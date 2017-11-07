using System;
using NuBot.Adapters;

namespace NuBot
{
    public interface IBotBuilder
    {
        IBotHost Build();

        IBotBuilder UseAdapter(IChatAdapter chatAdapter);
    }
}
