using System;
using System.Threading;
using System.Threading.Tasks;
using NuBot.Adapters;

namespace NuBot
{
    internal sealed class Context : IContext
    {
        private readonly IChatAdapter _chatAdapter;

        public Context(IChatAdapter chatAdapter, IMessage message, IParameterCollection parameterCollection)
        {
            _chatAdapter = chatAdapter ?? throw new ArgumentNullException(nameof(chatAdapter));

            Message = message ?? throw new ArgumentNullException(nameof(message));
            Parameters = parameterCollection ?? throw new ArgumentNullException(nameof(parameterCollection));
        }

        public IMessage Message { get; }

        public IParameterCollection Parameters { get; }

        public async Task SendAsync(string message)
        {
            await _chatAdapter.SendAsync(message, CancellationToken.None);
        }
    }
}
