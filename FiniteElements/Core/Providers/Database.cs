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
        private readonly List<Node> supports;
        private readonly List<Node> springs;
        private readonly List<IFrameElement> elements;
        private readonly List<IFrameSection> frameSEctions;
        private readonly List<IMaterial> materials;
        private readonly List<ILoadCase> loadCases;
        private readonly List<Matrix<double>> globalStiffnessMatrices;
        private Matrix<double> globalStiffnessMatrix;
        private Dictionary<double, Vector<double>> globalLoadVectors;
        private Dictionary<double, Vector<double>> globalFrameLoadVectors;
        private Dictionary<double, Vector<double>> globalNodeLoadVectors;

        public Database()
        {
            this.nodes = new List<Node>();
            this.supports = new List<Node>();
            this.springs = new List<Node>();
            this.elements = new List<IFrameElement>();
            this.frameSEctions = new List<IFrameSection>();
            this.materials = new List<IMaterial>();
            this.loadCases = new List<ILoadCase>();
            this.globalStiffnessMatrices = new List<Matrix<double>>();
            this.globalLoadVectors = new Dictionary<double, Vector<double>>();
            this.globalFrameLoadVectors = new Dictionary<double, Vector<double>>();
            this.globalNodeLoadVectors = new Dictionary<double, Vector<double>>();
        }

        public List<Node> Nodes
        {
            get
            {
                return this.nodes;
            }
        }

        public List<Node> Supports
        {
            get
            {
                return this.supports;
            }
        }

        public List<Node> Springs
        {
            get
            {
                return this.springs;
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

        public Dictionary<double, Vector<double>> GlobalLoadVectors
        {
            get
            {
                return this.globalLoadVectors;
            }

            set
            {
                this.globalLoadVectors = value;
            }
        }

        public Dictionary<double, Vector<double>> GlobalFrameLoadVectors
        {
            get
            {
                return this.globalFrameLoadVectors;
            }

            set
            {
                this.globalFrameLoadVectors = value;
            }
        }

        public Dictionary<double, Vector<double>> GlobalNodeLoadVectors
        {
            get
            {
                return this.globalNodeLoadVectors;
            }

            set
            {
                this.globalNodeLoadVectors = value;
            }
        }

        public Matrix<double> GlobalStiffnessMatrix
        {
            get
            {
                return this.globalStiffnessMatrix;
            }

            set
            {
                this.globalStiffnessMatrix = value;
            }
        }
    }
}
