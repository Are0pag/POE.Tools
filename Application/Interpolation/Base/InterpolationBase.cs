using System;
using Cysharp.Threading.Tasks;
using System.Threading;
using System.Reflection;
using System.Diagnostics;
using Scripts.Tools.AsyncOperationsHandle;
using UnityEngine;

namespace Scripts.Tools.Interpolation
{
    public abstract class InterpolationBase<TInstance, TValueType> : IAsyncOperation
    {
        protected readonly TInstance _targetInstance; 
        protected readonly PropertyInfo _targetProperty;
        protected readonly InterpolationArgs<TValueType> _args;

        protected InterpolationBase(TInstance targetInstance, PropertyInfo targetProperty, InterpolationArgs<TValueType> args) {
            _targetInstance = targetInstance;
            _targetProperty = targetProperty;
            _args = args;
        }

        protected InterpolationBase(TInstance targetInstance, PropertyInfo targetProperty, TValueType startValue, TValueType finalValue, float byTime) {
            _targetInstance = targetInstance;
            _targetProperty = targetProperty;

            _args = new InterpolationArgs<TValueType> {
                ByTime = byTime,
                StartValue = startValue,
                FinalValue = finalValue,
            };
        }
        
        public async UniTask RunAsyncOperation(CancellationTokenSource cts) {
            var stopWatch = Stopwatch.StartNew();
            float elapsedTime = 0f;
            while (stopWatch.Elapsed.Seconds < _args.ByTime) {
                _targetProperty.SetValue(_targetInstance, Lerp(_args.StartValue, _args.FinalValue, Mathf.Clamp01(elapsedTime += Time.deltaTime / _args.ByTime)));
                await UniTask.Yield(cts.Token);
            }
            // Ensure the final value is applied at the end 
            _targetProperty.SetValue(_targetInstance, _args.FinalValue);
        }

        protected abstract TValueType Lerp(TValueType startValue, TValueType finalValue, float t);
    }

    public class InterpolationCreator
    {
        
    }
}