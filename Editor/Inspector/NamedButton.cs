using UnityEngine;

namespace Scripts.Tools.CustomEdit.Inspector
{
    static public class NamedButton
    {
        static public void DrawButton(MonoBehaviour monoBehaviour) {
            if (!Application.isPlaying && GUILayout.Button("SameName", GUILayout.Width(80), GUILayout.Height(15)))
                monoBehaviour.gameObject.name = monoBehaviour.GetType().Name;
        }
    }
}
    