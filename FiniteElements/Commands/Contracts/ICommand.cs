using System.Collections.Generic;

namespace FiniteElements.Commands.Contracts
{
    internal interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
