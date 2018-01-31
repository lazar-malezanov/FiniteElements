using FrameSections.Container;
using FrameSections.Contracts;
using FrameSections.Core.Contracts;
using Ninject;
using System.Collections.Generic;

namespace FrameSections
{
    public class FrameSectionLibrary : IFrameSectionLibrary
    {
        public ISection WithParameters(IList<string> parameters) 
        {
            var kernel = new StandardKernel(new FrameSectionModule());

            string commandParameters = string.Join(" ", parameters);

            ISection executionResult = kernel.Get<ICommandProcessor>().ProcessCommand(commandParameters);
            return executionResult;
        }
    }
}
