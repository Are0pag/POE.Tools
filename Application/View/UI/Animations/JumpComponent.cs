using DG.Tweening;
using UnityEngine;

namespace Scripts.Tools.View
{
    [System.Serializable]
    public class JumpComponent : AnimationComponent
    {
        [Min(0)] public float JumpPower;
        [Min(0)] public float JumpHeight;
        [Min(1)] public int NumberOfJumps;

        public Sequence Jump(Ease ease = Ease.Linear) {
            return _transform
                .DOJump(new Vector3(_transform.position.x, _transform.position.y + JumpHeight, _transform.position.z), JumpPower, NumberOfJumps, Duration)
                .SetEase(ease)
                .SetAutoKill(false);
        }
    }
}