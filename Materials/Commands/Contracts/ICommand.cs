using Materials.Contracts;
using System.Collections.Generic;

namespace Materials.Commands.Contracts
{
    internal interface ICommand
    {
        IMaterialFromLibrary Execute(IList<string> parameters);
    }
}
