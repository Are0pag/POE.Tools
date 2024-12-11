using UnityEngine;

namespace Scripts.Tools.Interpolation
{
    [System.Serializable]
    public class InterpolationArgs<TValueType>
    {
        [field: SerializeField] public float ByTime { get; set; }
        [field: SerializeField] public TValueType StartValue { get; set; }
        [field: SerializeField] public TValueType FinalValue { get; set; }
    }
}