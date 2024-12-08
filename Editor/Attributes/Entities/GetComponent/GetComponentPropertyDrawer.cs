using UnityEditor;
using UnityEngine;

namespace Scripts.Tools.Attributes.CustomEdit
{
    [CustomPropertyDrawer(typeof(Scripts.Tools.Attributes.GetComponentAttribute))]
    internal class GetComponentPropertyDrawer : AttributePropertyDrawer
    {
        protected override Component GetTargetFieldValue(MonoBehaviour targetObject) {
            return new GetComponentAttributeInitializer().GetTargetFieldValue(targetObject, fieldInfo) as Component;
        }

        protected override string SetButtonName() {
            return "GetComp";
        }
    }
}

