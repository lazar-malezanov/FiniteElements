using Bytes2you.Validation;
using FiniteElements.Commands.Contracts;
using FiniteElements.Core.Contracts;
using FiniteElements.Core.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiniteElements.Commands.Assemble.AssembleStiffnessMatrices
{
    internal abstract class AssembleGlobalStiffnessMatrix : ICommand
    {
        protected IDatabase dbctx;
        protected IGlobalStiffnessMatrixFactory factory;

        protected AssembleGlobalStiffnessMatrix(IDatabase dbctx, IGlobalStiffnessMatrixFactory factory)
        {
            Guard.WhenArgument(dbctx, "dbctx").IsNull().Throw();
            Guard.WhenArgument(factory, "factory").IsNull().Throw();

            this.dbctx = dbctx;
            this.factory = factory;
        }

        public abstract string Execute(IList<string> parameters);       
    }
}
