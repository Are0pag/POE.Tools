namespace Scripts.Tools.AsyncOperationsHandle
{
    public interface IAsyncOperationHandlerInitialized : IAsyncOperationHandler
    {
        void Initialize(IAsyncOperation asyncOperation);
        
        void Initialize(AsyncOperationHandler asyncOperationHandler);
    }
}