using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Scripts.Tools.CustomEdit;
using UnityEngine;

namespace Scripts.Tools.Attributes.CustomEdit
{
    internal class GetComponentAttributeInitializer : AttributeInitializer
    {
        protected UnityEngine.Transform _cachedParentTransform;
        
        protected override bool IsTargetAttributeDefined(FieldInfo fieldInfo) {
            return Attribute.IsDefined(fieldInfo, typeof(GetComponentAttribute));
        }

        protected override Type GetTypeOfMethodContainer() {
            return typeof(ComponentSearcher);
        }

        protected override object[] SetParametersForRuntimeGenericMethod<TInstance>([DisallowNull] TInstance instance) {
            return new object[] { (instance as MonoBehaviour).gameObject.transform };
        }

        protected override void ContinueRecursively<TNestedInstance>(TNestedInstance nestedInstance) {
            
        }
    }
}