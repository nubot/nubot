using System;

namespace NuBot.Adapters
{
    public class MessageEventArgs : EventArgs
    {
        private readonly IMessage _message;

        public MessageEventArgs(IMessage message)
        {
            _message = message ?? throw new ArgumentNullException(nameof(message));
        }

        public IMessage Message => _message;
    }
}
