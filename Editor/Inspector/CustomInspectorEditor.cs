using Scripts.Tools.CustomEdit.Inspector;
using UnityEditor;
using UnityEngine;

namespace Scripts.Tools.CustomEdit
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(MonoBehaviour), true)]
    public class CustomInspectorEditor : Editor
    {
        public override void OnInspectorGUI() {
            if (target is not MonoBehaviour monoBehavior)
                return;

            InspectorButtonDrawer.ManageMethodsButtons(monoBehavior);
            NamedButton.DrawButton(monoBehavior);
            
            DrawDefaultInspector();
        }
    }
}
