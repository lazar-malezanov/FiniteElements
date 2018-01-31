using FiniteElements.Models.Contracts;
using System.Collections.Generic;

namespace FiniteElements.ContractsForExternalLibraries
{
    internal interface IExternalMaterialLibrary
    {
        IMaterial WithParameters(IList<string> parameters);
    }
}
