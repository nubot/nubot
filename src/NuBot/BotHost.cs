using System;
using System.Threading;
using System.Threading.Tasks;

namespace NuBot
{
    internal sealed class BotHost : IBotHost
    {
        public static IBotBuilder CreateDefaultBuilder(string[] args)
        {
            return new BotBuilder();
        }

        private readonly IBotController _bot;

        public BotHost(IBotController bot)
        {
            _bot = bot ?? throw new ArgumentNullException(nameof(bot));
        }

        public void Run(CancellationToken cancellationToken)
        {
            Task.WaitAll(_bot.ChatAdapter.RunAsync(cancellationToken));
        }
    }
}
