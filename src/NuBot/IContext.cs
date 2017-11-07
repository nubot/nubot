using System;
using System.Threading.Tasks;

namespace NuBot
{
    public interface IContext
    {
        Task SendAsync(string message);
    }
}
