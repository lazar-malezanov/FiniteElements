using Bytes2you.Validation;
using Materials.Contracts;
using Materials.Core.Contracts;  

namespace Materials.Core.Providers
{
    internal class CommandProcessor : ICommandProcessor
    {
        private readonly IParser parser;

        public CommandProcessor(IParser parser)
        {
            Guard.WhenArgument(parser, "parser").IsNull().Throw();

            this.parser = parser;
        }

        public IMaterialFromLibrary ProcessCommand(string commandAsString)
        {
            Guard.WhenArgument(commandAsString, "commandAsString").IsNullOrWhiteSpace().Throw();            

            var command = this.parser.ParseCommand(commandAsString);
            var parameters = this.parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            return executionResult;
        }
    }
}
