using FiniteElements.Models.Contracts;
using FiniteElements.Models.Nodes;
using MathNet.Numerics.LinearAlgebra;
using System.Collections.Generic;

namespace FiniteElements.Core.Contracts
{
    internal interface IDatabase
    {
        List<Node> Nodes { get; }

        List<Node> Supports { get; }

        List<Node> Springs { get; }

        List<IFrameElement> FrameElements { get; }

        List<IFrameSection> FrameSections { get; }

        List<Matrix<double>> GlobalStiffnessMatrices { get; }

        Matrix<double> GlobalStiffnessMatrix { get; set; }

        Dictionary<double, Vector<double>> GlobalLoadVectors { get; set; }

        Dictionary<double, Vector<double>> GlobalFrameLoadVectors { get; set; }

        Dictionary<double, Vector<double>> GlobalNodeLoadVectors { get; set; }

        List<IMaterial> Materials { get; }

        List<ILoadCase> LoadCases { get; }
    }
}
