namespace Scripts.Tools.Interpolation
{
    public interface IAsyncOperationHandlerInitialized : IAsyncOperationHandler
    {
        void Initialize(IAsyncOperation asyncOperation);
    }
}