using System.Reflection;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Scripts.Tools.Interpolation
{
    public abstract class InterpolationBase<TValueType>
    {
        /*public async UniTask RunAsync<TInstance>(TInstance targetInstance, PropertyInfo targetProperty, InterpolationArgs<TValueType> args) {
            await new MiddleWareAsync(InterpolateAsync(targetInstance, targetProperty, args)).RunAsync();
        }*/

        public async UniTask InterpolateAsync<TInstance>(TInstance targetInstance, PropertyInfo targetProperty, InterpolationArgs<TValueType> args, CancellationTokenSource cts) {
            float elapsedTime = 0f;
            while (elapsedTime < args.ByTime) {
                targetProperty.SetValue(targetInstance, Lerp(args.StartValue, args.FinalValue, Mathf.Clamp01(elapsedTime += Time.deltaTime / args.ByTime)));
                await UniTask.Yield(cts.Token);
            }
            // Ensure the final value is applied at the end
            targetProperty.SetValue(targetInstance, args.FinalValue);
        }

        protected abstract TValueType Lerp(TValueType startValue, TValueType finalValue, float t);
    }
}