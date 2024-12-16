using Scripts.Tools.View;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace Scripts.Tools.CustomEdit.Inspector
{
    static internal class UIHelpButtons
    {
        private const float HEIGHT = 18;
        private const float WIDTH = 90;

        static internal void DrawAndInitButtons(RectTransform rect) {
            EditorGUILayout.BeginHorizontal();

            if (!Application.isPlaying && GUILayout.Button("ByAnchor", GUILayout.Width(WIDTH), GUILayout.Height(HEIGHT)))
                ByAnchor(rect);
            
            if (!Application.isPlaying && GUILayout.Button("FullAnchor", GUILayout.Width(WIDTH), GUILayout.Height(HEIGHT)))
                FullAnchor(rect);
            
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.BeginHorizontal();
            
            if (!Application.isPlaying && GUILayout.Button("CreateText", GUILayout.Width(WIDTH), GUILayout.Height(HEIGHT)))
                InitText(Creator.CreateMonoBehavior(new CreationArgs<TextMeshPro>(rect)));
                
            
            if (!Application.isPlaying && GUILayout.Button("CreateImg", GUILayout.Width(WIDTH), GUILayout.Height(HEIGHT)))
                InitNew(Creator.CreateMonoBehavior(new CreationArgs<UnityEngine.UI.Image>(rect)).rectTransform);

            if (!Application.isPlaying && GUILayout.Button("CreateLinkBut", GUILayout.Width(WIDTH), GUILayout.Height(HEIGHT)))
                InitNew(Creator.CreateMonoBehavior(new CreationArgs<LinkedButton>(rect)).gameObject.GetComponent<RectTransform>());
                
            EditorGUILayout.EndHorizontal();
        }

        static private void InitText(TextMeshPro text) {
            text.alignment = TextAlignmentOptions.Center;
            text.horizontalAlignment = HorizontalAlignmentOptions.Center;
            text.verticalAlignment = VerticalAlignmentOptions.Middle;
            InitNew(text.rectTransform);
        }

        static private void InitNew(RectTransform rect) {
            rect.localScale = Vector3.one;
            rect.position = Vector3.zero;
            rect.localPosition = Vector3.zero;
        }

        static private void ByAnchor(RectTransform rect) {
            rect.localPosition = Vector3.zero;
            rect.anchoredPosition = Vector3.zero;
            rect.sizeDelta = Vector3.zero;
        }

        static private void FullAnchor(RectTransform rect) {
            rect.anchorMax = Vector2.one;
            rect.anchorMin = Vector2.zero;
            ByAnchor(rect);
        }
    }
}