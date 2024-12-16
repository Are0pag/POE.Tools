using Cysharp.Threading.Tasks;

namespace Scripts.Tools.Interpolation
{
    public class AsyncOperationHandlerInitialized : IAsyncOperationHandlerInitialized
    {
        protected AsyncOperationHandler _asyncOperationHandler;
        
        public void Initialize(IAsyncOperation asyncOperation) {
            _asyncOperationHandler = new AsyncOperationHandler(asyncOperation);
        }

        public void Cancel() => _asyncOperationHandler.Cancel();
        public async UniTask RunAsync() => await _asyncOperationHandler.RunAsync();
    }
}