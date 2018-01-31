using Materials.Container;
using Materials.Contracts;
using Materials.Core.Contracts;
using Ninject;
using System.Collections.Generic;

namespace Materials
{
    public class MaterialLibrary : IMaterialLibrary
    {
        public IMaterialFromLibrary WithParameters(IList<string> parameters)
        {
            var kernel = new StandardKernel(new MaterialModule());

            string commandParameters = string.Join(" ", parameters);

            IMaterialFromLibrary executionResult = kernel.Get<ICommandProcessor>().ProcessCommand(commandParameters);
            return executionResult;
        }
    }
}
