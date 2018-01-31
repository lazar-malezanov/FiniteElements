using Bytes2you.Validation;
using FiniteElements.Models.Contracts;
using Materials.Contracts;

namespace FiniteElements.Adapters
{
    internal class MaterialAdapter : IMaterial
    {
        private double eModule;
        private double gModule;
        private string name;
        private string type;
        private double number;

        public MaterialAdapter(IMaterialFromLibrary materialFromLibrary)
        {
            Guard.WhenArgument(materialFromLibrary, "materialFromLibrary").IsNull().Throw();

            this.eModule = materialFromLibrary.EModule;
            this.gModule = materialFromLibrary.GModule;
            this.name = materialFromLibrary.Name;
            this.type = materialFromLibrary.Type;
            this.number = materialFromLibrary.Number;
        }

        public double EModule
        {
            get
            {
                return this.eModule;
            }
        }

        public double GModule
        {
            get
            {
                return this.gModule;
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
    }
}
