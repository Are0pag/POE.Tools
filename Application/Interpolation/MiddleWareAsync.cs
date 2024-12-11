using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Scripts.Tools.Interpolation
{
    public delegate UniTask TaskAction(UniTask task);
    
    public class MiddleWareAsync
    {
        protected readonly UniTask _task;
        protected readonly TaskAction _taskAction;
        //protected readonly CancellationTokenSource _cts;

        public MiddleWareAsync(UniTask task
            //, CancellationTokenSource cancellationTokenSource
            ) {
            _task = task;
            //_cts = cancellationTokenSource;
        }
        
        

        public void Cancel() {
           // _cts?.Cancel();
        }

        public async UniTask RunAsync() {
            try {
                await _task;
            }
            catch (Exception exception) {
#if UNITY_EDITOR
                LogException(exception);
#endif
            }
        }

#if UNITY_EDITOR
        private void LogException(Exception exception) {
            if (exception is OperationCanceledException) 
                Debug.Log($"{nameof(OperationCanceledException)} from {exception.TargetSite}");
            
            if (exception is MissingReferenceException)
                Debug.Log($"{nameof(MissingReferenceException)} from {exception.StackTrace}");
        }
#endif
    }
}