using System;
using System.Collections.Generic;
using System.Linq;

namespace NuBot
{
    internal sealed class ParameterCollection : IParameterCollection
    {
        private readonly IList<IParameter> _parameters;

        public ParameterCollection(IEnumerable<IParameter> parameters)
        {
            _parameters = new List<IParameter>(parameters);
        }

        public IParameter this[string key] => _parameters.SingleOrDefault(p => p.Name == key);

        public IParameter this[int index] => _parameters[index];
    }
}
