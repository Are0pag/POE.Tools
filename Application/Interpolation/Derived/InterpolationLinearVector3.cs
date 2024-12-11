using UnityEngine;

namespace Scripts.Tools.Interpolation
{
    public class InterpolationLinearVector3 : InterpolationBase<Vector3>
    {
        protected override Vector3 Lerp(Vector3 startValue, Vector3 finalValue, float t) {
            return Vector3.Lerp(startValue, finalValue, t);
        }
    }
}