using FrameSections.Contracts;
using System.Collections.Generic;

namespace FrameSections.Commands.Contracts
{
    internal interface ICommand
    {
        ISection Execute(IList<string> parameters);
    }
}
