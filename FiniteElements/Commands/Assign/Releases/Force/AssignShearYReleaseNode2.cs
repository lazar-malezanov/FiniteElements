﻿using FiniteElements.Core.Contracts;
using FiniteElements.Models.Contracts;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Assign.Releases
{
    internal class AssignShearYReleaseNode2 : AssignCommand
    {
        public AssignShearYReleaseNode2(IDatabase dbctx) : base(dbctx) { }

        public override string Execute(IList<string> parameters)
        {
            int elementId;

            try
            {
                elementId = int.Parse(parameters[0]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse AssignShearYReleaseNode2 command parameters.");
            }

            IFrameElement frameElement = base.dbctx.FrameElements[elementId];

            frameElement.ShearYReleaseNode2 = true;
            return $"Shear in Y direction release at node 2 has been assigned to element with ID {frameElement.Number}.";
        }
    }
}
