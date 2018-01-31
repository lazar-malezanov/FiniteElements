using FrameSections.Contracts;
using System.Collections.Generic;

namespace FrameSections
{
    public interface IFrameSectionLibrary
    {
        ISection WithParameters(IList<string> parameters);
    }
}
