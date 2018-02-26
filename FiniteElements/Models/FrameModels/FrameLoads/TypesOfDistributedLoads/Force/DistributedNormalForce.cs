using FiniteElements.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiniteElements.Models.FrameModels.FrameLoads.TypesOfDistributedLoads.Force
{
    internal class DistributedNormalForce : DistributedLoads
    {
        private readonly string type = "Distributed Normal Force";

        public DistributedNormalForce(ILoadCase loadCase, double elementLength, double gCoefficient, double loadAtStart, double loadAtEnd,
            double loadStartsAt, double loadEndsAt) : base(loadCase, elementLength, gCoefficient, loadAtStart, loadAtEnd, loadStartsAt, loadEndsAt) { }

        public override List<double> GenerateLoad()
        {
            //First part
            double n11 = (-(Math.Pow(this.loadEndsAt, 2.0) - Math.Pow(this.loadStartsAt, 2.0)) / (2.0 * this.elementLength) 
                + Math.Pow(this.loadEndsAt, 1.0) - Math.Pow(this.loadStartsAt, 1.0)) 
                * this.loadAtStart;

            double n21 = ((Math.Pow(this.loadEndsAt, 2.0) - Math.Pow(this.loadStartsAt, 2.0)) / (2.0 * this.elementLength)) 
                * this.loadAtStart;

            //Second part
            double n12 = (-(Math.Pow(this.loadEndsAt, 3.0) - Math.Pow(this.loadStartsAt, 3.0)) / (3.0 * this.elementLength)
                + 0.5 * Math.Pow(this.loadEndsAt, 2.0) - Math.Pow(this.loadStartsAt, 2.0))
                * (this.loadAtEnd - this.loadAtStart) / (Math.Pow(this.loadEndsAt, 1.0) - Math.Pow(this.loadStartsAt, 1.0));

            double n22 = ((Math.Pow(this.loadEndsAt, 3.0) - Math.Pow(this.loadStartsAt, 3.0)) / (3.0 * this.elementLength))
                * (this.loadAtEnd - this.loadAtStart) / (Math.Pow(this.loadEndsAt, 1.0) - Math.Pow(this.loadStartsAt, 1.0));

            //Third part
            double n13 = - (-(Math.Pow(this.loadEndsAt, 2.0) - Math.Pow(this.loadStartsAt, 2.0)) / (2.0 * this.elementLength)
                + Math.Pow(this.loadEndsAt, 1.0) - Math.Pow(this.loadStartsAt, 1.0))
                * (this.loadAtEnd - this.loadAtStart) * this.loadStartsAt / (Math.Pow(this.loadEndsAt, 1.0) - Math.Pow(this.loadStartsAt, 1.0));

            double n23 = - ((Math.Pow(this.loadEndsAt, 2.0) - Math.Pow(this.loadStartsAt, 2.0)) / (2.0 * this.elementLength))
                * (this.loadAtEnd - this.loadAtStart) * this.loadStartsAt / (Math.Pow(this.loadEndsAt, 1.0) - Math.Pow(this.loadStartsAt, 1.0));

            //Finally
            double n1 = n11 + n12 + n13;
            double n2 = n21 + n22 + n23;

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
