using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NuBot
{
    public interface IListener
    {
        IEnumerable<IParameter> GetParameters(IMessage message);

        bool ShouldHandle(IMessage message);

        Task ExecuteAsync(IContext context);
    }
}
