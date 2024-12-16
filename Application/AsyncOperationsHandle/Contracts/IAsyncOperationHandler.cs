using Cysharp.Threading.Tasks;

namespace Scripts.Tools.AsyncOperationsHandle
{
    public interface IAsyncOperationHandler
    {
        UniTask RunAsync();
        void Cancel();
    }
}