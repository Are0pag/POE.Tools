using UnityEngine;

namespace Scripts.Tools.Interpolation
{
    public class InterpolationLinearMathf : InterpolationBase<float>
    {
        protected override float Lerp(float startValue, float finalValue, float t) {
            return Mathf.Lerp(startValue, finalValue, t);
        }
    }
}