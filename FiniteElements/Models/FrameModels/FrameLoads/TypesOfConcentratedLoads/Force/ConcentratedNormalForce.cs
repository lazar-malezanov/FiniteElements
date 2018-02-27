using FiniteElements.Models.Contracts;
using MathNet.Numerics.LinearAlgebra;

namespace FiniteElements.Models.FrameModels.FrameLoads.TypesOfConcentratedLoads.Force
{
    internal class ConcentratedNormalForce : ConcentratedLoads
    {
        private readonly string type = "Concentrated Normal Force";

        public ConcentratedNormalForce(ILoadCase loadCase, double elementLength, double gCoefficient,
            double loadValue, double loadPosition) : base(loadCase, elementLength, gCoefficient, loadValue, loadPosition) { }

        public override Vector<double> GenerateLoad()
        {
            double n1 = (-this.loadPosition + this.elementLength) * this.loadValue / this.elementLength;

            double n2 = (this.loadPosition) * this.loadValue / this.elementLength;

            return Vector<double>.Build.SparseOfArray(new double[] { n1, 0.0, 0.0, 0.0, 0.0, 0.0, n2, 0.0, 0.0, 0.0, 0.0, 0.0 });
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
