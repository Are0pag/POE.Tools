using Scripts.Tools.View;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

namespace Scripts.Tools.CustomEdit.View
{
    [CustomEditor(typeof(LinkedButton))]
    public class LinkedButtonEditor : ButtonEditor
    {
        private SerializedProperty _imageProp;
        private SerializedProperty _textProp;

        protected override void OnEnable() {
            base.OnEnable();
            _imageProp = serializedObject.FindProperty("_interactableImage");
            _textProp = serializedObject.FindProperty("_text");
        }

        public override void OnInspectorGUI() {
            AddCustomSerializeFields();
            EditorGUILayout.Space();
            base.OnInspectorGUI();
        }

        private void Construct() {
            //Creator.CreateMonoBehavior()
        }

        private void AddCustomSerializeFields() {
            serializedObject.Update();

            EditorGUILayout.LabelField("LinkedButton Properties", EditorStyles.miniBoldLabel);

            EditorGUILayout.PropertyField(_imageProp, new GUIContent("Image"));
            EditorGUILayout.PropertyField(_textProp, new GUIContent("Text"));

            serializedObject.ApplyModifiedProperties();
        }
    }
}