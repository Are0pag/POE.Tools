namespace Scripts.Tools.AsyncOperationsHandle
{
    public class AsyncOperationHandlerReverse : AsyncOperationHandler
    {
        public AsyncOperationHandlerReverse(IAsyncOperationReverse asyncOperation) 
            : base(asyncOperation) {
        }

        public void Reverse() {
            ((IAsyncOperationReverse)_asyncOperation).Reverse();
        }
    }
}