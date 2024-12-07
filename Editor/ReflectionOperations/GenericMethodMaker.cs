using System;
using System.Reflection;
using UnityEngine;

namespace Scripts.Tools.CustomEdit
{
    static public class GenericMethodMaker
    {
        static public MethodInfo Make(Type staticObject, FieldInfo fieldInfo)
        {
            var instanceMethods = staticObject
                .GetMethods(BindingFlags.Public | BindingFlags.Static);
            
            if (IsCorrespondConditions(instanceMethods)) 
                return null;

            if (instanceMethods[0].MakeGenericMethod(fieldInfo.FieldType) is { } methodInfo) {
                return methodInfo;
            }
            return null;
        }
        
        static private bool IsCorrespondConditions(MethodInfo[] instanceMethods) {
            if (instanceMethods.Length == 0) {
                Debug.LogError($"{nameof(GenericMethodMaker)}.{nameof(Make)} method expected exactly one method.");
                return true;
            } else if (instanceMethods.Length != 1) {
                Debug.LogError($"{nameof(GenericMethodMaker)}.{nameof(Make)} method do not find any methods.");
                return true;
            }

            return false;
        }
    }
}