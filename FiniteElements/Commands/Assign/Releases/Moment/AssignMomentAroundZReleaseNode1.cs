using FiniteElements.Core.Contracts;
using FiniteElements.Models.Contracts;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Assign.Releases
{
    internal class AssignMomentAroundZReleaseNode1 : AssignCommand
    {
        public AssignMomentAroundZReleaseNode1(IDatabase dbctx) : base(dbctx) { }

        public override string Execute(IList<string> parameters)
        {
            int elementId;

            try
            {
                elementId = int.Parse(parameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse AssignMomentAroundZReleaseNode1 command parameters.");
            }

            IFrameElement frameElement = base.dbctx.FrameElements[elementId];

            frameElement.MomentAroundZReleaseNode1 = true;
            return $"Moment around Z release at node 1 has been assigned to element with ID {frameElement.Number}.";
        }
    }
}
