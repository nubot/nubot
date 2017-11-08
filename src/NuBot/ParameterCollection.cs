using System;

namespace NuBot
{
    internal sealed class ParameterCollection : IParameterCollection
    {
        public ParameterCollection()
        {
        }

        public IParameter this[string key] => throw new NotImplementedException();

        public IParameter this[int index] => throw new NotImplementedException();
    }
}
