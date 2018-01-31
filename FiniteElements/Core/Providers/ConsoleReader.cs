using FiniteElements.Core.Contracts;
using System;

namespace FiniteElements.Core.Providers
{
    internal class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
