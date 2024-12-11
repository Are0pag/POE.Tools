using UnityEngine;

namespace Scripts.Tools.Interpolation
{
    [System.Serializable]
    public class InterpolationArgs<TValueType>
    {
        [field: SerializeField] public float ByTime { get; protected set; }
        [field: SerializeField] public TValueType StartValue { get; protected set; }
        [field: SerializeField] public TValueType FinalValue { get; protected set; }
    }
}