using Scripts.Tools.Attributes;
using UnityEngine;

namespace Scripts.Tools.View
{
    [System.Serializable]
    public abstract class AnimationComponent
    {
        [SerializeField] [GetComponent] protected Transform _transform;
        [Min(.1f)] public float Duration;
    }
}