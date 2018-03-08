using Bytes2you.Validation;
using FrameSections.Contracts;
using System;

namespace FrameSections.Sections
{
    internal class RectangularSection : ISection
    {
        private double height;
        private double width;
        private string type = "Rectangular Section";
        private string name;
        private double area;
        private double momentOfInertiaY;
        private double momentOfInertiaZ;
        private double torsionalConstantX;
        private double mju = 1.2;
        private double number;

        public RectangularSection(double height, double width)
        {
            Guard.WhenArgument(height, "height").IsNaN().Throw();
            Guard.WhenArgument(height, "height").IsLessThan(0.0).Throw();

            Guard.WhenArgument(width, "width").IsNaN().Throw();
            Guard.WhenArgument(width, "width").IsLessThan(0.0).Throw();

            InitializeProperties(height, width);
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                Guard.WhenArgument(value, "height").IsNaN().Throw();
                Guard.WhenArgument(value, "height").IsLessThan(0.0).Throw();

                InitializeProperties(value, this.width);
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                Guard.WhenArgument(value, "width").IsNaN().Throw();
                Guard.WhenArgument(value, "width").IsLessThan(0.0).Throw();

                InitializeProperties(this.height, value);
            }
        }

        public double Area
        {
            get
            {
                return this.area;
            }
        }

        public double MomentOfInertiaY
        {
            get
            {
                return this.momentOfInertiaY;
            }
        }

        public double MomentOfInertiaZ
        {
            get
            {
                return this.momentOfInertiaZ;
            }
        }

        public double TorsionalConstantX
        {
            get
            {
                return this.torsionalConstantX;
            }
        }

        public double Mju
        {
            get
            {
                return this.mju;
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

        public string Type
        {
            get
            {
                return type;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        private void InitializeProperties(double height, double width)
        {
            this.height = height;
            this.width = width;
            this.area = height * width;
            this.momentOfInertiaZ = height * height * height * width / 12.0;
            this.momentOfInertiaY = height * width * width * width / 12.0;

            double a = 0.5 * Math.Max(height, width);
            double b = 0.5 * Math.Min(height, width);

            this.torsionalConstantX = a * b * b * b * ((16.0 / 3.0) - 3.36 * (b / a) * (1 - (b * b * b * b) / (12.0 * a * a * a * a)));
        }
    }
}
