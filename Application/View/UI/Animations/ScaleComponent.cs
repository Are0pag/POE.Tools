using DG.Tweening;
using UnityEngine;

namespace Scripts.Tools.View
{
    [System.Serializable]
    public class ScaleComponent : AnimationComponent
    {
        public Vector3 StartScale = Vector3.zero;
        public Vector3 EndScale = Vector3.one;
        
        public void SetScaleAnimation(Ease ease = Ease.Linear) {
            _transform
                .DOScale(EndScale, Duration)
                .From(StartScale)
                .SetEase(ease)
                .SetAutoKill(false);
        }
    }
}