using Bytes2you.Validation;
using FiniteElements.Commands.Contracts;
using FiniteElements.Core.Contracts;
using FiniteElements.Core.Factories;
using System.Collections.Generic;

namespace FiniteElements.Commands
{
    internal abstract class AssembleGlobalLoadVectors : ICommand
    {
        protected IDatabase dbctx;
        protected IGlobalLoadVectorFactory factory;

        protected AssembleGlobalLoadVectors(IDatabase dbctx, IGlobalLoadVectorFactory factory)
        {
            Guard.WhenArgument(dbctx, "dbctx").IsNull().Throw();
            Guard.WhenArgument(factory, "factory").IsNull().Throw();

            this.dbctx = dbctx;
            this.factory = factory;
        }

        public abstract string Execute(IList<string> parameters);
    }
}
