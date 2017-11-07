using System;
using System.Threading.Tasks;

namespace NuBot.Tests.Fixtures
{
    public class InMemoryBotFixture
    {
        public static InMemoryBotFixture Hear(string pattern, Func<IContext, Task> callback)
        {
            return new InMemoryBotFixture();
        }

        public Task<string> SendAsync(string messageContent)
        {
            return Task.FromResult(string.Empty);
        }
    }
}
