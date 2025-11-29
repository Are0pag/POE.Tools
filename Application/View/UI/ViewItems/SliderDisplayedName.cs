using System;
using Scripts.Tools.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Tools.View
{
    public class SliderDisplayedName : MonoBehaviour
    {
        protected Action<int> _onInput;
        
        [SerializeField, GetComponent] 
        protected Slider _slider;

        [SerializeField, GetComponent] 
        protected TextMeshPro _nameText;
        
        public Slider Slider {
            get => _slider;
            protected set => _slider = value;
        }

        public TextMeshPro NameText {
            get => _nameText;
            protected set => _nameText = value;
        }

        public void Initialize(string nameText, Action<int> onInput = null, int initializeValue = 0, int minValue = 0, int maxValue = 1) {
            _onInput = onInput;
            _nameText.text = nameText;
            _slider.minValue = minValue;
            _slider.maxValue = maxValue;
            
            _slider.onValueChanged?.Invoke(initializeValue);
        }  
    }
}