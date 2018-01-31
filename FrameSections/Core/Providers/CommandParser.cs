using Bytes2you.Validation;
using FrameSections.Commands.Contracts;
using FrameSections.Core.Contracts;
using FrameSections.Core.Factories;
using System.Collections.Generic;
using System.Linq;

namespace FrameSections.Core.Providers
{
    internal class CommandParser : IParser
    {
        private readonly ICommandFactory commandFactory;

        public CommandParser(ICommandFactory commandFactory)
        {
            Guard.WhenArgument(commandFactory, "commandFactory").IsNull().Throw();

            this.commandFactory = commandFactory;
        }

        public ICommand ParseCommand(string fullCommand)
        {
            var commandName = fullCommand.Split()[0];

            return this.commandFactory.CreateCommand(commandName);
        }

        public IList<string> ParseParameters(string fullCommand)
        {
            var commandParts = fullCommand.Split().Skip(1).ToList();
            if (commandParts.Count == 0)
            {
                return new List<string>();
            }

            return commandParts;
        }
    }
}
