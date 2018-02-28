using FiniteElements.Core.Contracts;
using System.Collections.Generic;
using FiniteElements.Models.Contracts;
using FiniteElements.Models.Nodes;
using MathNet.Numerics.LinearAlgebra;

namespace FiniteElements.Core
{
    internal class Database : IDatabase
    {
        private readonly List<Node> nodes;
        private readonly List<IFrameElement> elements;
        private readonly List<IFrameSection> frameSEctions;
        private readonly List<IMaterial> materials;
        private readonly List<ILoadCase> loadCases;
        private readonly List<Matrix<double>> globalStiffnessMatrices;

        public Database()
        {
            this.nodes = new List<Node>();
            this.elements = new List<IFrameElement>();
            this.frameSEctions = new List<IFrameSection>();
            this.materials = new List<IMaterial>();
            this.loadCases = new List<ILoadCase>();
            this.globalStiffnessMatrices = new List<Matrix<double>>();
        }

        public List<Node> Nodes
        {
            get
            {
                return this.nodes;
            }
        }

        public List<IFrameElement> FrameElements
        {
            get
            {
                return this.elements;
            }
        }

        public List<IFrameSection> FrameSections
        {
            get
            {
                return this.frameSEctions;
            }
        }

        public List<IMaterial> Materials
        {
            get
            {
                return this.materials; ;
            }
        }

        public List<ILoadCase> LoadCases
        {
            get
            {
                return this.loadCases; ;
            }
        }

        public List<Matrix<double>> GlobalStiffnessMatrices
        {
            get
            {
                return this.globalStiffnessMatrices;
            }
        }
    }
}
