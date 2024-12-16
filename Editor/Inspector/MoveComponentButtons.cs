using UnityEditorInternal;
using UnityEngine;

namespace Scripts.Tools.CustomEdit.Inspector
{
    static public class MoveComponentButtons
    {
        private const int WIDTH = 45;
        private const int HEIGHT = 15;
        
        static public void DrawButtons(Component component) {
            if (!Application.isPlaying && GUILayout.Button("Up", GUILayout.Width(WIDTH), GUILayout.Height(HEIGHT)))
                ComponentUtility.MoveComponentUp(component);
            
            if (!Application.isPlaying && GUILayout.Button("Down", GUILayout.Width(WIDTH), GUILayout.Height(HEIGHT)))
                ComponentUtility.MoveComponentDown(component);
        }
    }
}