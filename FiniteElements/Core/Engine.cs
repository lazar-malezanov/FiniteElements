using Bytes2you.Validation;
using FiniteElements.Core.Contracts;
using System;

namespace FiniteElements.Core
{
    internal class Engine : IEngine
    {
        private const string TerminationCommand = "Exit";

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandProcessor commandProcessor;

        public Engine(IReader reader, IWriter writer, ICommandProcessor commandProcessor)
        {
            Guard.WhenArgument(reader, "reader").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();
            Guard.WhenArgument(commandProcessor, "commandProcessor").IsNull().Throw();

            this.reader = reader;
            this.writer = writer;
            this.commandProcessor = commandProcessor;
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.reader.ReadLine();

                    if (commandAsString.ToLower() == TerminationCommand.ToLower())
                    {
                        break;
                    }

                    string executionResult = this.commandProcessor.ProcessCommand(commandAsString);

                    writer.WriteMessage(executionResult);
                }
                catch (Exception ex)
                {
                    writer.WriteError(ex.Message);
                }
            }
        }
    }
}
