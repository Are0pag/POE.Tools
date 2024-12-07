using System;
using System.Reflection;
using Scripts.Tools.CustomEdit;
using UnityEngine;

namespace Scripts.Tools.Attributes.CustomEdit
{
    internal abstract class AttributeInitializer
    {
        internal void InitializeTargetFields() {
            foreach (var monoBehaviour in InvokerOnScriptsReload.StoredMonoBehaviours) {
                try {
                    ManageInstanceFieldsRecursive(monoBehaviour);
                }
                catch (System.StackOverflowException) {
                    Debug.Log($"{nameof(StackOverflowException)} from {nameof(AttributeInitializer)}");
                }
            }
        }

        protected void ManageInstanceFieldsRecursive<TInstance>(TInstance instance) 
            where TInstance : class
        {
            var type = instance.GetType();
            foreach (var fieldInfo in FieldsExtractor.GetSerializeFieldsFromType(type)) {
                if (fieldInfo.FieldType.IsValueType) 
                    continue;

                if (IsTargetAttributeDefined(fieldInfo)) {
                    if (!FieldInitializeConditions.IsFieldNeedsToInitialize(instance, fieldInfo)) 
                        continue;
                    
                    if (GenericMethodMaker.Make(GetTypeOfMethodContainer(), fieldInfo) is {} method)
                        if (method.Invoke(null, SetParametersForRuntimeGenericMethod(instance)) is {} result)
                            fieldInfo.SetValue(instance, result);
                    
                    //Debug.Log($"!ATTRIBUTE_TARGET! \n declaringType: {fieldInfo.DeclaringType?.Name}, \n name: {fieldInfo.Name}"); 
                    continue;
                }
                
                ContinueRecursively(nestedInstance: fieldInfo.GetValue(instance));
            }
        }

        protected abstract bool IsTargetAttributeDefined(FieldInfo fieldInfo);

        protected abstract Type GetTypeOfMethodContainer();
        
        protected abstract object[] SetParametersForRuntimeGenericMethod<TInstance>(TInstance instance) where TInstance : class;

        protected abstract void ContinueRecursively<TNestedInstance>(TNestedInstance nestedInstance) where TNestedInstance : class;
    }
}
