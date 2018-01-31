namespace FiniteElements.Core.Contracts
{
    internal interface ICommandProcessor
    {
        string ProcessCommand(string commandAsString);
    }
}
