using System;
using System.Threading;
using System.Threading.Tasks;

namespace NuBot.Adapters
{
    public delegate Task AsyncEventHandler<T>(object sender, T args);

    public interface IChatAdapter
    {
        event AsyncEventHandler<MessageEventArgs> MessageReceived;

        string Name { get; }

        Task RunAsync(CancellationToken cancellationToken);

        Task SendAsync(string content, CancellationToken cancellationToken);
    }
}
