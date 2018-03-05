using FiniteElements.Core.Contracts;
using FiniteElements.Models.Contracts;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Assign.Releases
{
    internal class AssignTorsionReleaseAtNode1 : AssignCommand
    {
        public AssignTorsionReleaseAtNode1(IDatabase dbctx) : base(dbctx) { }

        public override string Execute(IList<string> parameters)
        {
            int elementId;

            try
            {
                elementId = int.Parse(parameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse AssignTorsionReleaseAtNode1 command parameters.");
            }

            IFrameElement frameElement = base.dbctx.FrameElements[elementId];

            frameElement.TorsionReleaseNode1 = true;
            return $"Torsion release at node 1 has been assigned to element with ID {frameElement.Number}.";
        }
    }
}
