using FiniteElements.Core.Contracts;
using FiniteElements.Models.Contracts;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Assign
{
    internal class AssignFrameSection : AssignCommand
    {
        public AssignFrameSection(IDatabase dbctx) : base(dbctx) { }

        public override string Execute(IList<string> parameters)
        {
            int sectionId;
            int elementId;

            try
            {
                sectionId = int.Parse(parameters[0]);
                elementId = int.Parse(parameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse AssignFrameSection command parameters.");
            }

            IFrameElement frameElement = base.dbctx.FrameElements[elementId];
            IFrameSection frameSection = base.dbctx.FrameSections[sectionId];

            frameElement.SectionProp = frameSection; 
            return $"Section with ID {frameSection.Number} has been assigned to element with ID {frameElement.Number}.";
        }
    }
}
