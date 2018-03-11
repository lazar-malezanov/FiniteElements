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

        List<Matrix<double>> GlobalStiffnessMatrices { get; } //From different elements

        Matrix<double> GlobalNodeStiffnessMatrix { get; set; }

        Matrix<double> GlobalStiffnessMatrix { get; set; }

        Matrix<double> GlobalStiffnessMatrixWithSupports { get; set; }

        Dictionary<int, Vector<double>> GlobalLoadVectors { get; set; }

        Dictionary<int, Vector<double>> GlobalFrameLoadVectors { get; set; }

        Dictionary<int, Vector<double>> GlobalNodeLoadVectors { get; set; }

        Dictionary<int, Vector<double>> ResultNodalDisplacementVectors { get; set; }

        Dictionary<int, Vector<double>> ResultNodalReactionVectors { get; set; }

        Dictionary<int, Vector<double>> ResultInternalForceVectors { get; set; }

        List<IMaterial> Materials { get; }

        List<ILoadCase> LoadCases { get; }
    }
}
