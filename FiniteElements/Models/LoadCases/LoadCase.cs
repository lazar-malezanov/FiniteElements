using Bytes2you.Validation;
using FiniteElements.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiniteElements.Models.LoadCases
{
    internal class LoadCase : ILoadCase
    {
        private string name;
        private double number;

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
    }
}
