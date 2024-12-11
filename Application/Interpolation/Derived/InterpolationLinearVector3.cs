using System.Reflection;
using UnityEngine;

namespace Scripts.Tools.Interpolation
{
    public class InterpolationLinearVector3<TInstance> : InterpolationBase<TInstance, Vector3>
    {
        public InterpolationLinearVector3(TInstance targetInstance, PropertyInfo targetProperty, InterpolationArgs<Vector3> args) 
            : base(targetInstance, targetProperty, args) {
        }

        protected override Vector3 Lerp(Vector3 startValue, Vector3 finalValue, float t) {
            return Vector3.Lerp(startValue, finalValue, t);
        }
    }
}