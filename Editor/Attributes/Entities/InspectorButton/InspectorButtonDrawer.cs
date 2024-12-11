using System.Reflection;
using Scripts.Tools.Attributes;
using UnityEngine;

namespace Scripts.Tools.CustomEdit
{
    static public class InspectorButtonDrawer
    {
        static public void ManageMethodsButtons(MonoBehaviour monoBehaviour) {
            var methods = monoBehaviour.GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly);

            foreach (var method in methods) {
                if (method.GetCustomAttribute<InspectorButtonAttribute>() is not { } attribute)
                    continue;
                
                var buttonLabel = string.IsNullOrEmpty(attribute.ButtonLabel) ? method.Name : attribute.ButtonLabel;
                if (IsEnabled(attribute.Mode) && GUILayout.Button(buttonLabel))
                    method.Invoke(monoBehaviour, null);
            }
        }

        static private bool IsEnabled(ExecutingMode executingMode) {
            if (executingMode == ExecutingMode.Both)
                return true;
            
            return (Application.isPlaying && executingMode == ExecutingMode.IsPlayingOnly) 
                   || (!Application.isPlaying && executingMode == ExecutingMode.IsEditorOnly);
        }
    }
}