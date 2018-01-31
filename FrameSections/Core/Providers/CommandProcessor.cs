using Bytes2you.Validation;
using FrameSections.Contracts;
using FrameSections.Core.Contracts;

namespace FrameSections.Core.Providers
{
    internal class CommandProcessor : ICommandProcessor
    {
        private readonly IParser parser;

        public CommandProcessor(IParser parser)
        {
            Guard.WhenArgument(parser, "parser").IsNull().Throw();

            this.parser = parser;
        }

        public ISection ProcessCommand(string commandAsString)
        {
            Guard.WhenArgument(commandAsString, "commandAsString").IsNullOrWhiteSpace().Throw();            

            var command = this.parser.ParseCommand(commandAsString);
            var parameters = this.parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            return executionResult;
        }
    }
}
