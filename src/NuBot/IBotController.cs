using System;
using NuBot.Adapters;

namespace NuBot
{
    internal interface IBotController : IBot
    {
        IChatAdapter ChatAdapter { get; }
    }
}
