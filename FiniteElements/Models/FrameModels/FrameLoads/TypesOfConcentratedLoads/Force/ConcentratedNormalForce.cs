using FiniteElements.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiniteElements.Models.FrameModels.FrameLoads.TypesOfConcentratedLoads.Force
{
    internal class ConcentratedNormalForce : ConcentratedLoads
    {
        private readonly string type = "Concentrated Normal Force";

        public ConcentratedNormalForce(ILoadCase loadCase, double elementLength, double gCoefficient,
            double loadValue, double loadPosition) : base(loadCase, elementLength, gCoefficient, loadValue, loadPosition) { }

        public override List<double> GenerateLoad()
        {
            double n1 = (-this.loadPosition + this.elementLength) * this.loadValue / this.elementLength;

            double n2 = (this.loadPosition) * this.loadValue / this.elementLength;

            return new List<double> { n1, n2 };
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
