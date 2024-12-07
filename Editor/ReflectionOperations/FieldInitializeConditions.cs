using System;
using System.Reflection;

namespace Scripts.Tools.CustomEdit
{
    static public class FieldInitializeConditions
    {
        static public bool IsFieldNeedsToInitialize<TInstance>(TInstance targetType, FieldInfo fieldInfo)
            where TInstance : class
        {
            try {
                return !IsFieldInitialized(targetType, fieldInfo);
            }
            catch (NullReferenceException) {
                return false;
            }
        }
        
        static internal bool IsFieldInitialized<TInstance>(TInstance targetType, FieldInfo fieldInfo) 
            where TInstance : class
        {
            var currentValue = fieldInfo.GetValue(targetType);
            var defaultValue = Activator.CreateInstance(fieldInfo.FieldType);
            return !currentValue.Equals(defaultValue);
        }
    }
}