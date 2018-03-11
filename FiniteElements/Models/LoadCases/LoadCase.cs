using Bytes2you.Validation;
using FiniteElements.Models.Contracts;

namespace FiniteElements.Models.LoadCases
{
    internal class LoadCase : ILoadCase
    {
        private string name;
        private int number;

        public LoadCase(string name)
        {
            Guard.WhenArgument(name, "name").IsNullOrWhiteSpace().Throw();

            this.name = name;      
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Guard.WhenArgument(value, "name").IsNullOrWhiteSpace().Throw();
                this.name = value;
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
                Guard.WhenArgument(value, "number").IsLessThan(0).Throw();
                this.number = value;
            }
        }
    }
}
