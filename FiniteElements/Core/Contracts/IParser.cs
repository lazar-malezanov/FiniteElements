using FiniteElements.Commands.Contracts;
using System.Collections.Generic;

namespace FiniteElements.Core.Contracts
{
    internal interface IParser
    {
        ICommand ParseCommand(string fullCommand);

        IList<string> ParseParameters(string fullCommand);
    }
}
