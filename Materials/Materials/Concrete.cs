using Bytes2you.Validation;
using Materials.Contracts;
using System;

namespace Materials.Materials
{
    internal class Concrete : IMaterialFromLibrary
    {
        private double fck;         //[kN/m2]
        private double fckCube;     //[kN/m2]
        private double fcm;         //[kN/m2]
        private double fctm;        //[kN/m2]
        private double fctk005;     //[kN/m2]
        private double fctk095;     //[kN/m2]
        private double ecm;         //[kN/m2]
        private double ec1;         //[kN/m2]
        private double epsilonC1;   //[%.]  - promils
        private double epsilonCu1;  //[%.]  - promils
        private double epsilonC2;   //[%.]  - promils
        private double epsilonCu2;  //[%.]  - promils
        private double n;           //[-]                                   
        private double epsilonC3;   //[%.]  - promils
        private double epsilonCu3;  //[%.]  - promils
        private double poissonRatio = 0.2;
        private double gModule;
        private double number;
        private string name;
        private string type = "Concrete";

        public Concrete(string concreteType)
        {
            Guard.WhenArgument(concreteType, "concreteType").IsNull().Throw();

            double[] concrete = SelectConcrete(concreteType);
            this.fck = concrete[0];
            this.fckCube = concrete[1];
            this.fcm = concrete[2];
            this.fctm = concrete[3];
            this.fctk005 = concrete[4];
            this.fctk095 = concrete[5];
            this.ecm = concrete[6];
            this.ec1 = concrete[7];
            this.epsilonC1 = concrete[8];
            this.epsilonCu1 = concrete[9];
            this.epsilonC2 = concrete[10];
            this.epsilonCu2 = concrete[11];
            this.n = concrete[12];
            this.epsilonC3 = concrete[13];
            this.epsilonCu3 = concrete[14];
            this.gModule = this.ecm / (2.0 * (1.0 + this.poissonRatio));
        }

        public double Fck
        {
            get
            {
                return this.fck;
            }
        }

        public double FckCube
        {
            get
            {
                return this.fckCube;
            }
        }

        public double Fcm
        {
            get
            {
                return this.fcm;
            }
        }

        public double Fctm
        {
            get
            {
                return this.fctm;
            }
        }

        public double Fctk005
        {
            get
            {
                return this.fctk005;
            }
        }

        public double Fctk095
        {
            get
            {
                return this.fctk095;
            }
        }

        public double Ecm
        {
            get
            {
                return this.ecm;
            }
        }

        public double Ec1
        {
            get
            {
                return this.ec1;
            }
        }

        public double EpsilonC1
        {
            get
            {
                return this.epsilonC1;
            }
        }

        public double EpsilonCu1
        {
            get
            {
                return this.epsilonCu1;
            }
        }

        public double EpsilonC2
        {
            get
            {
                return this.epsilonC2;
            }
        }

        public double EpsilonCu2
        {
            get
            {
                return this.epsilonCu2;
            }
        }

        public double N
        {
            get
            {
                return this.n;
            }
        }

        public double EpsilonC3
        {
            get
            {
                return this.epsilonC3;
            }
        }

        public double EpsilonCu3
        {
            get
            {
                return this.epsilonCu3;
            }
        }

        public double EModule
        {
            get
            {
                return this.ecm;
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
                Guard.WhenArgument(value, "Poisson").IsLessThanOrEqual(0.0).Throw();
                Guard.WhenArgument(value, "Poisson").IsGreaterThanOrEqual(1.0).Throw();

                this.poissonRatio = value;
                this.gModule = this.ecm / (2.0 * (1.0 + this.poissonRatio));
            }
        }

