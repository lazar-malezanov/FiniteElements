﻿using FiniteElements.Models.Contracts;
using MathNet.Numerics.LinearAlgebra;

namespace FiniteElements.Models.Nodes.NodeLoads.Moment
{
    internal class MomentAroundX : NodalMoments
    {
        private readonly string type = "Nodal Moment around global X axis";

        public MomentAroundX(ILoadCase loadCase, double loadValue) : base(loadCase, loadValue) { }

        public override Vector<double> GenerateLoad()
        {
            return Vector<double>.Build.SparseOfArray(new double[] { 0.0, 0.0, 0.0, this.loadValue, 0.0, 0.0 });
        }

        public override string Type
        {
            get
            {
                return this.type;
            }
        }

        public override ILoadCase LoadCase
        {
            get
            {
                return this.loadCase;
            }
        }
    }
}
