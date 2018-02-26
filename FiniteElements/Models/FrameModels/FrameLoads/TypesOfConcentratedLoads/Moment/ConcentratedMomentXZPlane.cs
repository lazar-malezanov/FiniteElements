using FiniteElements.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiniteElements.Models.FrameModels.FrameLoads.TypesOfConcentratedLoads.Moment
{
    internal class ConcentratedMomentXZPlane : ConcentratedLoads
    {
        private readonly string type = "Concentrated Moment XZ Plane (around element's Y axis)";

        public ConcentratedMomentXZPlane(ILoadCase loadCase, double elementLength, double gCoefficient,
            double loadValue, double loadPosition) : base(loadCase, elementLength, gCoefficient, loadValue, loadPosition) { }

        public override List<double> GenerateLoad()
        {
            double q1 = (6.0 * Math.Pow(this.loadPosition, 2.0) - 6.0 * Math.Pow(this.elementLength, 1.0) * Math.Pow(this.loadPosition, 1.0) - 12.0 * this.gCoefficient)
                * this.loadValue / (Math.Pow(this.elementLength, 1.0) * (Math.Pow(this.elementLength, 2.0) + 12.0 * this.gCoefficient));

            double q2 = (-6.0 * Math.Pow(this.loadPosition, 2.0) + 6.0 * Math.Pow(this.elementLength, 1.0) * Math.Pow(this.loadPosition, 1.0) + 12.0 * this.gCoefficient)
                * this.loadValue / (Math.Pow(this.elementLength, 1.0) * (Math.Pow(this.elementLength, 2.0) + 12.0 * this.gCoefficient));

            double m1 = (3.0 * Math.Pow(this.elementLength, 1.0) * Math.Pow(this.loadPosition, 2.0) - 2.0 * (2.0 * Math.Pow(this.elementLength, 2.0) + 6.0 * this.gCoefficient) * Math.Pow(this.loadPosition, 1.0)
                + (Math.Pow(this.elementLength, 3.0) + 6.0 * this.gCoefficient * (Math.Pow(this.elementLength, 1.0))))
                * this.loadValue / (Math.Pow(this.elementLength, 1.0) * (Math.Pow(this.elementLength, 2.0) + 12.0 * this.gCoefficient));

            double m2 = (3.0 * Math.Pow(this.elementLength, 1.0) * Math.Pow(this.loadPosition, 2.0) + 2.0 * (-Math.Pow(this.elementLength, 2.0) + 6.0 * this.gCoefficient) * Math.Pow(this.loadPosition, 1.0)
                - (6.0 * this.gCoefficient * (Math.Pow(this.elementLength, 1.0))))
                * this.loadValue / (Math.Pow(this.elementLength, 1.0) * (Math.Pow(this.elementLength, 2.0) + 12.0 * this.gCoefficient));

            return new List<double> { q1, m1, q2, m2 };
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
