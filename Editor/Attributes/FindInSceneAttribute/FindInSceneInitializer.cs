using System;
using System.Linq;
using System.Reflection;
using POE.Tools.Editor;
using UnityEditor;
using UnityEngine;

namespace Scripts.Tools.CustomEdit
{
    [InitializeOnLoad]
    static internal class FindInSceneInitializer
    {
        static FindInSceneInitializer() {
            EditorApplication.delayCall += InitializeComponents;
        }

        static internal void InitializeComponents() {
            AttributeBuildHelper.GetObjectsFromScene(ProcessFields);
        }

        static private void ProcessFields(MonoBehaviour monoBehaviour) {
            var fields = monoBehaviour.GetType()
                .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f =>
                    Attribute.IsDefined((MemberInfo)f, typeof(FindInSceneAttribute))
                    && Attribute.IsDefined((MemberInfo)f, typeof(SerializeField)));

            foreach (var field in fields) {
                if (AttributeBuildHelper.IsFieldNeedsToInitialize(field, monoBehaviour))
                    InitializeField(field, monoBehaviour);
            }
        }

        static private void InitializeField(FieldInfo fieldInfo, MonoBehaviour monoBehaviour) {
            var fieldType = fieldInfo.FieldType;
            if (!typeof(Component).IsAssignableFrom(fieldType)) 
                return;
            
            var method = typeof(Finder).GetMethod(nameof(Finder.FindComponentInScene))?.MakeGenericMethod(fieldType);
            if (method == null)
                return;
                
            var component = method.Invoke(null, null);
            if (component != null) {
                fieldInfo.SetValue(monoBehaviour, component);
            }
        }
    }
}