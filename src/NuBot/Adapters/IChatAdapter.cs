using System;
using System.Threading;
using System.Threading.Tasks;

namespace NuBot.Adapters
{
    public interface IChatAdapter
    {
        Task RunAsync(CancellationToken cancellationToken);
    }
}
