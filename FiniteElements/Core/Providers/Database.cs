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
        private Matrix<double> globalNodeStiffnessMatrix;
        private Matrix<double> globalStiffnessMatrix;
        private Matrix<double> globalStiffnessMatrixWithSupports;
        private Dictionary<int, Vector<double>> globalLoadVectors;
        private Dictionary<int, Vector<double>> globalFrameLoadVectors;
        private Dictionary<int, Vector<double>> globalNodeLoadVectors;
        private Dictionary<int, Vector<double>> resultNodalDisplacementVectors;
        private Dictionary<int, Vector<double>> resultNodalReactionVectors;
        private Dictionary<int, Vector<double>> resultInternalForceVectors;

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
            this.globalLoadVectors = new Dictionary<int, Vector<double>>();
            this.globalFrameLoadVectors = new Dictionary<int, Vector<double>>();
            this.globalNodeLoadVectors = new Dictionary<int, Vector<double>>();
            this.resultNodalDisplacementVectors = new Dictionary<int, Vector<double>>();
            this.resultNodalReactionVectors = new Dictionary<int, Vector<double>>();
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

        public Dictionary<int, Vector<double>> GlobalLoadVectors
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

        public Dictionary<int, Vector<double>> GlobalFrameLoadVectors
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

        public Dictionary<int, Vector<double>> GlobalNodeLoadVectors
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

        public Matrix<double> GlobalNodeStiffnessMatrix
        {
            get
            {
                return this.globalNodeStiffnessMatrix;
            }

            set
            {
                this.globalNodeStiffnessMatrix = value;
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

        public Matrix<double> GlobalStiffnessMatrixWithSupports
        {
            get
            {
                return this.globalStiffnessMatrixWithSupports;
            }

            set
            {
                this.globalStiffnessMatrixWithSupports = value;
            }
        }

        public Dictionary<int, Vector<double>> ResultNodalDisplacementVectors
        {
            get
            {
                return this.resultNodalDisplacementVectors;
            }

            set
            {
                this.resultNodalDisplacementVectors = value;
            }
        }

        public Dictionary<int, Vector<double>> ResultNodalReactionVectors
        {
            get
            {
                return this.resultNodalReactionVectors;
            }

            set
            {
                this.resultNodalReactionVectors = value;
            }
        }

        public Dictionary<int, Vector<double>> ResultInternalForceVectors
        {
            get
            {
                return this.resultInternalForceVectors;
            }

            set
            {
                this.resultInternalForceVectors = value;
            }
        }
    }
}
