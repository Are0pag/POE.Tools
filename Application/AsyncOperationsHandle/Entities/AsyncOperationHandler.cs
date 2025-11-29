using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Scripts.Tools.CustomEdit;

namespace Scripts.Tools.AsyncOperationsHandle
{
    public class AsyncOperationHandler : IAsyncOperationHandler
    {
        protected readonly IAsyncOperation _asyncOperation;
        protected readonly CancellationTokenSource _cancellationTokenSource;

        public bool IsRunning;

        public AsyncOperationHandler(IAsyncOperation asyncOperation) {
            _asyncOperation = asyncOperation;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public async UniTask RunAsync() {
            try {
                IsRunning = true;
                await _asyncOperation.RunAsyncOperation(_cancellationTokenSource);
            }
            catch (Exception exception) {
                #if UNITY_EDITOR
                exception.Log(this);
                #endif
            }
            finally {
                IsRunning = false;
            }
        }

        public void Cancel() {
            IsRunning = false;
            _cancellationTokenSource.Cancel();
        }
    }
}