using FiniteElements.Core.Contracts;
using System;

namespace FiniteElements.Core.Providers
{
    internal class ConsoleWriter : IWriter
    {
        public void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void WriteError(string message)
        {
            Console.WriteLine(message);
        }
    }
}
