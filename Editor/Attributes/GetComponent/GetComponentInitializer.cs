using System;
using System.Linq;
using System.Reflection;
using POE.Tools.Editor;
using UnityEditor;
using UnityEngine;

namespace Scripts.Tools.CustomEdit
{
    [InitializeOnLoad]
    static internal class GetComponentInitializer
    {
        static GetComponentInitializer() {
            EditorApplication.delayCall += InitializeComponents;
        }
        
        static internal void InitializeComponents() {
            AttributeBuildHelper.GetObjectsFromScene(ProcessFields);
        }

        static private void ProcessFields(MonoBehaviour monoBehaviour) {
            var fields = monoBehaviour.GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                .Where(f => 
                    Attribute.IsDefined((MemberInfo)f, typeof(GetComponentAttribute)) 
                    && Attribute.IsDefined((MemberInfo)f, typeof(SerializeField)));

            foreach (var field in fields) {
                if (AttributeBuildHelper.IsFieldNeedsToInitialize(field, monoBehaviour))     
                    Initialize(monoBehaviour, field);
            }
        }

        static private void Initialize(MonoBehaviour monoBehaviour, FieldInfo field) {
            var fieldType = field.FieldType;
            if (typeof(Component).IsAssignableFrom(fieldType)) {
                var findComponentMethod = typeof(ComponentSearcher)
                    .GetMethod(nameof(ComponentSearcher.TryFindComponentInChildsRecursive))
                    ?.MakeGenericMethod(fieldType);

                if (findComponentMethod == null) 
                    return;
                            
                var component = findComponentMethod.Invoke(null, new object[] { monoBehaviour.gameObject.transform });
                if (component != null) {
                    field.SetValue(monoBehaviour, component);
                    Debug.Log($"[GetComponent] {field.Name} initialized on {monoBehaviour.name}.");
                }
                else {
                    Debug.LogWarning($"[GetComponent] Component of type {fieldType} not found on {monoBehaviour.name}.");
                }
            }
            else {
                Debug.LogWarning($"[GetComponent] Field {field.Name} is not a Component type.");
            }
        }
    }
}