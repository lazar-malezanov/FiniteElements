using Bytes2you.Validation;
using FiniteElements.ContractsForExternalLibraries;
using FiniteElements.Models.Contracts;
using FrameSections;
using FrameSections.Contracts;
using System.Collections.Generic;

namespace FiniteElements.Adapters
{
    internal class FrameSectionLibraryAdapter : IExternalFrameSectionLibrary
    {
        private readonly IFrameSectionLibrary frameSectionLibrary;

        public FrameSectionLibraryAdapter(IFrameSectionLibrary frameSectionLibrary)
        {
            Guard.WhenArgument(frameSectionLibrary, "frameSectionLibrary").IsNull().Throw();

            this.frameSectionLibrary = frameSectionLibrary;
        }

        public IFrameSection WithParameters(IList<string> parameters)
        {
            Guard.WhenArgument(parameters, "parameters").IsNull().Throw();

            ISection externalSection = this.frameSectionLibrary.WithParameters(parameters);
            IFrameSection internalSection = new FrameSectionAdapter(externalSection);

            return internalSection; 
        }
    }
}
