using System.Globalization;
using TMPro;
using UnityEngine;

namespace Scripts.Tools.View
{
    public class SliderDisplayedNameAndValue : SliderDisplayedName
    {
        [SerializeField] protected TextMeshPro _valueText;
        public TextMeshPro ValueText {
            get => _valueText;
            protected set => _valueText = value;
        }

        protected void OnEnable() {
            _slider.onValueChanged.AddListener((v) => {
                                                   ValueText.text = v.ToString(CultureInfo.InvariantCulture);
                                                   _slider.value = v;
                                                   _onInput?.Invoke((int) v);
                                               });
        }

        protected void OnDisable() {
            _slider.onValueChanged.RemoveAllListeners();
        }
    }
}