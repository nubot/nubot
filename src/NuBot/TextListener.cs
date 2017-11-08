using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NuBot
{
    internal sealed class TextListener : IListener
    {
        private readonly string _pattern;
        private readonly Func<IContext, Task> _callback;

        public TextListener(string pattern, Func<IContext, Task> callback)
        {
            _pattern = pattern ?? throw new ArgumentNullException(nameof(pattern));
            _callback = callback ?? throw new ArgumentNullException(nameof(callback));
        }

        public async Task ExecuteAsync(IContext context)
        {
            await _callback(context);
        }

        public bool ShouldHandle(IMessage message)
        {
            return Regex.IsMatch(message.Content, _pattern);
        }
    }
}
