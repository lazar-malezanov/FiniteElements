using Bytes2you.Validation;
using FiniteElements.Models.Contracts;
using MathNet.Numerics.LinearAlgebra;
using System.Collections.Generic;

namespace FiniteElements.Models.FrameModels.FrameLoads
{
    internal class LinearlyDistributedLoad : IFrameLoad
    {
        private double intensity;
        private string type = "Linearly Distributed"; 
        private double loadCaseNumber;
        private ILoadCase loadCase;
        private Vector<double> localVector;
        private double elementLength;

        public LinearlyDistributedLoad(double intensity, double elementLength)
        {
            Guard.WhenArgument(intensity, "intensity").IsNaN().Throw();
            Guard.WhenArgument(elementLength, "elementLength").IsNaN().Throw();
            Guard.WhenArgument(elementLength, "elementLength").IsLessThan(0.0).Throw();

            this.Intensity = intensity;
            this.elementLength = elementLength;

            this.localVector = CreateLocalLoadVector(intensity, elementLength); 
        }

        public double Intensity
        {
            get
            {
                return this.intensity;
            }

            set
            {
                Guard.WhenArgument(value, "intensity").IsNaN().Throw();
                this.intensity = value;           
            }
        }                

        public double LoadCaseNumber
        {
            get
            {
                return this.loadCaseNumber;
            }

            set
            {
                Guard.WhenArgument(value, "loadCaseId").IsNaN().Throw();
                Guard.WhenArgument(value, "loadCaseId").IsLessThan(0.0).Throw();
                this.loadCaseNumber = value;
            }
        }

        public ILoadCase LoadCase
        {
            get
            {
                return this.loadCase;
            }

            set
            {
                Guard.WhenArgument(value, "loadCase").IsNull().Throw();
                this.loadCase = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }             
        } 
        
        public Vector<double> LocalVector
        {
            get
            {
                return this.localVector;
            }
        }

        public double ElementLength
        {
            get
            {
                return this.elementLength;
            }

            set
            {
                Guard.WhenArgument(value, "elementLength").IsNaN().Throw();
                Guard.WhenArgument(value, "elementLength").IsLessThan(0.0).Throw();

                this.elementLength = value;
            }
        }

        private Vector<double> CreateLocalLoadVector(double intensity, double elementLength)
        {
            Vector<double> loadVector = Vector<double>.Build.DenseOfArray(new double[] 
            {
                0, 0.5 * intensity * elementLength, intensity * elementLength * elementLength / 12.0, 0, 0.5 * intensity * elementLength, (-1) * intensity * elementLength * elementLength / 12.0
            });

            return loadVector;
        }
    }
}
