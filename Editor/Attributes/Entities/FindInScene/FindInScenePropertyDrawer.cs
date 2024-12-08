using UnityEditor;
using UnityEngine;

namespace Scripts.Tools.Attributes.CustomEdit
{
    [CustomPropertyDrawer(typeof(FindInSceneAttribute))]
    internal class FindInScenePropertyDrawer : AttributePropertyDrawer
    {
        protected override Component GetTargetFieldValue(MonoBehaviour targetObject) {
            return new FindAttributeInitializer().GetTargetFieldValue(targetObject, fieldInfo) as Component;
        }

        protected override string SetButtonName() {
            return "Find";
        }
    }
}