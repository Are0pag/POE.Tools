using Scripts.Tools.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Scripts.Tools.View
{
    [DisallowMultipleComponent, RequireComponent(typeof(RectTransform))]
    public class LinkedButton : UnityEngine.UI.Button
    {
        [SerializeField] [GetComponent] private Image _interactableImage; 
        [SerializeField] [GetComponent] private TextMeshProUGUI _text;

        public Image InteractableImage => _interactableImage; 
        public TextMeshProUGUI Text => _text;

        public void Init(ViewItemStyle viewItemStyle) {
            _interactableImage.sprite = viewItemStyle.Sprite;
            _text.text = viewItemStyle.Label;
        }
        
        #if UNITY_EDITOR
        protected override void OnValidate() {
            base.OnValidate();
            if (_interactableImage != null) 
                targetGraphic = _interactableImage;
        }
        #endif
    }
}