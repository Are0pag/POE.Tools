using System.Threading;
using Cysharp.Threading.Tasks;

namespace Scripts.Tools.AsyncOperationsHandle
{
    public interface IAsyncOperation
    {
        UniTask RunAsyncOperation(CancellationTokenSource cts);
    }
}