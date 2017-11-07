using System;
using System.Threading.Tasks;

namespace NuBot
{
    public interface IBot
    {
        void Hear(string pattern, Func<IContext, Task> callback);
    }
}
