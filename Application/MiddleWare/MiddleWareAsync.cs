using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Scripts.Tools.CustomEdit;

namespace Scripts.Tools.Interpolation
{
    public class MiddleWareAsync
    {
        protected readonly IAsyncOperation _asyncOperation;
        protected readonly CancellationTokenSource _cancellationTokenSource;

        public MiddleWareAsync(IAsyncOperation asyncOperation) {
            _asyncOperation = asyncOperation;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public void Cancel() {
           _cancellationTokenSource.Cancel();
        }

        public async UniTask RunAsync() {
            try {
                await _asyncOperation.RunAsyncOperation(_cancellationTokenSource);
            }
            catch (Exception exception) {
#if UNITY_EDITOR
                ExceptionLogger.Log(exception);
#endif
            }
        }
    }
}