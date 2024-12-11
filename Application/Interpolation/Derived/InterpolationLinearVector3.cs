using System.Reflection;
using UnityEngine;

namespace Scripts.Tools.Interpolation
{
    public class InterpolationLinearVector3<TInstance> : InterpolationBase<TInstance, Vector3>
    {
        public InterpolationLinearVector3(TInstance targetInstance, PropertyInfo targetProperty, InterpolationArgs<Vector3> args) 
            : base(targetInstance, targetProperty, args) {
        }

        public InterpolationLinearVector3(TInstance targetInstance, PropertyInfo targetProperty, Vector3 startValue, Vector3 finalValue, float byTime)
            : base(targetInstance, targetProperty, startValue, finalValue, byTime) {
            
        }

        protected override Vector3 Lerp(Vector3 startValue, Vector3 finalValue, float t) {
            return Vector3.Lerp(startValue, finalValue, t);
        }
    }
}