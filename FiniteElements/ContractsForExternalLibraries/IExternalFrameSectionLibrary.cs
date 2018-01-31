using FiniteElements.Models.Contracts;
using System.Collections.Generic;

namespace FiniteElements.ContractsForExternalLibraries
{
    internal interface IExternalFrameSectionLibrary
    {
        IFrameSection WithParameters(IList<string> parameters);
    }
}
