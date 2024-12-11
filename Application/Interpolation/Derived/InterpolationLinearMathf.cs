using System.Reflection;
using UnityEngine;

namespace Scripts.Tools.Interpolation
{
    public class InterpolationLinearMathf<TInstance> : InterpolationBase<TInstance, float>
    {
        public InterpolationLinearMathf(TInstance targetInstance, PropertyInfo targetProperty, InterpolationArgs<float> args) 
            : base(targetInstance, targetProperty, args) {
        }

        public InterpolationLinearMathf(TInstance targetInstance, PropertyInfo targetProperty, float startValue, float finalValue, float byTime)
            : base(targetInstance, targetProperty, startValue, finalValue, byTime) {
            
        }

        protected override float Lerp(float startValue, float finalValue, float t) {
            return Mathf.Lerp(startValue, finalValue, t);
        }
    }
}