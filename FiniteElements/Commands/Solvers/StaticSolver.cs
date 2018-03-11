using System;
using System.Collections.Generic;
using FiniteElements.Core.Contracts;

namespace FiniteElements.Commands.Solvers
{
    internal class StaticSolver : Solve
    {
        public StaticSolver(IDatabase dbctx) : base(dbctx) { }

        public override string Execute(IList<string> parameters)
        {
            try
            {
                for (int i = 0; i < this.dbctx.LoadCases.Count; i++)
                {
                    this.dbctx.ResultNodalDisplacementVectors.Add(i, this.dbctx.GlobalStiffnessMatrixWithSupports.Inverse() * this.dbctx.GlobalLoadVectors[i]);
                    this.dbctx.ResultNodalReactionVectors.Add(i, this.dbctx.GlobalStiffnessMatrix * this.dbctx.ResultNodalDisplacementVectors[i] - this.dbctx.GlobalLoadVectors[i]);
                }
            }
            catch (Exception)
            {

                throw new ArgumentException("System could not be solved, check the structure for mechanisms.");
            }
            

            return $"System solved for all load cases.";
        }
    }
}
