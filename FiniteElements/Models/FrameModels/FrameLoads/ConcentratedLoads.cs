using Bytes2you.Validation;
using FiniteElements.Models.Contracts;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiniteElements.Models.FrameModels.FrameLoads
{
    internal abstract class ConcentratedLoads : IFrameLoad
    {
        protected ILoadCase loadCase;
        protected double elementLength;
        protected double gCoefficient;
        protected double loadValue;
        protected double loadPosition;

        protected ConcentratedLoads(ILoadCase loadCase, double elementLength, double gCoefficient, double loadValue, double loadPosition)
        {
            Guard.WhenArgument(loadCase, "loadCase").IsNull().Throw();
            Guard.WhenArgument(elementLength, "elementLength").IsNaN().Throw();
            Guard.WhenArgument(gCoefficient, "gCoefficient").IsNaN().Throw();
            Guard.WhenArgument(loadValue, "loadValue").IsNaN().Throw();
            Guard.WhenArgument(loadPosition, "loadPosition").IsNaN().Throw();

            this.loadCase = loadCase;
            this.elementLength = elementLength;
            this.gCoefficient = gCoefficient;
            this.loadValue = loadValue;
            this.loadPosition = loadPosition;
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

        public ILoadCase LoadCase
        {
            get
            {
                return this.loadCase;
            }
        }

        public abstract string Type { get; }

        public abstract Vector<double> GenerateLoad();
    }
}
