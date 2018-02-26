using FiniteElements.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiniteElements.Models.FrameModels.FrameLoads.TypesOfConcentratedLoads.Moment
{
    internal class ConcentratedTorsion : ConcentratedLoads
    {
        private readonly string type = "Concentrated Torsion (around element's X axis)";

        public ConcentratedTorsion(ILoadCase loadCase, double elementLength, double gCoefficient,
            double loadValue, double loadPosition) : base(loadCase, elementLength, gCoefficient, loadValue, loadPosition) { }

        public override List<double> GenerateLoad()
        {
            double t1 = (-this.loadPosition + this.elementLength) * this.loadValue / this.elementLength;

            double t2 = (this.loadPosition) * this.loadValue / this.elementLength;

            return new List<double> { t1, t2 };
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
