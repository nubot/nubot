using System;
using NSubstitute;

namespace NuBot.Tests.Fixtures
{
    public sealed class MessageFixture
    {
        private readonly string _content;

        public MessageFixture(string content)
        {
            _content = content;
        }

        public IMessage Build()
        {
            var msg = Substitute.For<IMessage>();
            msg.Content.Returns(_content);
            return msg;
        }
    }
}
