using FiniteElements.Core.Contracts;
using FiniteElements.Models.Contracts;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Assign.Releases
{
    internal class AssignMomentAroundYReleaseNode1 : AssignCommand
    {
        public AssignMomentAroundYReleaseNode1(IDatabase dbctx) : base(dbctx) { }

        public override string Execute(IList<string> parameters)
        {
            int elementId;

            try
            {
                elementId = int.Parse(parameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse AssignMomentAroundYReleaseNode1 command parameters.");
            }

            IFrameElement frameElement = base.dbctx.FrameElements[elementId];

            frameElement.MomentAroundYReleaseNode1 = true;
            return $"Moment around Y release at node 1 has been assigned to element with ID {frameElement.Number}.";
        }
    }
}
