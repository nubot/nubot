using System;
using System.Threading;

namespace NuBot
{
    public interface IBotHost
    {
        void Run(CancellationToken cancellationToken);
    }
}
