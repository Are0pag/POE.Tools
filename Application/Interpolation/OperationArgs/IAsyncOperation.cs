using System.Threading;

namespace Scripts.Tools.Interpolation
{
    public interface IAsyncOperation
    {
        CancellationTokenSource CancellationTokenSource { get; set; }
    }
}