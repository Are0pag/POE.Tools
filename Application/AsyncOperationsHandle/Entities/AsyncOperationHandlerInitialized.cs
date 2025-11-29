using System.Diagnostics.CodeAnalysis;
using Cysharp.Threading.Tasks;

namespace Scripts.Tools.AsyncOperationsHandle
{
    public class AsyncOperationHandlerInitialized : IAsyncOperationHandlerInitialized
    {
        [AllowNull]
        protected AsyncOperationHandler _asyncOperationHandler;

        public bool IsRunning {
            get {
                if (_asyncOperationHandler == null)
                    return false;
                return _asyncOperationHandler.IsRunning;
            }
        }

        void IAsyncOperationHandlerInitialized.Initialize(IAsyncOperation asyncOperation) {
            Cancel();
            _asyncOperationHandler = new AsyncOperationHandler(asyncOperation);
        }

        void IAsyncOperationHandlerInitialized.Initialize(AsyncOperationHandler asyncOperationHandler) {
            Cancel();
            _asyncOperationHandler = asyncOperationHandler;
        }

        public async UniTask RunAsync() => await _asyncOperationHandler.RunAsync();

        public void Cancel() {
            _asyncOperationHandler?.Cancel();
        }
    }
}