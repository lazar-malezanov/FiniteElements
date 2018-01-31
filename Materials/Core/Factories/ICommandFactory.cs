using Materials.Commands.Contracts;

namespace Materials.Core.Factories
{
    internal interface ICommandFactory
    {
        ICommand CreateCommand(string commandName);
    }
}
