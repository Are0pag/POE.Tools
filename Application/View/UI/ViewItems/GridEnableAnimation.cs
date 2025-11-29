using UnityEngine;

namespace Scripts.Tools.View
{
    internal class GridEnableAnimation : MonoBehaviour
    {
        [SerializeField]
        protected ScaleComponent _scaleComponent;

        private void OnEnable() {
            _scaleComponent.SetScaleAnimation();
        }
    }
}