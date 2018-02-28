using Bytes2you.Validation;
using FiniteElements.Commands.Contracts;
using FiniteElements.Core.Contracts;
using FiniteElements.Core.Factories;
using FiniteElements.Models;
using System.Collections.Generic;

namespace FiniteElements.Commands
{
    internal class AssembleGlobalFrameStiffnessMatrixCommand : ICommand
    {
        private IDatabase dbctx;
        private IGlobalStiffnessMatrixFactory factory;

        public AssembleGlobalFrameStiffnessMatrixCommand(IDatabase dbctx, IGlobalStiffnessMatrixFactory factory)
        {
            Guard.WhenArgument(dbctx, "dbctx").IsNull().Throw();
            Guard.WhenArgument(factory, "factory").IsNull().Throw();

            this.dbctx = dbctx;
            this.factory = factory;
        }

        public string Execute(IList<string> parameters)
        {
            GlobalStiffnessMatrix globalMatrix = factory.CreateGlobalFrameStiffnessMatrix(this.dbctx);
            this.dbctx.GlobalStiffnessMatrices.Add(globalMatrix.Assemble());

            return $"Global frame stiffness matrix has been assembled.";
        }
    }
}
