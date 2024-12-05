using System;
using System.Reflection;
using UnityEngine;

namespace POE.Tools.Editor
{
    static internal class AttributeBuildHelper
    {
        static internal void GetObjectsFromScene(Action<MonoBehaviour> processFields) {
            foreach (var gameObject in GameObject.FindObjectsByType<GameObject>(FindObjectsSortMode.None)) {
                foreach (var monoBehaviour in gameObject.GetComponents<MonoBehaviour>()) {
                    if (monoBehaviour == null) 
                        continue;
                    processFields?.Invoke(monoBehaviour);
                }
            }
        }

        static internal bool IsFieldNeedsToInitialize(FieldInfo field, MonoBehaviour monoBehaviour) {
            if (field.FieldType.IsValueType) 
                return false;
            
            return !IsFieldInitialized(field, monoBehaviour);
        }
        
        static private bool IsFieldInitialized(FieldInfo field, MonoBehaviour monoBehaviour) {
            return !field.GetValue(monoBehaviour).Equals(Activator.CreateInstance(field.FieldType));
        }
    }
}