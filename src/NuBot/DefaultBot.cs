using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NuBot.Adapters;

namespace NuBot
{
    internal sealed class DefaultBot : IBot
    {
        private readonly IChatAdapter _chatAdapter;
        private readonly IList<IListener> _listeners;

        public DefaultBot(IChatAdapter chatAdapter)
        {
            _chatAdapter = chatAdapter ?? throw new ArgumentNullException(nameof(chatAdapter));
            _chatAdapter.MessageReceived += OnMessageReceived;
            _listeners = new List<IListener>();
        }

        public void Hear(string pattern, Func<IContext, Task> callback)
        {
            _listeners.Add(new TextListener(pattern, callback));
        }

        private async Task OnMessageReceived(object sender, MessageEventArgs args)
        {
            var listeners = (from l in _listeners
                             where l.ShouldHandle(args.Message)
                             select l);

            foreach (var listener in listeners)
            {
                var parameters = new ParameterCollection();
                var ctx = new Context(_chatAdapter, args.Message, parameters);

                await listener.ExecuteAsync(ctx);
            }
        }
    }
}
