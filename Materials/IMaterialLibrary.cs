using Materials.Contracts;
using System.Collections.Generic;

namespace Materials
{
    public interface IMaterialLibrary
    {
        IMaterialFromLibrary WithParameters(IList<string> parameters);
    }
}
