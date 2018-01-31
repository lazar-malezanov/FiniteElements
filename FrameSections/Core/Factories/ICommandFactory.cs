using FrameSections.Commands.Contracts;

namespace FrameSections.Core.Factories
{
    internal interface ICommandFactory
    {
        ICommand CreateCommand(string commandName);
    }
}
