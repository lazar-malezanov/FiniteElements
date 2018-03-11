using FiniteElements.Core.Contracts;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace FiniteElements.Models.GlobalStiffnessMatrices
{
    internal class GlobalNodeStiffnessMatrix : GlobalStiffnessMatrix
    {
        public GlobalNodeStiffnessMatrix(IDatabase dbctx) : base(dbctx) { }

        public override Matrix<double> Assemble()
        {
            int matrixDimension = this.dbctx.Nodes.Count * 6;
            Matrix<double> globalMatrix = SparseMatrix.Create(matrixDimension, matrixDimension, 0.0);

            foreach (var node in this.dbctx.Springs)
            {
                globalMatrix[6 * node.Number + 0, 6 * node.Number + 0] += node.XSpring;
                globalMatrix[6 * node.Number + 1, 6 * node.Number + 1] += node.YSpring;
                globalMatrix[6 * node.Number + 2, 6 * node.Number + 2] += node.ZSpring;
                globalMatrix[6 * node.Number + 3, 6 * node.Number + 3] += node.RxSpring;
                globalMatrix[6 * node.Number + 4, 6 * node.Number + 4] += node.RzSpring;
                globalMatrix[6 * node.Number + 5, 6 * node.Number + 5] += node.RySpring;               
            }

            return globalMatrix;
        }
    }
}
