namespace FiniteElements.Core.Contracts
{
    internal interface IWriter
    {
        void WriteMessage(string message);

        void WriteError(string message);
    }
}
