using System;
using NuBot.Adapters;

namespace NuBot
{
    internal sealed class DefaultBotBuilder : IBotBuilder
    {
        private IChatAdapter _chatAdapter;

        public DefaultBotBuilder()
        {
        }

        public IBotHost Build()
        {
            return new BotHost();
        }

        public IBotBuilder UseAdapter(IChatAdapter chatAdapter)
        {
            _chatAdapter = chatAdapter ?? throw new ArgumentNullException(nameof(chatAdapter));
            return this;
        }
    }
}
