using Bytes2you.Validation;
using Materials.Contracts;
using System;

namespace Materials.Materials
{
    internal class RebarSteel : IMaterialFromLibrary
    {
        private double fyk;          //[kN/m2]
        private double epsilonUk;    //[%.]
        private double k;            //[-]
        private double epsilonYk;    //[%.]
        private double e;            //[kN/m2]
        private double poissonRatio = 0.3;
        private double gModule;      //[kN/m2]
        private int number;
        private string name;
        private string type = "Rebar Steel";

        public RebarSteel(string rebarType)
        {
            Guard.WhenArgument(rebarType, "rebarType").IsNull().Throw();

            double[] steel = SelectRebarSteel(rebarType);
            this.fyk = steel[0];
            this.epsilonUk = steel[0];
            this.k = steel[0];
            this.epsilonYk = steel[0];
            this.e = steel[0];
            this.gModule = this.e / (2.0 * (1.0 + this.poissonRatio));
        }

        public double Fyk
        {
            get
            {
                return this.fyk;
            }
        }

        public double EpsilonUk
        {
            get
            {
                return this.epsilonUk;
            }
        }

        public double K
        {
            get
            {
                return this.k;
            }
        }

        public double EpsilonYk
        {
            get
            {
                return this.epsilonYk;
            }
        }

        public double E
        {
            get
            {
                return this.e;
            }
        }

        public double EModule
        {
            get
            {
                return this.e;
            }
        }

        public double GModule
        {
            get
            {
                return this.gModule;
            }
        }

        public double PoissonRatio
        {
            get
            {
                return this.poissonRatio;
            }

            set
            {
                Guard.WhenArgument(value, "Poisson").IsNaN().Throw();
                Guard.WhenArgument(value, "Poisson").IsLessThan(0.0).Throw();
                Guard.WhenArgument(value, "Poisson").IsGreaterThanOrEqual(1.0).Throw();

                this.poissonRatio = value;
                this.gModule = this.e / (2.0 * (1.0 + this.poissonRatio));
            }
        }

        public int Number
        {
            get
            {
                return this.number;
            }

            set
            {
                this.number = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public string Type
        {
            get
            {
                return this.type;
            }
        }

        public double[] SelectRebarSteel(string rebarType)
        {           
            double[] steel;

            if (rebarType == "Default")
            {
                //               fyk[kN/m2] euk[%.] k[-] eyk[%.] E[kN/m2]
                steel = new double[] { 0.0, 0.0, 0.0, 0.0, 0.0 };
                return steel;
            }
            else if (rebarType == "B500A")
            {
                //               fyk[kN/m2] euk[%.] k[-] eyk[%.] E[kN/m2]
                steel = new double[] { 500000.0, 25.0, 1.05, 2.5, 200000000.0 };
                return steel;
            }
            else if (rebarType == "B500B")
            {
                steel = new double[] { 500000.0, 50.0, 1.08, 2.5, 200000000.0 };
                return steel;
            }
            else if (rebarType == "B500C")
            {
                steel = new double[] { 500000.0, 75.0, 1.15, 2.5, 200000000.0 };
                return steel;
            }
            else if (rebarType == "B420A")
            {
                steel = new double[] { 420000.0, 50.0, 1.08, 2.1, 200000000.0 };
                return steel;
            }
            else if (rebarType == "B420C")
            {
                steel = new double[] { 420000.0, 80.0, 1.15, 2.1, 200000000.0 };
                return steel;
            }
            else
            {
                throw new ArgumentException("Invalid rebar type!");
            }
        }
    }
}
