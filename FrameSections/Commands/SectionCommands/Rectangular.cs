using Bytes2you.Validation;
using FrameSections.Commands.Contracts;
using FrameSections.Contracts;
using FrameSections.Core.Factories;
using FrameSections.Sections;
using System;
using System.Collections.Generic;

namespace FrameSections.Commands.SectionCommands
{
    internal class Rectangular : ICommand
    {
        private readonly IFrameSectionFactory factory;

        public Rectangular(IFrameSectionFactory factory)
        {
            Guard.WhenArgument(factory, "factory").IsNull().Throw();

            this.factory = factory;
        }

        public ISection Execute(IList<string> parameters)
        {
            double height;
            double width;

            try
            {
                height = double.Parse(parameters[0]);
                width = double.Parse(parameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse Rectangular command parameters.");
            }

            ISection frameSection = new RectangularSection(height, width);
            return frameSection;
        }
    }
}
