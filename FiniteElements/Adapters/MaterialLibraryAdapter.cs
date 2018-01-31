using Bytes2you.Validation;
using FiniteElements.ContractsForExternalLibraries;
using FiniteElements.Models.Contracts;
using Materials;
using Materials.Contracts;
using System.Collections.Generic;

namespace FiniteElements.Adapters
{
    internal class MaterialLibraryAdapter : IExternalMaterialLibrary
    {
        private readonly IMaterialLibrary materialLibrary;

        public MaterialLibraryAdapter(IMaterialLibrary materialLibrary)
        {
            Guard.WhenArgument(materialLibrary, "materialLibrary").IsNull().Throw();

            this.materialLibrary = materialLibrary;
        }

        public IMaterial WithParameters(IList<string> parameters)
        {
            Guard.WhenArgument(parameters, "parameters").IsNull().Throw();

            IMaterialFromLibrary externalMaterial = this.materialLibrary.WithParameters(parameters);
            IMaterial internalMaterial = new MaterialAdapter(externalMaterial);
           
            return internalMaterial;
        }
    }
}
