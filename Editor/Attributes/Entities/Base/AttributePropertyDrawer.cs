using UnityEditor;
using UnityEngine;

namespace Scripts.Tools.Attributes.CustomEdit
{
    internal abstract class AttributePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            
            Rect fieldRect = new Rect(position.x, position.y, position.width - 80, position.height);
            Rect buttonRect = new Rect(position.x + position.width - 70, position.y, 70, position.height);

            EditorGUI.PropertyField(fieldRect, property, label);

            if (property.propertyType == SerializedPropertyType.ObjectReference) {
                if (GUI.Button(buttonRect, SetButtonName())) {
                    if (property.serializedObject.targetObject is MonoBehaviour targetObject) {
                        property.objectReferenceValue = GetTargetFieldValue(targetObject);
                        property.serializedObject.ApplyModifiedProperties();
                    }
                }
            }
            else {
                EditorGUI.HelpBox(buttonRect, "Invalid Type", MessageType.Warning);
            }
        }

        protected abstract Component GetTargetFieldValue(MonoBehaviour targetObject);

        protected abstract string SetButtonName();
    }
}