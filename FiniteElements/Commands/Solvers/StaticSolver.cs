using System;
using System.Collections.Generic;
using FiniteElements.Core.Contracts;
using MathNet.Numerics.LinearAlgebra;

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
                    Matrix<double> temp = this.dbctx.GlobalStiffnessMatrix.Inverse();
                    this.dbctx.ResultNodalDisplacementVectors.Add(i, temp * this.dbctx.GlobalLoadVectors[i]);
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
