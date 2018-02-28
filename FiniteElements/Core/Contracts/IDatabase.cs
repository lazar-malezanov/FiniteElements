using FiniteElements.Models.Contracts;
using FiniteElements.Models.Nodes;
using MathNet.Numerics.LinearAlgebra;
using System.Collections.Generic;

namespace FiniteElements.Core.Contracts
{
    internal interface IDatabase
    {
        List<Node> Nodes { get; }

        List<IFrameElement> FrameElements { get; }

        List<IFrameSection> FrameSections { get; }

        List<Matrix<double>> GlobalStiffnessMatrices { get; }

        List<IMaterial> Materials { get; }

        List<ILoadCase> LoadCases { get; }
    }
}
