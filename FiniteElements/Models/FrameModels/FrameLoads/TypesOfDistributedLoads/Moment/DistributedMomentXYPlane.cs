using FiniteElements.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiniteElements.Models.FrameModels.FrameLoads.TypesOfDistributedLoads.Moment
{
    internal class DistributedMomentXYPlane : DistributedLoads
    {
        private readonly string type = "Distributed Moment in XY Plane (around element's Z axis)";

        public DistributedMomentXYPlane(ILoadCase loadCase, double elementLength, double gCoefficient, double loadAtStart, double loadAtEnd,
            double loadStartsAt, double loadEndsAt) : base(loadCase, elementLength, gCoefficient, loadAtStart, loadAtEnd, loadStartsAt, loadEndsAt) { }

        public override List<double> GenerateLoad()
        {
            //First part
            double q11 = (2.0 * (Math.Pow(this.loadEndsAt, 3.0) - Math.Pow(this.loadStartsAt, 3.0))
                - 3.0 * this.elementLength * (Math.Pow(this.loadEndsAt, 2.0) - Math.Pow(this.loadStartsAt, 2.0))
                - 12.0 * this.gCoefficient * (Math.Pow(this.loadEndsAt, 1.0) - Math.Pow(this.loadStartsAt, 1.0)))
                * this.loadAtStart / (this.elementLength * (Math.Pow(this.elementLength, 2.0) + 12.0 * this.gCoefficient));

            double q21 = (- 2.0 * (Math.Pow(this.loadEndsAt, 3.0) - Math.Pow(this.loadStartsAt, 3.0))
                + 3.0 * this.elementLength * (Math.Pow(this.loadEndsAt, 2.0) - Math.Pow(this.loadStartsAt, 2.0))
                + 12.0 * this.gCoefficient * (Math.Pow(this.loadEndsAt, 1.0) - Math.Pow(this.loadStartsAt, 1.0)))
                * this.loadAtStart / (this.elementLength * (Math.Pow(this.elementLength, 2.0) + 12.0 * this.gCoefficient));

            double m11 = (this.elementLength * (Math.Pow(this.loadEndsAt, 3.0) - Math.Pow(this.loadStartsAt, 3.0))
                - (2.0 * Math.Pow(this.elementLength, 2.0) + 6 * this.gCoefficient) * (Math.Pow(this.loadEndsAt, 2.0) - Math.Pow(this.loadStartsAt, 2.0))
                + (Math.Pow(this.elementLength, 3.0) + 6.0 * this.gCoefficient * this.elementLength) * (Math.Pow(this.loadEndsAt, 1.0) - Math.Pow(this.loadStartsAt, 1.0)))
                * this.loadAtStart / (this.elementLength * (Math.Pow(this.elementLength, 2.0) + 12.0 * this.gCoefficient));

            double m21 = (this.elementLength * (Math.Pow(this.loadEndsAt, 3.0) - Math.Pow(this.loadStartsAt, 3.0))
                + (- Math.Pow(this.elementLength, 2.0) + 6.0 * this.gCoefficient) * (Math.Pow(this.loadEndsAt, 2.0) - Math.Pow(this.loadStartsAt, 2.0))
                - (6.0 * this.gCoefficient * this.elementLength) * (Math.Pow(this.loadEndsAt, 1.0) - Math.Pow(this.loadStartsAt, 1.0)))
                * this.loadAtStart / (this.elementLength * (Math.Pow(this.elementLength, 2.0) + 12.0 * this.gCoefficient));

            //Second part
            double q12 = (1.5 * (Math.Pow(this.loadEndsAt, 4.0) - Math.Pow(this.loadStartsAt, 4.0))
                - 2.0 * this.elementLength * (Math.Pow(this.loadEndsAt, 3.0) - Math.Pow(this.loadStartsAt, 3.0))
                - 6.0 * this.gCoefficient * (Math.Pow(this.loadEndsAt, 2.0) - Math.Pow(this.loadStartsAt, 2.0)))
                * (this.loadAtEnd - this.loadAtStart) / ((loadEndsAt - loadStartsAt) * this.elementLength * (Math.Pow(this.elementLength, 2.0) + 12.0 * this.gCoefficient));

            double q22 = (- 1.5 * (Math.Pow(this.loadEndsAt, 4.0) - Math.Pow(this.loadStartsAt, 4.0))
                + 2.0 * this.elementLength * (Math.Pow(this.loadEndsAt, 3.0) - Math.Pow(this.loadStartsAt, 3.0))
                + 6.0 * this.gCoefficient * (Math.Pow(this.loadEndsAt, 2.0) - Math.Pow(this.loadStartsAt, 2.0)))
                * (this.loadAtEnd - this.loadAtStart) / ((loadEndsAt - loadStartsAt) * this.elementLength * (Math.Pow(this.elementLength, 2.0) + 12.0 * this.gCoefficient));

            double m12 = (0.75 * this.elementLength * (Math.Pow(this.loadEndsAt, 4.0) - Math.Pow(this.loadStartsAt, 4.0))
                - (2.0/3.0) * (2.0 * Math.Pow(this.elementLength, 2.0) + 6.0 * this.gCoefficient) * (Math.Pow(this.loadEndsAt, 3.0) - Math.Pow(this.loadStartsAt, 3.0))
                + 0.5 * (Math.Pow(this.elementLength, 3.0) + 6.0 * this.gCoefficient * this.elementLength) * (Math.Pow(this.loadEndsAt, 2.0) - Math.Pow(this.loadStartsAt, 2.0)))
                * (this.loadAtEnd - this.loadAtStart) / ((loadEndsAt - loadStartsAt) * this.elementLength * (Math.Pow(this.elementLength, 2.0) + 12.0 * this.gCoefficient));

            double m22 = (0.75 * this.elementLength * (Math.Pow(this.loadEndsAt, 4.0) - Math.Pow(this.loadStartsAt, 4.0))
                + (2.0 / 3.0) * (- Math.Pow(this.elementLength, 2.0) + 6.0 * this.gCoefficient) * (Math.Pow(this.loadEndsAt, 3.0) - Math.Pow(this.loadStartsAt, 3.0))
                - (3.0 * this.gCoefficient * this.elementLength) * (Math.Pow(this.loadEndsAt, 2.0) - Math.Pow(this.loadStartsAt, 2.0)))
                * (this.loadAtEnd - this.loadAtStart) / ((loadEndsAt - loadStartsAt) * this.elementLength * (Math.Pow(this.elementLength, 2.0) + 12.0 * this.gCoefficient));

            //Third part
            double q13 = - (2.0 * (Math.Pow(this.loadEndsAt, 3.0) - Math.Pow(this.loadStartsAt, 3.0))
                - 3.0 * this.elementLength * (Math.Pow(this.loadEndsAt, 2.0) - Math.Pow(this.loadStartsAt, 2.0))
                - 12.0 * this.gCoefficient * (Math.Pow(this.loadEndsAt, 1.0) - Math.Pow(this.loadStartsAt, 1.0)))
                * (this.loadAtEnd - this.loadAtStart) / ((loadEndsAt - loadStartsAt) * this.elementLength * (Math.Pow(this.elementLength, 2.0) + 12.0 * this.gCoefficient));

            double q23 = - (-2.0 * (Math.Pow(this.loadEndsAt, 3.0) - Math.Pow(this.loadStartsAt, 3.0))
                + 3.0 * this.elementLength * (Math.Pow(this.loadEndsAt, 2.0) - Math.Pow(this.loadStartsAt, 2.0))
                + 12.0 * this.gCoefficient * (Math.Pow(this.loadEndsAt, 1.0) - Math.Pow(this.loadStartsAt, 1.0)))
                * (this.loadAtEnd - this.loadAtStart) / ((loadEndsAt - loadStartsAt) * this.elementLength * (Math.Pow(this.elementLength, 2.0) + 12.0 * this.gCoefficient));

            double m13 = - (this.elementLength * (Math.Pow(this.loadEndsAt, 3.0) - Math.Pow(this.loadStartsAt, 3.0))
                - (2.0 * Math.Pow(this.elementLength, 2.0) + 6.0 * this.gCoefficient) * (Math.Pow(this.loadEndsAt, 2.0) - Math.Pow(this.loadStartsAt, 2.0))
                + (Math.Pow(this.elementLength, 3.0) + 6.0 * this.gCoefficient * this.elementLength) * (Math.Pow(this.loadEndsAt, 1.0) - Math.Pow(this.loadStartsAt, 1.0)))
                * (this.loadAtEnd - this.loadAtStart) / ((loadEndsAt - loadStartsAt) * this.elementLength * (Math.Pow(this.elementLength, 2.0) + 12.0 * this.gCoefficient));

            double m23 = - (this.elementLength * (Math.Pow(this.loadEndsAt, 3.0) - Math.Pow(this.loadStartsAt, 3.0))
                + (-Math.Pow(this.elementLength, 2.0) + 6.0 * this.gCoefficient) * (Math.Pow(this.loadEndsAt, 2.0) - Math.Pow(this.loadStartsAt, 2.0))
                - (6.0 * this.gCoefficient * this.elementLength) * (Math.Pow(this.loadEndsAt, 1.0) - Math.Pow(this.loadStartsAt, 1.0)))
                * (this.loadAtEnd - this.loadAtStart) / ((loadEndsAt - loadStartsAt) * this.elementLength * (Math.Pow(this.elementLength, 2.0) + 12.0 * this.gCoefficient));

            //Finally
            double q1 = q11 + q12 + q13;
            double q2 = q21 + q22 + q23;
            double m1 = m11 + m12 + m13;
            double m2 = m21 + m22 + m23;

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
