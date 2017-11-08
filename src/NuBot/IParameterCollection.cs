using System;

namespace NuBot
{
    public interface IParameterCollection
    {
        IParameter this[string key] { get; }
        IParameter this[int index] { get; }
    }
}
