using Bytes2you.Validation;
using FiniteElements.Models.Contracts;
using MathNet.Numerics.LinearAlgebra;

namespace FiniteElements.Models.Nodes.NodeLoads
{
    internal abstract class NodalForces : ILoad
    {
        protected readonly ILoadCase loadCase;
        protected readonly double loadValue;

        protected NodalForces(ILoadCase loadCase, double loadValue)
        {
            Guard.WhenArgument(loadCase, "loadCase").IsNull().Throw();

            this.loadCase = loadCase;
            this.loadValue = loadValue;
        }

        public abstract Vector<double> GenerateLoad();

        public abstract string Type { get; }

        public abstract ILoadCase LoadCase { get; }        
    }
}
