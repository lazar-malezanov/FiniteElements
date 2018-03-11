using FiniteElements.Commands.Assemble.AssembleStiffnessMatrices;
using FiniteElements.Core.Contracts;
using FiniteElements.Core.Factories;
using FiniteElements.Models;
using System.Collections.Generic;

namespace FiniteElements.Commands
{
    internal class AssembleGlobalNodeStiffnessMatrix : AssembleGlobalStiffnessMatrix
    {
        public AssembleGlobalNodeStiffnessMatrix(IDatabase dbctx, IGlobalStiffnessMatrixFactory factory) : base(dbctx, factory) { }

        public override string Execute(IList<string> parameters)
        {
            if (dbctx.FrameElements.Count > 0)
            {
                GlobalStiffnessMatrix globalMatrix = factory.CreateGlobalNodeStiffnessMatrix(this.dbctx);
                this.dbctx.GlobalNodeStiffnessMatrix = globalMatrix.Assemble();

                return $"Global node stiffness matrix has been assembled.";
            }

            else
            {
                return $"There are not any springs from which to assemble the stiffness matrix.";
            }
        }
    }
}
