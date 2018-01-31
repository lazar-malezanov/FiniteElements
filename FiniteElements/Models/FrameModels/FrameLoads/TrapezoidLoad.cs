using Bytes2you.Validation;
using FiniteElements.Models.Contracts;
using MathNet.Numerics.LinearAlgebra;
using System.Collections.Generic;

namespace FiniteElements.Models.FrameModels.FrameLoads
{
    internal class TrapezoidLoad : IFrameLoad
    {
        private double intensityAtNode1;
        private double intensityAtNode2;
        private string type = "Trapezoid Load";     
        private double loadCaseNumber;
        private ILoadCase loadCase;
        private Vector<double> localVector;
        private double elementLength;

        public TrapezoidLoad(double intensityAtNode1, double intensityAtNode2, double elementLength)
        {
            Guard.WhenArgument(intensityAtNode1, "intensityAtNode1").IsNaN().Throw();  
            Guard.WhenArgument(intensityAtNode2, "intensityAtNode2").IsNaN().Throw();
            Guard.WhenArgument(elementLength, "elementLength").IsNaN().Throw();
            Guard.WhenArgument(elementLength, "elementLength").IsLessThan(0.0).Throw();

            this.IntensityAtNode1 = intensityAtNode1;
            this.IntensityAtNode2 = intensityAtNode2;
            this.elementLength = elementLength;

            //this.localVector = CreateLocalLoadVector(intensityAtNode1, intensityAtNode2, elementLength);           
        }

        public double IntensityAtNode1
        {
            get
            {
                return this.intensityAtNode1;
            }

            set
            {
                Guard.WhenArgument(value, "intensityAtNode1").IsNaN().Throw();      
                this.intensityAtNode1 = value;  
            }
        }

        public double IntensityAtNode2
        {
            get
            {
                return this.intensityAtNode2;
            }

            set
            {
                Guard.WhenArgument(value, "intensityAtNode2").IsNaN().Throw();         
                this.intensityAtNode2 = value;         
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

        //private Vector<double> CreateLocalLoadVector(double intensityAtNode1, double intensityAtNode2, double elementLength)
        //{
        //    //TODO change the vector!!!
        //    Vector<double> loadVector = Vector<double>.Build.DenseOfArray(new double[]
        //    {
        //        0, 0.5 * intensity * elementLength, intensity * elementLength * elementLength / 12.0, 0, 0.5 * intensity * elementLength, (-1) * intensity * elementLength * elementLength / 12.0
        //    });

        //    return loadVector;
        //}
    }
}
