using Bytes2you.Validation;
using FiniteElements.Models.Contracts;
using FrameSections.Contracts;

namespace FiniteElements.Adapters
{
    internal class FrameSectionAdapter : IFrameSection
    {
        private double area;
        private double mju;
        private double momentOfInertiaY;
        private double momentOfInertiaZ;
        private double torsionalConstantX;
        private string name;
        private double number;
        private string type;

        public FrameSectionAdapter(ISection sectionFromLibrary)
        {
            Guard.WhenArgument(sectionFromLibrary, "sectionFromLibrary").IsNull().Throw();

            this.area = sectionFromLibrary.Area;
            this.mju = sectionFromLibrary.Mju;
            this.momentOfInertiaY = sectionFromLibrary.MomentOfInertiaY;
            this.momentOfInertiaZ = sectionFromLibrary.MomentOfInertiaZ;
            this.torsionalConstantX = sectionFromLibrary.TorsionalConstantX;
            this.name = sectionFromLibrary.Name;
            this.number = sectionFromLibrary.Number;
            this.type = sectionFromLibrary.Type;
        }

        public double Area
        {
            get
            {
                return this.area;
            }
        }

        public double Mju
        {
            get
            {
                return this.mju;
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

        public double Number
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

        public string Type
        {
            get
            {
                return this.type;
            }
        }
    }
}
