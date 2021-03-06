using System;
using NuBot.Adapters;

namespace NuBot
{
    internal sealed class BotBuilder : IBotBuilder
    {
        private IChatAdapter _chatAdapter;

        internal BotBuilder()
        {
        }

        public IBotHost Build()
        {
            var bot = new Bot(_chatAdapter);
            return new BotHost(bot);
        }

        public IBotBuilder UseAdapter(IChatAdapter chatAdapter)
        {
            _chatAdapter = chatAdapter ?? throw new ArgumentNullException(nameof(chatAdapter));
            return this;
        }
    }
}
