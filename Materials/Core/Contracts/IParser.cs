using Materials.Commands.Contracts;
using System.Collections.Generic;

namespace Materials.Core.Contracts
{
    internal interface IParser
    {
        ICommand ParseCommand(string fullCommand);

        IList<string> ParseParameters(string fullCommand);
    }
}
