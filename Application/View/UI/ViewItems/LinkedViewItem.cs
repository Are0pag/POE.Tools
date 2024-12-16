using Scripts.Tools.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Tools.View
{
    [System.Serializable]
    public class LinkedViewItem : ViewItem
    {
        [SerializeField] [GetComponent] protected TextMeshPro _text;
        public TextMeshPro Text {
            get => _text;
            set => _text = value;
        }
    }

    [System.Serializable]
    public class ViewItemWithHint : ViewItem
    {
        [SerializeField] protected GameObject _hintPrefab;
    }

    [System.Serializable]
    public class ViewItem
    {
        [SerializeField] [GetComponent] protected Image _image;
        public Image Image {
            get => _image;
            protected set => _image = value;
        }
    }
}