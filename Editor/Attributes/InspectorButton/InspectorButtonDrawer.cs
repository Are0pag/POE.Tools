using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Scripts.Tools.CustomEdit
{
    [CustomEditor(typeof(MonoBehaviour), true)]
    internal class InspectorButtonDrawer : Editor
    {
        public override void OnInspectorGUI() {
            if (target is not MonoBehaviour monoBehaviour) 
                return;

            var methods = monoBehaviour.GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly);

            foreach (var method in methods) {
                if (method.GetCustomAttribute<InspectorButtonAttribute>() is not { } attribute)
                    continue;
                
                var buttonLabel = string.IsNullOrEmpty(attribute.ButtonLabel) ? method.Name : attribute.ButtonLabel;
                if (IsEnabled(attribute.Mode) && GUILayout.Button(buttonLabel))
                    method.Invoke(monoBehaviour, null);
            }

            DrawDefaultInspector();
        }

        private bool IsEnabled(ExecutingMode executingMode) {
            if (executingMode == ExecutingMode.Both)
                return true;
            
            return (Application.isPlaying && executingMode == ExecutingMode.IsPlayingOnly) 
                   || (!Application.isPlaying && executingMode == ExecutingMode.IsEditorOnly);
        }
    }
}