using System.Threading;
using Cysharp.Threading.Tasks;

namespace Scripts.Tools.Interpolation
{
    public interface IAsyncOperation
    {
        UniTask RunAsyncOperation(CancellationTokenSource cts);
    }
}