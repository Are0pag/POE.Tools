using System;
using System.Linq;
using System.Reflection;
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
            foreach (var gameObject in GameObject.FindObjectsByType<GameObject>(FindObjectsSortMode.None)) {
                foreach (var monoBehaviour in gameObject.GetComponents<MonoBehaviour>()) {
                    if (monoBehaviour == null) 
                        continue;

                    ProcessFields(monoBehaviour);
                }
            }
        }

        static private void ProcessFields(MonoBehaviour monoBehaviour) {
            // Process fields with [GetComponent] attribute
            var fields = monoBehaviour.GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                .Where(f => 
                    Attribute.IsDefined((MemberInfo)f, typeof(GetComponentAttribute)) 
                    && Attribute.IsDefined((MemberInfo)f, typeof(SerializeField)));

            foreach (var field in fields) {
                if (IsFieldInitialized(field, field.GetValue(monoBehaviour))) 
                    return;
                        
                Initialize(field.FieldType, monoBehaviour, field);
            }
        }

        static private void Initialize(Type fieldType, MonoBehaviour monoBehaviour, FieldInfo field) {
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

        static private bool IsFieldInitialized(FieldInfo field, object fieldValue) {
            if (fieldValue == null)
                return false;

            return !field.FieldType.IsValueType || !fieldValue.Equals(Activator.CreateInstance(field.FieldType));
        }
    }
}