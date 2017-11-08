using System;

namespace NuBot
{
    public interface IParameter
    {
        string Name { get; }

        string ToString();
    }
}
