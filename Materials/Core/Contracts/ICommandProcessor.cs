using Materials.Contracts;

namespace Materials.Core.Contracts
{
    internal interface ICommandProcessor
    {
        IMaterialFromLibrary ProcessCommand(string commandAsString);
    }
}
