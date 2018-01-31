using Bytes2you.Validation;
using Materials.Commands.Contracts;
using Materials.Contracts;
using Materials.Core.Factories;
using Materials.Materials;
using System.Collections.Generic;

namespace Materials.Commands.SectionCommands
{
    internal class CreateRebarSteel : ICommand
    {
        private readonly IMaterialFactory factory;

        public CreateRebarSteel(IMaterialFactory factory)
        {
            Guard.WhenArgument(factory, "factory").IsNull().Throw();

            this.factory = factory;
        }

        public IMaterialFromLibrary Execute(IList<string> parameters)
        {
            string rebarSteelType = parameters[0];

            IMaterialFromLibrary rebarSteel = new RebarSteel(rebarSteelType);
            return rebarSteel;
        }
    }
}
