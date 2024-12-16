using Cysharp.Threading.Tasks;

namespace Scripts.Tools.Interpolation
{
    public interface IAsyncOperationHandler
    {
        UniTask RunAsync();
        void Cancel();
    }
}