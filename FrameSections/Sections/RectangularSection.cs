using Bytes2you.Validation;
using FrameSections.Contracts;

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
        private double mju = 1.2;
        private double number;

        public RectangularSection(double height, double width)
        {
            Guard.WhenArgument(height, "height").IsNaN().Throw();
            Guard.WhenArgument(height, "height").IsLessThan(0.0).Throw();

            Guard.WhenArgument(width, "width").IsNaN().Throw();
            Guard.WhenArgument(width, "width").IsLessThan(0.0).Throw();

            this.Height = height;
            this.Width = width;
            this.area = height * width;
            this.momentOfInertiaY = height * height * height * width / 12.0;
            this.momentOfInertiaZ = height * width * width * width / 12.0;
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

                this.height = value;
                this.area = this.height * this.width;
                this.momentOfInertiaY = this.height * this.height * this.height * this.width / 12.0;
                this.momentOfInertiaZ = this.height * this.width * this.width * this.width / 12.0;
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

                this.width = value;
                this.area = this.height * this.width;
                this.momentOfInertiaY = this.height * this.height * this.height * this.width / 12.0;
                this.momentOfInertiaZ = this.height * this.width * this.width * this.width / 12.0;
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
    }
}
