using System;
using System.Threading;
using System.Threading.Tasks;

namespace NuBot.Adapters.Console
{
    public sealed class ConsoleAdapter : IChatAdapter
    {
        public Task RunAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}
