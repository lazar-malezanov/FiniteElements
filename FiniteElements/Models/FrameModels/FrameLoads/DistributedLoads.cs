using Bytes2you.Validation;
using FiniteElements.Models.Contracts;
using MathNet.Numerics.LinearAlgebra;

namespace FiniteElements.Models.FrameModels.FrameLoads
{
    internal abstract class DistributedLoads : IFrameLoad
    {
        protected ILoadCase loadCase;
        protected double elementLength;
        protected double gCoefficient;
        protected double loadAtStart;
        protected double loadAtEnd;
        protected double loadStartsAt;
        protected double loadEndsAt;

        protected DistributedLoads(ILoadCase loadCase, double elementLength, double gCoefficient, double loadAtStart, double loadAtEnd, double loadStartsAt, double loadEndsAt)
        {
            Guard.WhenArgument(loadCase, "loadCase").IsNull().Throw();
            Guard.WhenArgument(elementLength, "elementLength").IsNaN().Throw();
            Guard.WhenArgument(gCoefficient, "gCoefficient").IsNaN().Throw();
            Guard.WhenArgument(loadAtStart, "loadAtStart").IsNaN().Throw();
            Guard.WhenArgument(loadAtEnd, "loadAtEnd").IsNaN().Throw();
            Guard.WhenArgument(loadStartsAt, "loadStartsAt").IsNaN().Throw();
            Guard.WhenArgument(loadEndsAt, "loadEndsAt").IsNaN().Throw();

            this.loadCase = loadCase;
            this.elementLength = elementLength;
            this.gCoefficient = gCoefficient;
            this.loadAtStart = loadAtStart;
            this.loadAtEnd = loadAtEnd;
            this.loadStartsAt = loadStartsAt;
            this.loadEndsAt = loadEndsAt;
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
