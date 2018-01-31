using Bytes2you.Validation;
using FiniteElements.Models.Contracts;
using FiniteElements.Models.Nodes;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
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
        private List<ILoad> loads;
        private Matrix<double> localMatrix;
        private double number;
        private double elementLength;
        private double alfa;

        public FrameElement(Node node1, Node node2)
        {
            Guard.WhenArgument(node1, "node1").IsNull().Throw();
            Guard.WhenArgument(node2, "node2").IsNull().Throw();

            this.node1 = node1;
            this.node2 = node2;

            this.loads = new List<ILoad>();

            double X1 = node1.XCoord;
            double X2 = node2.XCoord;
            double Y1 = node1.YCoord;
            double Y2 = node2.YCoord;
            this.elementLength = Math.Sqrt(Math.Pow(X1 - X2, 2) + Math.Pow(Y1 - Y2, 2));
            this.alfa = Math.Atan2(X2 - X1, Y2 - Y1);
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

        public List<ILoad> Loads
        {
            get
            {
                return this.loads;
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

        public double Number
        {
            get
            {
                return this.number;
            }

            set
            {
                Guard.WhenArgument(value, "number").IsNaN();
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

             
    }
}
