using System;
using DG.Tweening;
using Scripts.Tools.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Tools.View
{
    public class Hint : MonoBehaviour
    {
        public float LiveTime = 5f;
        [SerializeField] JumpComponent _jumpComponent;
        [SerializeField] ScaleComponent _scaleComponent;
        public LinkedViewItem LinkedViewItem;

        public void Init(Sprite sprite, string text = "") {
            LinkedViewItem.Text.text = text;
            LinkedViewItem.Image.sprite = sprite;
        }
       
        protected void OnEnable() {
            transform.position = new Vector3(transform.position.x, transform.position.y - _jumpComponent.JumpHeight, transform.position.z);
            _jumpComponent.Jump();
            
            
            Invoke(nameof(StartDisableAnimation), LiveTime);
        }

        protected void Update() {
            if (Input.GetMouseButtonDown(0))
                StartDisableAnimation();
        }

        protected void StartDisableAnimation() {
            transform.DOPlayBackwards();
            Invoke(nameof(Disable), _scaleComponent.Duration);
        }

        protected void Disable() {
            gameObject.SetActive(false);
        }
        
        #if UNITY_EDITOR
        [InspectorButton(ExecutingMode.IsEditorOnly)]
        private void Create() {
            Creator.CreateMonoBehavior(new CreationArgs<TextMeshPro>(transform.GetChild(0).transform));
            Creator.CreateMonoBehavior(new CreationArgs<Image>(transform.GetChild(0).transform));
        }
        #endif
    }
}