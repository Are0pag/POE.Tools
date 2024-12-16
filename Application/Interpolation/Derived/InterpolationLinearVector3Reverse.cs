using System.Reflection;
using UnityEngine;

namespace Scripts.Tools.Interpolation
{
    public class InterpolationLinearVector3Reverse<TInstance> : AsyncOperationReverseInterpolationBase<TInstance, Vector3>
    {
        public InterpolationLinearVector3Reverse(TInstance targetInstance, PropertyInfo targetProperty, InterpolationArgs<Vector3> args) 
            : base(targetInstance, targetProperty, args) {
        }

        public InterpolationLinearVector3Reverse(TInstance targetInstance, PropertyInfo targetProperty, Vector3 startValue, Vector3 finalValue, float byTime) 
            : base(targetInstance, targetProperty, startValue, finalValue, byTime) {
        }

        protected override Vector3 Lerp(Vector3 startValue, Vector3 finalValue, float t) {
            return Vector3.Lerp(startValue, finalValue, t);
        }
    }
}