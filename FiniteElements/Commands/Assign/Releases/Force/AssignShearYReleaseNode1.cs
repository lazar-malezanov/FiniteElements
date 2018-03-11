using FiniteElements.Core.Contracts;
using FiniteElements.Models.Contracts;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Assign.Releases
{
    internal class AssignShearYReleaseNode1 : AssignCommand
    {
        public AssignShearYReleaseNode1(IDatabase dbctx) : base(dbctx) { }

        public override string Execute(IList<string> parameters)
        {
            int elementId;

            try
            {
                elementId = int.Parse(parameters[0]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse AssignShearYReleaseNode1 command parameters.");
            }

            IFrameElement frameElement = base.dbctx.FrameElements[elementId];

            frameElement.ShearYReleaseNode1 = true;
            return $"Shear in Y direction release at node 1 has been assigned to element with ID {frameElement.Number}.";
        }
    }
}
