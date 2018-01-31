using FiniteElements.Commands.Contracts;

namespace FiniteElements.Core.Factories
{
    internal interface ICommandFactory
    {
        ICommand CreateCommand(string commandName);
    }
}
