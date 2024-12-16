namespace Scripts.Tools.AsyncOperationsHandle
{
    public interface IAsyncOperationHandlerInitialized : IAsyncOperationHandler
    {
        void Initialize(IAsyncOperation asyncOperation);
    }
}