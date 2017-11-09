using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NuBot
{
    internal sealed class TextListener : IListener
    {
        private readonly Regex _regex;
        private readonly Func<IContext, Task> _callback;

        public TextListener(string pattern, Func<IContext, Task> callback)
        {
            _regex = new Regex(
                pattern ?? throw new ArgumentNullException(nameof(pattern)),
                RegexOptions.IgnoreCase);

            _callback = callback ?? throw new ArgumentNullException(nameof(callback));
        }

        public async Task ExecuteAsync(IContext context)
        {
            await _callback(context);
        }

        public IEnumerable<IParameter> GetParameters(IMessage message)
        {
            const string WholeMatchGroup = "0";

            var result = new List<IParameter>();

            var groupNames = _regex.GetGroupNames();
            var match = _regex.Match(message.Content);

            foreach (var name in groupNames.Where(gn => gn != WholeMatchGroup))
            {
                var value = match.Groups[name].Value;
                result.Add(new Parameter(name, value));
            }

            return result;
        }

        public bool ShouldHandle(IMessage message)
        {
            return _regex.IsMatch(message.Content);
        }
    }
}