        public double Number
        {
            get
            {
                return this.number;
            }

            set
            {
                Guard.WhenArgument(value, "number").IsNaN().Throw();
                Guard.WhenArgument(value, "number").IsLessThan(0.0).Throw();
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

        private double[] SelectConcrete(string concreteType)
        {
            double[] concrete;
            if (concreteType == "Default")
            {
                concrete = new double[] { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 };
                //                   fck[kN/m2]  fck,cube[kN/m2]  fcm[kN/m2]   fctm[kN/m2]  fctk0,05[kN/m2]  fctk0,95[kN/m2]  Ecm[kN/m2]        Ec1[kN/m2]      ec1[%.]     ecu1[%.]    ec2[%.]     ecu2[%.]    n[-]    ec3[%.]  ecu3[%.]
                return concrete;
            }
            else if (concreteType == "C12/15")
            {
                concrete = new double[] { 12000.0, 15000.0, 20000.0, 1570.0, 1100.0, 2040.0, 27090000.0, 11290000.0, 1.77, 3.5, 2.0, 3.5, 2.0, 1.75, 3.5 };
                //                   fck[kN/m2]  fck,cube[kN/m2]  fcm[kN/m2]   fctm[kN/m2]  fctk0,05[kN/m2]  fctk0,95[kN/m2]  Ecm[kN/m2]        Ec1[kN/m2]      ec1[%.]     ecu1[%.]    ec2[%.]     ecu2[%.]    n[-]    ec3[%.]  ecu3[%.]
                return concrete;
            }
            else if (concreteType == "C16/20")
            {
                concrete = new double[] { 16000.0, 20000.0, 24000.0, 1900.0, 1330.0, 2480.0, 28610000.0, 12800000.0, 1.87, 3.5, 2.0, 3.5, 2.0, 1.75, 3.5 };
                //                   fck[kN/m2]  fck,cube[kN/m2]  fcm[kN/m2]   fctm[kN/m2]  fctk0,05[kN/m2]  fctk0,95[kN/m2]  Ecm[kN/m2]        Ec1[kN/m2]      ec1[%.]     ecu1[%.]    ec2[%.]     ecu2[%.]    n[-]    ec3[%.]  ecu3[%.]
                return concrete;
            }
            else if (concreteType == "C20/25")
            {
                concrete = new double[] { 20000.0, 25000.0, 28000.0, 2210.0, 1550.0, 2870.0, 29960000.0, 14240000.0, 1.97, 3.5, 2.0, 3.5, 2.0, 1.75, 3.5 };
                //                   fck[kN/m2]  fck,cube[kN/m2]  fcm[kN/m2]   fctm[kN/m2]  fctk0,05[kN/m2]  fctk0,95[kN/m2]  Ecm[kN/m2]        Ec1[kN/m2]      ec1[%.]     ecu1[%.]    ec2[%.]     ecu2[%.]    n[-]    ec3[%.]  ecu3[%.]
                return concrete;
            }
            else if (concreteType == "C25/30")
            {
                concrete = new double[] { 25000.0, 30000.0, 33000.0, 2560.0, 1800.0, 3330.0, 31480000.0, 15950000.0, 2.07, 3.5, 2.0, 3.5, 2.0, 1.75, 3.5 };
                //                   fck[kN/m2]  fck,cube[kN/m2]  fcm[kN/m2]   fctm[kN/m2]  fctk0,05[kN/m2]  fctk0,95[kN/m2]  Ecm[kN/m2]        Ec1[kN/m2]      ec1[%.]     ecu1[%.]    ec2[%.]     ecu2[%.]    n[-]    ec3[%.]  ecu3[%.]
                return concrete;
            }
            else if (concreteType == "C30/37")
            {
                concrete = new double[] { 30000.0, 37000.0, 38000.0, 2900.0, 2030.0, 3770.0, 32840000.0, 17580000.0, 2.16, 3.5, 2.0, 3.5, 2.0, 1.75, 3.5 };
                //                   fck[kN/m2]  fck,cube[kN/m2]  fcm[kN/m2]   fctm[kN/m2]  fctk0,05[kN/m2]  fctk0,95[kN/m2]  Ecm[kN/m2]        Ec1[kN/m2]      ec1[%.]     ecu1[%.]    ec2[%.]     ecu2[%.]    n[-]    ec3[%.]  ecu3[%.]
                return concrete;
            }
            else if (concreteType == "C35/45")
            {
                concrete = new double[] { 35000.0, 45000.0, 43000.0, 3210.0, 2250.0, 4170.0, 34080000.0, 19140000.0, 2.25, 3.5, 2.0, 3.5, 2.0, 1.75, 3.5 };
                //                   fck[kN/m2]  fck,cube[kN/m2]  fcm[kN/m2]   fctm[kN/m2]  fctk0,05[kN/m2]  fctk0,95[kN/m2]  Ecm[kN/m2]        Ec1[kN/m2]      ec1[%.]     ecu1[%.]    ec2[%.]     ecu2[%.]    n[-]    ec3[%.]  ecu3[%.]
                return concrete;
            }
            else if (concreteType == "C40/50")
            {
                concrete = new double[] { 40000.0, 50000.0, 48000.0, 3510.0, 2460.0, 4560.0, 35220000.0, 20650000.0, 2.32, 3.5, 2.0, 3.5, 2.0, 1.75, 3.5 };
                //                   fck[kN/m2]  fck,cube[kN/m2]  fcm[kN/m2]   fctm[kN/m2]  fctk0,05[kN/m2]  fctk0,95[kN/m2]  Ecm[kN/m2]        Ec1[kN/m2]      ec1[%.]     ecu1[%.]    ec2[%.]     ecu2[%.]    n[-]    ec3[%.]  ecu3[%.]
                return concrete;
            }
            else if (concreteType == "C45/55")
            {
                concrete = new double[] { 45000.0, 55000.0, 53000.0, 3800.0, 2660.0, 4930.0, 36280000.0, 22110000.0, 2.40, 3.5, 2.0, 3.5, 2.0, 1.75, 3.5 };
                //                   fck[kN/m2]  fck,cube[kN/m2]  fcm[kN/m2]   fctm[kN/m2]  fctk0,05[kN/m2]  fctk0,95[kN/m2]  Ecm[kN/m2]        Ec1[kN/m2]      ec1[%.]     ecu1[%.]    ec2[%.]     ecu2[%.]    n[-]    ec3[%.]  ecu3[%.]
                return concrete;
            }
            else if (concreteType == "C50/60")
            {
                concrete = new double[] { 50000.0, 60000.0, 58000.0, 4070.0, 2850.0, 5290.0, 37280000.0, 23530000.0, 2.46, 3.5, 2.0, 3.5, 2.0, 1.75, 3.5 };
                //                   fck[kN/m2]  fck,cube[kN/m2]  fcm[kN/m2]   fctm[kN/m2]  fctk0,05[kN/m2]  fctk0,95[kN/m2]  Ecm[kN/m2]        Ec1[kN/m2]      ec1[%.]     ecu1[%.]    ec2[%.]     ecu2[%.]    n[-]    ec3[%.]  ecu3[%.]
                return concrete;
            }
            else if (concreteType == "C55/67")
            {
                concrete = new double[] { 55000.0, 67000.0, 63000.0, 4210.0, 2950.0, 5480.0, 38210000.0, 24910000.0, 2.53, 3.2, 2.2, 3.1, 1.75, 1.8, 3.1 };
                //                   fck[kN/m2]  fck,cube[kN/m2]  fcm[kN/m2]   fctm[kN/m2]  fctk0,05[kN/m2]  fctk0,95[kN/m2]  Ecm[kN/m2]        Ec1[kN/m2]      ec1[%.]     ecu1[%.]    ec2[%.]     ecu2[%.]    n[-]    ec3[%.]  ecu3[%.]
                return concrete;
            }
            else if (concreteType == "C60/75")
            {
                concrete = new double[] { 60000.0, 75000.0, 68000.0, 4350.0, 3050.0, 5660.0, 39100000.0, 26260000.0, 2.59, 3.0, 2.3, 2.9, 1.6, 1.9, 2.9 };
                //                   fck[kN/m2]  fck,cube[kN/m2]  fcm[kN/m2]   fctm[kN/m2]  fctk0,05[kN/m2]  fctk0,95[kN/m2]  Ecm[kN/m2]        Ec1[kN/m2]      ec1[%.]     ecu1[%.]    ec2[%.]     ecu2[%.]    n[-]    ec3[%.]  ecu3[%.]
                return concrete;
            }
            else if (concreteType == "C70/85")
            {
                concrete = new double[] { 70000.0, 85000.0, 78000.0, 4610.0, 3230.0, 5990.0, 40740000.0, 28870000.0, 2.70, 2.8, 2.4, 2.7, 1.45, 2.0, 2.7 };
                //                   fck[kN/m2]  fck,cube[kN/m2]  fcm[kN/m2]   fctm[kN/m2]  fctk0,05[kN/m2]  fctk0,95[kN/m2]  Ecm[kN/m2]        Ec1[kN/m2]      ec1[%.]     ecu1[%.]    ec2[%.]     ecu2[%.]    n[-]    ec3[%.]  ecu3[%.]
                return concrete;
            }
            else if (concreteType == "C80/95")
            {
                concrete = new double[] { 80000.0, 95000.0, 88000.0, 4840.0, 3390.0, 6290.0, 42240000.0, 31430000.0, 2.80, 2.8, 2.5, 2.6, 1.4, 2.2, 2.6 };
                //                   fck[kN/m2]  fck,cube[kN/m2]  fcm[kN/m2]   fctm[kN/m2]  fctk0,05[kN/m2]  fctk0,95[kN/m2]  Ecm[kN/m2]        Ec1[kN/m2]      ec1[%.]     ecu1[%.]    ec2[%.]     ecu2[%.]    n[-]    ec3[%.]  ecu3[%.]
                return concrete;
            }
            else if (concreteType == "C90/105")
            {
                concrete = new double[] { 90000.0, 105000.0, 98000.0, 5040.0, 3530.0, 6560.0, 43630000.0, 35000000.0, 2.80, 2.8, 2.6, 2.6, 1.4, 2.3, 2.6 };
                //                   fck[kN/m2]  fck,cube[kN/m2]  fcm[kN/m2]   fctm[kN/m2]  fctk0,05[kN/m2]  fctk0,95[kN/m2]  Ecm[kN/m2]        Ec1[kN/m2]      ec1[%.]     ecu1[%.]    ec2[%.]     ecu2[%.]    n[-]    ec3[%.]  ecu3[%.]
                return concrete;
            }
            else if (concreteType == "test")
            {
                concrete = new double[] { 90000.0, 105000.0, 98000.0, 5040.0, 3530.0, 6560.0, 29000.0, 35000000.0, 2.80, 2.8, 2.6, 2.6, 1.4, 2.3, 2.6 };
                //                   fck[kN/m2]  fck,cube[kN/m2]  fcm[kN/m2]   fctm[kN/m2]  fctk0,05[kN/m2]  fctk0,95[kN/m2]  Ecm[kN/m2]        Ec1[kN/m2]      ec1[%.]     ecu1[%.]    ec2[%.]     ecu2[%.]    n[-]    ec3[%.]  ecu3[%.]
                return concrete;
            }
            else
            {
                throw new ArgumentException("Invalid concrete type!");
            }
        }
    }
}
