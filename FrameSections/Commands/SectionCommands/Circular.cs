using Bytes2you.Validation;
using FrameSections.Commands.Contracts;
using FrameSections.Contracts;
using FrameSections.Core.Factories;
using FrameSections.Sections;
using System;
using System.Collections.Generic;

namespace FrameSections.Commands.SectionCommands
{
    internal class Circular : ICommand
    {
        private readonly IFrameSectionFactory factory;

        public Circular(IFrameSectionFactory factory)
        {
            Guard.WhenArgument(factory, "factory").IsNull().Throw();

            this.factory = factory;
        }

        public ISection Execute(IList<string> parameters)
        {
            double diameter; 

            try
            {
                diameter = double.Parse(parameters[0]);  
            }
            catch
            {
                throw new ArgumentException("Failed to parse Circular command parameters.");
            }

            ISection frameSection = new CircularSection(diameter);
            return frameSection;
        }
    }
}
