using FiniteElements.Core.Contracts;
using FiniteElements.Models.Contracts;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Assign.Releases
{
    internal class AssignShearZReleaseNode2 : AssignCommand
    {
        public AssignShearZReleaseNode2(IDatabase dbctx) : base(dbctx) { }

        public override string Execute(IList<string> parameters)
        {
            int elementId;

            try
            {
                elementId = int.Parse(parameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse AssignShearZReleaseNode2 command parameters.");
            }

            IFrameElement frameElement = base.dbctx.FrameElements[elementId];

            frameElement.ShearZReleaseNode2 = true;
            return $"Shear in Z direction release at node 2 has been assigned to element with ID {frameElement.Number}.";
        }
    }
}
