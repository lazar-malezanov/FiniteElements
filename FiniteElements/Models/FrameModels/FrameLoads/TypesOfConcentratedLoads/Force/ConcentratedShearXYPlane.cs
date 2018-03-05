using FiniteElements.Models.Contracts;
using MathNet.Numerics.LinearAlgebra;
using System;

namespace FiniteElements.Models.FrameModels.FrameLoads.TypesOfConcentratedLoads.Force
{
    internal class ConcentratedShearXYPlane : ConcentratedLoads
    {
        private readonly string type = "Concentrated Shear Force XY Plane";

        public ConcentratedShearXYPlane(ILoadCase loadCase, double elementLength, double gCoefficient, 
            double loadValue, double loadPosition) : base(loadCase, elementLength, gCoefficient, loadValue, loadPosition) { }

        public override Vector<double> GenerateLoad()
        {
            double q1 = (2.0 * Math.Pow(this.loadPosition, 3.0) - 3.0 * Math.Pow(this.elementLength, 1.0) * Math.Pow(this.loadPosition, 2.0) - 12.0 * this.gCoefficient * Math.Pow(this.loadPosition, 1.0) 
                + Math.Pow(this.elementLength, 1.0) * (Math.Pow(this.elementLength, 2.0) + 12.0 * this.gCoefficient)) 
                * this.loadValue / (Math.Pow(this.elementLength, 1.0) * (Math.Pow(this.elementLength, 2.0) + 12.0 * this.gCoefficient));

            double q2 = (- 2.0 * Math.Pow(this.loadPosition, 3.0) + 3.0 * Math.Pow(this.elementLength, 1.0) * Math.Pow(this.loadPosition, 2.0) + 12.0 * this.gCoefficient * Math.Pow(this.loadPosition, 1.0))
                * this.loadValue / (Math.Pow(this.elementLength, 1.0) * (Math.Pow(this.elementLength, 2.0) + 12.0 * this.gCoefficient)); 
            
            double m1 = (Math.Pow(this.elementLength, 1.0) * Math.Pow(this.loadPosition, 3.0) - (2.0 * Math.Pow(this.elementLength, 2.0) + 6.0 * this.gCoefficient) * Math.Pow(this.loadPosition, 2.0) 
                + ((Math.Pow(this.elementLength, 3.0) + 6.0 * this.gCoefficient * (Math.Pow(this.elementLength, 1.0))) * Math.Pow(this.loadPosition, 1.0))) 
                * this.loadValue / (Math.Pow(this.elementLength, 1.0) * (Math.Pow(this.elementLength, 2.0) + 12.0 * this.gCoefficient));

            double m2 = (Math.Pow(this.elementLength, 1.0) * Math.Pow(this.loadPosition, 3.0) + (- Math.Pow(this.elementLength, 2.0) + 6.0 * this.gCoefficient) * Math.Pow(this.loadPosition, 2.0)
                - (6.0 * this.gCoefficient * (Math.Pow(this.elementLength, 1.0)) * Math.Pow(this.loadPosition, 1.0)))
                * this.loadValue / (Math.Pow(this.elementLength, 1.0) * (Math.Pow(this.elementLength, 2.0) + 12.0 * this.gCoefficient));

            return Vector<double>.Build.SparseOfArray(new double[] { 0.0, q1, 0.0, 0.0, 0.0, m1, 0.0, q2, 0.0, 0.0, 0.0, m2 });
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
