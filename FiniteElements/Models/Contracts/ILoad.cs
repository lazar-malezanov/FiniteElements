using MathNet.Numerics.LinearAlgebra;

namespace FiniteElements.Models.Contracts
{
    internal interface ILoad
    {
        ILoadCase LoadCase { get; }

        string Type { get; }
    }
}
