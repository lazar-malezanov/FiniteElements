using Bytes2you.Validation;
using FiniteElements.ContractsForExternalLibraries;
using FiniteElements.Core.Contracts;
using FiniteElements.Models.Contracts;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Creating
{
    internal class CreateFrameSection : CreateCommand
    {
        private IExternalFrameSectionLibrary createFrameSectionLibrary;

        public CreateFrameSection(IDatabase dbctx, IExternalFrameSectionLibrary createFrameSectionLibrary) : base(dbctx)
        {
            Guard.WhenArgument(createFrameSectionLibrary, "createFrameSectionLibrary").IsNull().Throw();

            this.createFrameSectionLibrary = createFrameSectionLibrary;
        }

        public override string Execute(IList<string> parameters)
        {
            IFrameSection frameSection;

            try
            {
                frameSection = this.createFrameSectionLibrary.WithParameters(parameters);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateFrameSection command parameters.");
            }           

            this.dbctx.FrameSections.Add(frameSection);
            frameSection.Number = base.dbctx.FrameSections.Count - 1;
            return $"Frame Section with ID {frameSection.Number} was created.";
        }
    }
}
