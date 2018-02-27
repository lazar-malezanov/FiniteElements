using FiniteElements.Models.Contracts;
using MathNet.Numerics.LinearAlgebra;

namespace FiniteElements.Models.FrameModels.FrameLoads.TypesOfConcentratedLoads.Moment
{
    internal class ConcentratedTorsion : ConcentratedLoads
    {
        private readonly string type = "Concentrated Torsion (around element's X axis)";

        public ConcentratedTorsion(ILoadCase loadCase, double elementLength, double gCoefficient,
            double loadValue, double loadPosition) : base(loadCase, elementLength, gCoefficient, loadValue, loadPosition) { }

        public override Vector<double> GenerateLoad()
        {
            double t1 = (-this.loadPosition + this.elementLength) * this.loadValue / this.elementLength;

            double t2 = (this.loadPosition) * this.loadValue / this.elementLength;

            return Vector<double>.Build.SparseOfArray(new double[] { 0.0, 0.0, 0.0, t1, 0.0, 0.0, 0.0, 0.0, 0.0, t2, 0.0, 0.0 });
        }

        public override string Type
        {
            get
            {
                return this.type;
            }
        }
    }
}
