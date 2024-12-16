using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Scripts.Tools.CustomEdit.Inspector
{
    [CustomEditor(typeof(RectTransform), true), CanEditMultipleObjects]
    internal class RectCustomEditor : Editor
    {
        private Editor _instance;
        private MethodInfo _onSceneGUI;

        private void OnEnable() {
            CreateDefaultInspector();
        }

        private void CreateDefaultInspector() {
            var editorType = Assembly.GetAssembly(typeof(Editor)).GetTypes().FirstOrDefault(m => m.Name == "RectTransformEditor");
            _instance = CreateEditor(targets, editorType);
            if (editorType != null) 
                _onSceneGUI = editorType.GetMethod("OnSceneGUI", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        }

        public override void OnInspectorGUI() {
            _instance.OnInspectorGUI();
            UIHelpButtons.DrawAndInitButtons((RectTransform)target);
        }
        
        
        private void OnSceneGUI() {
            if(_instance)
                try {
                    _onSceneGUI.Invoke(_instance, Array.Empty<object>());
                }
                catch (Exception) {
                    // ignored
                }
        }

        private void OnDisable() {
            try {
                if (_instance) 
                    DestroyImmediate(_instance);
            }
            catch (Exception) {
            }
        }
    }
}