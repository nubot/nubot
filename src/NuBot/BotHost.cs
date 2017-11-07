using System;

namespace NuBot
{
    public class BotHost : IBotHost
    {
        public static IBotBuilder CreateDefaultBuilder(string[] args)
        {
            return new DefaultBotBuilder();
        }

        public void Run()
        {
        }
    }
}
