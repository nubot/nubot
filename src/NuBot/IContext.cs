using System;
using System.Threading.Tasks;

namespace NuBot
{
    public interface IContext
    {
        IMessage Message { get; }

        IParameterCollection Parameters { get; }

        Task SendAsync(string message);
    }
}
