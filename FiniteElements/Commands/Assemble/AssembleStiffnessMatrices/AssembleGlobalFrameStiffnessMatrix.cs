using FiniteElements.Core.Contracts;
using FiniteElements.Core.Factories;
using FiniteElements.Models;
using System.Collections.Generic;

namespace FiniteElements.Commands.Assemble.AssembleStiffnessMatrices
{
    internal class AssembleGlobalFrameStiffnessMatrix : AssembleGlobalStiffnessMatrix
    {
        public AssembleGlobalFrameStiffnessMatrix(IDatabase dbctx, IGlobalStiffnessMatrixFactory factory) : base(dbctx, factory) { }

        public override string Execute(IList<string> parameters)
        {
            if (dbctx.FrameElements.Count > 0)
            {
                GlobalStiffnessMatrix globalMatrix = factory.CreateGlobalFrameStiffnessMatrix(this.dbctx);
                this.dbctx.GlobalStiffnessMatrices.Add(globalMatrix.Assemble());

                return $"Global frame stiffness matrix has been assembled.";
            }

            else
            {
                return $"There are no frame elements from which to assemble the stiffness matrix.";
            }
        }
    }
}
