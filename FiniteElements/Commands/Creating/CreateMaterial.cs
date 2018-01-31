using Bytes2you.Validation;
using FiniteElements.ContractsForExternalLibraries;
using FiniteElements.Core.Contracts;
using FiniteElements.Models.Contracts;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Creating
{
    internal class CreateMaterial : CreateCommand
    {
        private IExternalMaterialLibrary createMaterialLibrary;

        public CreateMaterial(IDatabase dbctx, IExternalMaterialLibrary createMaterialLibrary) : base(dbctx)
        {
            Guard.WhenArgument(createMaterialLibrary, "createMaterialLibrary").IsNull().Throw();

            this.createMaterialLibrary = createMaterialLibrary;
        }

        public override string Execute(IList<string> parameters)
        {
            IMaterial material;

            try
            {
                material = this.createMaterialLibrary.WithParameters(parameters);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateMaterial command parameters.");
            }

            this.dbctx.Materials.Add(material);
            material.Number = base.dbctx.Materials.Count - 1;
            return $"Material with ID {material.Number} was created.";
        }
    }
}
