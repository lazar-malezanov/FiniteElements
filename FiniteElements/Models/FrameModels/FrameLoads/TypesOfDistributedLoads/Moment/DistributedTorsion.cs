using FiniteElements.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiniteElements.Models.FrameModels.FrameLoads.TypesOfDistributedLoads.Moment
{
    internal class DistributedTorsion : DistributedLoads
    {
        private readonly string type = "Distributed Torsion (around element's X axis)";

        public DistributedTorsion(ILoadCase loadCase, double elementLength, double gCoefficient, double loadAtStart, double loadAtEnd,
            double loadStartsAt, double loadEndsAt) : base(loadCase, elementLength, gCoefficient, loadAtStart, loadAtEnd, loadStartsAt, loadEndsAt) { }

        public override List<double> GenerateLoad()
        {
            //First part
            double t11 = (-(Math.Pow(this.loadEndsAt, 2.0) - Math.Pow(this.loadStartsAt, 2.0)) / (2.0 * this.elementLength)
                + Math.Pow(this.loadEndsAt, 1.0) - Math.Pow(this.loadStartsAt, 1.0))
                * this.loadAtStart;

            double t21 = ((Math.Pow(this.loadEndsAt, 2.0) - Math.Pow(this.loadStartsAt, 2.0)) / (2.0 * this.elementLength))
                * this.loadAtStart;

            //Second part
            double t12 = (-(Math.Pow(this.loadEndsAt, 3.0) - Math.Pow(this.loadStartsAt, 3.0)) / (3.0 * this.elementLength)
                + 0.5 * Math.Pow(this.loadEndsAt, 2.0) - Math.Pow(this.loadStartsAt, 2.0))
                * (this.loadAtEnd - this.loadAtStart) / (Math.Pow(this.loadEndsAt, 1.0) - Math.Pow(this.loadStartsAt, 1.0));

            double t22 = ((Math.Pow(this.loadEndsAt, 3.0) - Math.Pow(this.loadStartsAt, 3.0)) / (3.0 * this.elementLength))
                * (this.loadAtEnd - this.loadAtStart) / (Math.Pow(this.loadEndsAt, 1.0) - Math.Pow(this.loadStartsAt, 1.0));

            //Third part
            double t13 = -(-(Math.Pow(this.loadEndsAt, 2.0) - Math.Pow(this.loadStartsAt, 2.0)) / (2.0 * this.elementLength)
                + Math.Pow(this.loadEndsAt, 1.0) - Math.Pow(this.loadStartsAt, 1.0))
                * (this.loadAtEnd - this.loadAtStart) * this.loadStartsAt / (Math.Pow(this.loadEndsAt, 1.0) - Math.Pow(this.loadStartsAt, 1.0));

            double t23 = -((Math.Pow(this.loadEndsAt, 2.0) - Math.Pow(this.loadStartsAt, 2.0)) / (2.0 * this.elementLength))
                * (this.loadAtEnd - this.loadAtStart) * this.loadStartsAt / (Math.Pow(this.loadEndsAt, 1.0) - Math.Pow(this.loadStartsAt, 1.0));

            //Finally
            double t1 = t11 + t12 + t13;
            double t2 = t21 + t22 + t23;

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
