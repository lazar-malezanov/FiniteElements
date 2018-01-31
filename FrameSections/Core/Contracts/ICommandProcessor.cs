using FrameSections.Contracts;

namespace FrameSections.Core.Contracts
{
    internal interface ICommandProcessor
    {
        ISection ProcessCommand(string commandAsString);
    }
}
