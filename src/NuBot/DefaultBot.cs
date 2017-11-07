using System;
using System.Threading.Tasks;

namespace NuBot
{
    internal sealed class DefaultBot : IBot
    {
        public void Hear(string pattern, Func<IContext, Task> callback)
        {
            throw new NotImplementedException();
        }
    }
}
