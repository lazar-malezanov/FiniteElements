using MathNet.Numerics.LinearAlgebra;

namespace FiniteElements.Models.Contracts
{
    internal interface INodalLoad : ILoad
    {
        double LoadValue { get; }

        Vector<double> GenerateLoad();
    }
}
