using FrameSections.Commands.Contracts;
using System.Collections.Generic;

namespace FrameSections.Core.Contracts
{
    internal interface IParser
    {
        ICommand ParseCommand(string fullCommand);

        IList<string> ParseParameters(string fullCommand);
    }
}
