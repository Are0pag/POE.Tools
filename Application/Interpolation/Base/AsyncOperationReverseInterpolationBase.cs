using System.Reflection;
using Scripts.Tools.AsyncOperationsHandle;

namespace Scripts.Tools.Interpolation
{
    public abstract class AsyncOperationReverseInterpolationBase<TInstance, TValueType> : InterpolationBase<TInstance, TValueType>, IAsyncOperationReverse
    {
        protected AsyncOperationReverseInterpolationBase(TInstance targetInstance, PropertyInfo targetProperty, InterpolationArgs<TValueType> args) 
            : base(targetInstance, targetProperty, args) {
        }

        protected AsyncOperationReverseInterpolationBase(TInstance targetInstance, PropertyInfo targetProperty, TValueType startValue, TValueType finalValue, float byTime) 
            : base(targetInstance, targetProperty, startValue, finalValue, byTime) {
        }

        public void Reverse() {
            (_args.FinalValue, _args.StartValue) = (_args.StartValue, _args.FinalValue);
        }
    }
}