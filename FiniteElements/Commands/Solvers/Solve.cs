using Bytes2you.Validation;
using FiniteElements.Commands.Contracts;
using FiniteElements.Core.Contracts;
using System.Collections.Generic;

namespace FiniteElements.Commands.Solvers
{
    internal abstract class Solve : ICommand
    {
        protected readonly IDatabase dbctx;

        public Solve(IDatabase dbctx)
        {
            Guard.WhenArgument(dbctx, "dbctx").IsNull().Throw();

            this.dbctx = dbctx;
        }

        public abstract string Execute(IList<string> parameters);
    }
}
