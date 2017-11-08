using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NuBot.Adapters;

namespace NuBot
{
    internal sealed class Bot : IBot
    {
        private readonly IChatAdapter _chatAdapter;
        private readonly IList<IListener> _listeners;

        public Bot(IChatAdapter chatAdapter)
        {
            _chatAdapter = chatAdapter ?? throw new ArgumentNullException(nameof(chatAdapter));
            _chatAdapter.MessageReceived += OnMessageReceived;
            _listeners = new List<IListener>();
        }

        public void Hear(string pattern, Func<IContext, Task> callback)
        {
            _listeners.Add(new TextListener(pattern, callback));
        }

        public void Respond(string pattern, Func<IContext, Task> callback)
        {
            var mentionPattern = $"^[@]?{_chatAdapter.Name}\\s{pattern}";
            _listeners.Add(new TextListener(mentionPattern, callback));
        }

        private async Task OnMessageReceived(object sender, MessageEventArgs args)
        {
            var listeners = (from l in _listeners
                             where l.ShouldHandle(args.Message)
                             select l);

            foreach (var listener in listeners)
            {
                var parameters = listener.GetParameters(args.Message);

                var ctx = new Context(
                    _chatAdapter,
                    args.Message,
                    new ParameterCollection(parameters));

                await listener.ExecuteAsync(ctx);
            }
        }
    }
}
