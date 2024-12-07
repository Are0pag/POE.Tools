using System;
using System.Reflection;
using Scripts.Tools.CustomEdit;

namespace Scripts.Tools.Attributes.CustomEdit
{
    internal class FindAttributeInitializer : AttributeInitializer
    {
        protected override bool IsTargetAttributeDefined(FieldInfo fieldInfo) {
            return Attribute.IsDefined(fieldInfo, typeof(FindInSceneAttribute));
        }

        protected override Type GetTypeOfMethodContainer() {
            return typeof(ComponentFinder);
        }

        protected override object[] SetParametersForRuntimeGenericMethod<TInstance>(TInstance instance) {
            return null;
        }

        protected override void ContinueRecursively<TNestedInstance>(TNestedInstance nestedInstance) {
            base.ManageInstanceFieldsRecursive(nestedInstance);
        }
    }
}