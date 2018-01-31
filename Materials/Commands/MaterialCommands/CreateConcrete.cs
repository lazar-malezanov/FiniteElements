using Bytes2you.Validation;
using Materials.Commands.Contracts;
using Materials.Contracts;
using Materials.Core.Factories;
using Materials.Materials;
using System.Collections.Generic;

namespace Materials.Commands.SectionCommands
{
    internal class CreateConcrete : ICommand
    {
        private readonly IMaterialFactory factory;

        public CreateConcrete(IMaterialFactory factory)
        {
            Guard.WhenArgument(factory, "factory").IsNull().Throw();

            this.factory = factory;
        }

        public IMaterialFromLibrary Execute(IList<string> parameters)
        {
            string concreteType = parameters[0]; 

            IMaterialFromLibrary concrete = new Concrete(concreteType);
            return concrete;
        }
    }
}
