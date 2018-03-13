using Bytes2you.Validation;
using FiniteElements.Models.Contracts;
using FiniteElements.Models.Nodes;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;

namespace FiniteElements.Models.FrameModels.FrameElements
{
    internal class FrameElement : IFrameElement
    {
        private Node node1;
        private Node node2;
        private IMaterial materialProp;
        private IFrameSection sectionProp;
        private List<IFrameLoad> loads;
        private Dictionary<int, Vector<double>> generatedLocalLoadVectors;
        private Dictionary<int, Vector<double>> localInternalForceVectors;
        private Matrix<double> localMatrix;
        private Matrix<double> transformationMatrix;
        private Matrix<double> globalMatrix;
        private int number;
        private double elementLength;
        private double alfa;
        
        private bool torsionReleaseNode1;
        private bool momentAroundYReleaseNode1;
        private bool momentAroundZReleaseNode1;
        private bool normalReleaseNode1;
        private bool shearYReleaseNode1;
        private bool shearZReleaseNode1;

        private bool torsionReleaseNode2;
        private bool momentAroundYReleaseNode2;
        private bool momentAroundZReleaseNode2;
        private bool normalReleaseNode2;
        private bool shearYReleaseNode2;
        private bool shearZReleaseNode2;


        public FrameElement(Node node1, Node node2)
        {
            Guard.WhenArgument(node1, "node1").IsNull().Throw();
            Guard.WhenArgument(node2, "node2").IsNull().Throw();

            this.node1 = node1;
            this.node2 = node2;

            this.loads = new List<IFrameLoad>();
            this.generatedLocalLoadVectors = new Dictionary<int, Vector<double>>();
            this.localInternalForceVectors = new Dictionary<int, Vector<double>>();

            double X1 = node1.XCoord;
            double X2 = node2.XCoord;
            double Y1 = node1.YCoord;
            double Y2 = node2.YCoord;
            double Z1 = node1.ZCoord;
            double Z2 = node2.ZCoord;

            this.elementLength = Math.Sqrt(Math.Pow(X1 - X2, 2) + Math.Pow(Y1 - Y2, 2) + Math.Pow(Z1 - Z2, 2));
            this.alfa = 0;
        }

        public IMaterial MaterialProp
        {
            get
            {
                return this.materialProp;
            }

            set
            {
                Guard.WhenArgument(value, "MaterialProp").IsNull();
                this.materialProp = value;
            }
        }

        public IFrameSection SectionProp
        {
            get
            {
                return this.sectionProp;
            }

            set
            {
                Guard.WhenArgument(value, "SectionProp").IsNull();
                this.sectionProp = value;
            }
        }

        public List<IFrameLoad> Loads
        {
            get
            {
                return this.loads;
            } 
        }

        public Dictionary<int, Vector<double>> GeneratedLocalLoadVectors
        {
            get
            {
                return this.generatedLocalLoadVectors;
            }

            set
            {
                this.generatedLocalLoadVectors = value;
            }
        }

        public Dictionary<int, Vector<double>> LocalInternalForceVectors
        {
            get
            {
                return this.localInternalForceVectors;
            }

            set
            {
                this.localInternalForceVectors = value;
            }
        }

        public int Number
        {
            get
            {
                return this.number;
            }

            set
            {
                this.number = value;
            }
        }

        public Node Node1
        {
            get
            {
                return this.node1;
            }
        }

        public Node Node2
        {
            get
            {
                return this.node2;
            }
        }

        public double Alfa
        {
            get
            {
                return this.alfa;
            }
        }

        public double ElementLength
        {
            get
            {
                return this.elementLength;
            }
        }      

        public Matrix<double> LocalMatrix
        {
            get
            {
                return this.localMatrix;
            }

            set
            {
                this.localMatrix = value;
            }
        }

        public Matrix<double> TransformationMatrix
        {
            get
            {
                return this.transformationMatrix;
            }

            set
            {
                this.transformationMatrix = value;
            }
        }

        public Matrix<double> GlobalMatrix
        {
            get
            {
                return this.globalMatrix;
            }

            set
            {
                this.globalMatrix = value;
            }
        }

        public bool TorsionReleaseNode1
        {
            get
            {
                return this.torsionReleaseNode1;
            }
            
            set
            {
                this.torsionReleaseNode1 = value;
            }
        }

        public bool MomentAroundYReleaseNode1
        {
            get
            {
                return this.momentAroundYReleaseNode1;
            }

            set
            {
                this.momentAroundYReleaseNode1 = value;
            }
        }

        public bool MomentAroundZReleaseNode1
        {
            get
            {
                return this.momentAroundZReleaseNode1;
            }

            set
            {
                this.momentAroundZReleaseNode1 = value;
            }
        }

        public bool NormalReleaseNode1
        {
            get
            {
                return this.normalReleaseNode1;
            }

            set
            {
                this.normalReleaseNode1 = value;
            }
        }

        public bool ShearYReleaseNode1
        {
            get
            {
                return this.shearYReleaseNode1;
            }

            set
            {
                this.shearYReleaseNode1 = value;
            }
        }

        public bool ShearZReleaseNode1
        {
            get
            {
                return this.shearZReleaseNode1;
            }

            set
            {
                this.shearZReleaseNode1 = value;
            }
        }

        public bool TorsionReleaseNode2
        {
            get
            {
                return this.torsionReleaseNode2;
            }

            set
            {
                this.torsionReleaseNode2 = value;
            }
        }

        public bool MomentAroundYReleaseNode2
        {
            get
            {
                return this.momentAroundYReleaseNode2;
            }

            set
            {
                this.momentAroundYReleaseNode2 = value;
            }
        }

        public bool MomentAroundZReleaseNode2
        {
            get
            {
                return this.momentAroundZReleaseNode2;
            }

            set
            {
                this.momentAroundZReleaseNode2 = value;
            }
        }

        public bool NormalReleaseNode2
        {
            get
            {
                return this.normalReleaseNode2;
            }

            set
            {
                this.normalReleaseNode2 = value;
            }
        }

        public bool ShearYReleaseNode2
        {
            get
            {
                return this.shearYReleaseNode2;
            }

            set
            {
                this.shearYReleaseNode2 = value;
            }
        }

        public bool ShearZReleaseNode2
        {
            get
            {
                return this.shearZReleaseNode2;
            }

            set
            {
                this.shearZReleaseNode2 = value;
            }
        }
    }
}
