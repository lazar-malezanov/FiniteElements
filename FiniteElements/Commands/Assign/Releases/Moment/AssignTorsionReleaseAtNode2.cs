using FiniteElements.Core.Contracts;
using FiniteElements.Models.Contracts;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Assign.Releases
{
    internal class AssignTorsionReleaseAtNode2 : AssignCommand
    {
        public AssignTorsionReleaseAtNode2(IDatabase dbctx) : base(dbctx) { }

        public override string Execute(IList<string> parameters)
        {
            int elementId;

            try
            {
                elementId = int.Parse(parameters[0]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse AssignTorsionReleaseAtNode2 command parameters.");
            }

            IFrameElement frameElement = base.dbctx.FrameElements[elementId];

            frameElement.TorsionReleaseNode2 = true;
            return $"Torsion release at node 2 has been assigned to element with ID {frameElement.Number}.";
        }
    }
}
