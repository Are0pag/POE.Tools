using System;
using UnityEditor;
using UnityEngine;

namespace Scripts.Tools.CustomEdit.Inspector
{
    [CustomEditor(typeof(Transform))]
    internal class TransformResetEditor : Editor
    {
        #region Strings

        private const string RESET_BUTTON_TEXT = "Reset";
        private const string POSITION_LABEL = "Position";
        private const string ROTATION_LABEL = "Rotation";
        private const string SCALE_LABEL = "Scale";
        private const string RESET_SCALE_UNDO = "Reset Scale";
        private const string RESET_POSITION_UNDO = "Reset Position";

        #endregion

        public override void OnInspectorGUI() {
            Transform targetTransform = (Transform)target;

            AddButton(() => { Position(targetTransform); });
            AddButton(() => { Scale(targetTransform); });
            AddButton(() => { Rotation(targetTransform); });
        }

        static private void AddButton(Action action) {
            EditorGUILayout.BeginHorizontal();
            action?.Invoke();
            EditorGUILayout.EndHorizontal();
        }

        static private void Rotation(Transform targetTransform) {
            Vector3 rotationEuler = targetTransform.rotation.eulerAngles;
            Vector3 newRotation = EditorGUILayout.Vector3Field(ROTATION_LABEL, rotationEuler);
            
            if (Button()) {
                Undo.RecordObject(targetTransform, "Reset Rotation");
                targetTransform.rotation = Quaternion.identity;
            }

            if (newRotation != rotationEuler) {
                Undo.RecordObject(targetTransform, "Modify Rotation");
                targetTransform.rotation = Quaternion.Euler(newRotation);
            }
        }

        static private void Scale(Transform targetTransform) {
            targetTransform.localScale = EditorGUILayout.Vector3Field(SCALE_LABEL, targetTransform.localScale);
            if (Button()) {
                Undo.RecordObject(targetTransform, RESET_SCALE_UNDO);
                targetTransform.localScale = Vector3.one;
            }
        }

        static private void Position(Transform targetTransform) {
            if (!targetTransform.parent) 
                targetTransform.position = EditorGUILayout.Vector3Field(POSITION_LABEL, targetTransform.position);
            else
                targetTransform.localPosition = EditorGUILayout.Vector3Field(POSITION_LABEL, targetTransform.localPosition);
            
            if (Button()) {
                Undo.RecordObject(targetTransform, RESET_POSITION_UNDO);
                targetTransform.localPosition = Vector3.zero;
            }
        }

        static private bool Button() => GUILayout.Button(RESET_BUTTON_TEXT, GUILayout.Width(60));
    }
}