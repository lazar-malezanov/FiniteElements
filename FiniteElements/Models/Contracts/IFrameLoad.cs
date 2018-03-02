using MathNet.Numerics.LinearAlgebra;

namespace FiniteElements.Models.Contracts
{
    internal interface IFrameLoad : ILoad
    {        
        double ElementLength { get; set; }

        Vector<double> GenerateLoad();
    }
}
