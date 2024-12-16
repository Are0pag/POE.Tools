using Scripts.Tools;
using UnityEditor;
using UnityEngine;

namespace Scripts.Tools.CustomEdit.Inspector
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(MonoBehaviour), true)]
    public class CustomInspectorEditor : Editor
    {
        public override void OnInspectorGUI() {
            if (target is not MonoBehaviour monoBehavior)
                return;

            InspectorButtonDrawer.ManageMethodsButtons(monoBehavior);
            
            EditorGUILayout.BeginHorizontal();
            NamedButton.DrawButton(monoBehavior);
            MoveComponentButtons.DrawButtons(monoBehavior);
            EditorGUILayout.EndHorizontal();
            
            /*if (monoBehavior.transform.root.TryGetComponent(out Canvas canvas) || monoBehavior.transform.GetComponentsInChildren<Canvas>().Length > 0)
                UIHelpButtons.DrawAndInitButtons(monoBehavior);*/
            
            DrawDefaultInspector();
        }
    }
}
