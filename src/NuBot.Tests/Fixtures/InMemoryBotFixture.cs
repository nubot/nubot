using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NuBot.Adapters;

namespace NuBot.Tests.Fixtures
{
    public class InMemoryBotFixture
    {
        public class TestMessage : IMessage
        {
            public TestMessage(string content)
            {
                Content = content;
            }
            public string Content { get; }
        }

        public class TestAdapter : IChatAdapter
        {
            private readonly StringBuilder _builder;

            public event AsyncEventHandler<MessageEventArgs> MessageReceived;

            public TestAdapter(StringBuilder builder)
            {
                _builder = builder;
            }

            public Task RunAsync(CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public async Task RaiseMessageReceivedAsync(string message)
            {
                if (MessageReceived != null)
                {
                    await MessageReceived(this, new MessageEventArgs(new TestMessage(message)));
                }
            }

            public Task SendAsync(string content, CancellationToken cancellationToken)
            {
                _builder.Append(content);
                return Task.CompletedTask;
            }
        }

        private readonly IBot _bot;

        private readonly TestAdapter _chatAdapter;

        private readonly StringBuilder _builder;

        public InMemoryBotFixture(IBot bot, TestAdapter chatAdapter, StringBuilder builder)
        {
            _bot = bot ?? throw new ArgumentNullException(nameof(bot));
            _chatAdapter = chatAdapter ?? throw new ArgumentNullException(nameof(chatAdapter));
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public static InMemoryBotFixture Hear(string pattern, Func<IContext, Task> callback)
        {
            var builder = new StringBuilder();
            var adapter = new TestAdapter(builder);
            var bot = new DefaultBot(adapter);
            bot.Hear(pattern, callback);

            return new InMemoryBotFixture(bot, adapter, builder);
        }

        public async Task<string> SendAsync(string messageContent)
        {
            await _chatAdapter.RaiseMessageReceivedAsync(messageContent);

            return _builder.ToString();
        }
    }
}
