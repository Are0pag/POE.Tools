using Cysharp.Threading.Tasks;
using System.Threading;
using System.Reflection;
using System.Diagnostics;
using UnityEngine;

namespace Scripts.Tools.Interpolation
{
    public delegate UniTask InterpolateDelegate<in TInstance, TValueType>(TInstance targetInstance, PropertyInfo targetProperty, InterpolationArgs<TValueType> args);
    
    public abstract class InterpolationBase<TValueType> : IAsyncOperation
    {
        public CancellationTokenSource CancellationTokenSource { get; set; } = new();

        public async UniTask InterpolateAsync<TInstance>(TInstance targetInstance, PropertyInfo targetProperty, InterpolationArgs<TValueType> args) {
            var stopWatch = Stopwatch.StartNew();
            float elapsedTime = 0f;
            while (stopWatch.Elapsed.Seconds < args.ByTime) {
                targetProperty.SetValue(targetInstance, Lerp(args.StartValue, args.FinalValue, Mathf.Clamp01(elapsedTime += Time.deltaTime / args.ByTime)));
                await UniTask.Yield(CancellationTokenSource.Token);
            }
            // Ensure the final value is applied at the end 
            targetProperty.SetValue(targetInstance, args.FinalValue);
        }

        protected abstract TValueType Lerp(TValueType startValue, TValueType finalValue, float t);
    }
}