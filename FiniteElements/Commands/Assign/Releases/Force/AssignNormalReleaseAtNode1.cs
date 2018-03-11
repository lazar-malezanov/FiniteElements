using FiniteElements.Core.Contracts;
using FiniteElements.Models.Contracts;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Assign.Releases
{
    internal class AssignNormalReleaseAtNode1 : AssignCommand
    {
        public AssignNormalReleaseAtNode1(IDatabase dbctx) : base(dbctx) { }

        public override string Execute(IList<string> parameters)
        {
            int elementId;

            try
            {
                elementId = int.Parse(parameters[0]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse AssignNormalReleaseAtNode1 command parameters.");
            }

            IFrameElement frameElement = base.dbctx.FrameElements[elementId];

            frameElement.NormalReleaseNode1 = true;
            return $"Normal release at node 1 has been assigned to element with ID {frameElement.Number}.";
        }
    }
}
