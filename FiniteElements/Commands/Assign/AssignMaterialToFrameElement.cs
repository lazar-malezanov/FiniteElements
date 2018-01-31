using FiniteElements.Core.Contracts;
using FiniteElements.Models.Contracts;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Assign
{
    internal class AssignMaterialToFrameElement : AssignCommand
    {
        public AssignMaterialToFrameElement(IDatabase dbctx) : base(dbctx) { }

        public override string Execute(IList<string> parameters)
        {
            int materialId;
            int elementId;
            
            try
            {
                materialId = int.Parse(parameters[0]);
                elementId = int.Parse(parameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse AssignMaterialToFrameElement command parameters.");
            }

            IFrameElement frameElement = base.dbctx.FrameElements[elementId];
            IMaterial frameMaterial = base.dbctx.Materials[materialId];

            frameElement.MaterialProp = frameMaterial;
            return $"Material with ID {frameMaterial.Number} has been assigned to element with ID {frameElement.Number}.";
        }
    }
}
