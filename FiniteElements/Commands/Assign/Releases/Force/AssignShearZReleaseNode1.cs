using FiniteElements.Core.Contracts;
using FiniteElements.Models.Contracts;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Assign.Releases
{
    internal class AssignShearZReleaseNode1 : AssignCommand
    {
        public AssignShearZReleaseNode1(IDatabase dbctx) : base(dbctx) { }

        public override string Execute(IList<string> parameters)
        {
            int elementId;

            try
            {
                elementId = int.Parse(parameters[0]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse AssignShearZReleaseNode1 command parameters.");
            }

            IFrameElement frameElement = base.dbctx.FrameElements[elementId];

            frameElement.ShearZReleaseNode1 = true;
            return $"Shear in Z direction release at node 1 has been assigned to element with ID {frameElement.Number}.";
        }
    }
}
