using System;
using System.Threading.Tasks;

namespace NuBot
{
    public interface IListener
    {
        bool ShouldHandle(IMessage message);

        Task ExecuteAsync(IContext context);
    }
}
