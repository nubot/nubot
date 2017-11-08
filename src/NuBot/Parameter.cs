using System;

namespace NuBot
{
    internal sealed class Parameter : IParameter
    {
        public Parameter(string name, string value)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Name { get; }

        public string Value { get; }

        public override string ToString()
        {
            return Value;
        }
    }
}
