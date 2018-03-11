using FiniteElements.Core.Contracts;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace FiniteElements.Models
{
    internal class GlobalFrameStiffnessMatrix : GlobalStiffnessMatrix
    {
        public GlobalFrameStiffnessMatrix(IDatabase dbctx) : base(dbctx) { }

        public override Matrix<double> Assemble()
        {
            int matrixDimension = this.dbctx.Nodes.Count * 6;
            Matrix<double> globalMatrix = SparseMatrix.Create(matrixDimension, matrixDimension, 0.0);

            foreach (var element in this.dbctx.FrameElements)
            {
                //Top Left Local
                globalMatrix[6 * element.Node1.Number + 0, 6 * element.Node1.Number + 0] += element.GlobalMatrix[0, 0];
                globalMatrix[6 * element.Node1.Number + 1, 6 * element.Node1.Number + 0] += element.GlobalMatrix[1, 0];
                globalMatrix[6 * element.Node1.Number + 2, 6 * element.Node1.Number + 0] += element.GlobalMatrix[2, 0];
                globalMatrix[6 * element.Node1.Number + 3, 6 * element.Node1.Number + 0] += element.GlobalMatrix[3, 0];
                globalMatrix[6 * element.Node1.Number + 4, 6 * element.Node1.Number + 0] += element.GlobalMatrix[4, 0];
                globalMatrix[6 * element.Node1.Number + 5, 6 * element.Node1.Number + 0] += element.GlobalMatrix[5, 0];

                globalMatrix[6 * element.Node1.Number + 0, 6 * element.Node1.Number + 1] += element.GlobalMatrix[0, 1];
                globalMatrix[6 * element.Node1.Number + 1, 6 * element.Node1.Number + 1] += element.GlobalMatrix[1, 1];
                globalMatrix[6 * element.Node1.Number + 2, 6 * element.Node1.Number + 1] += element.GlobalMatrix[2, 1];
                globalMatrix[6 * element.Node1.Number + 3, 6 * element.Node1.Number + 1] += element.GlobalMatrix[3, 1];
                globalMatrix[6 * element.Node1.Number + 4, 6 * element.Node1.Number + 1] += element.GlobalMatrix[4, 1];
                globalMatrix[6 * element.Node1.Number + 5, 6 * element.Node1.Number + 1] += element.GlobalMatrix[5, 1];

                globalMatrix[6 * element.Node1.Number + 0, 6 * element.Node1.Number + 2] += element.GlobalMatrix[0, 2];
                globalMatrix[6 * element.Node1.Number + 1, 6 * element.Node1.Number + 2] += element.GlobalMatrix[1, 2];
                globalMatrix[6 * element.Node1.Number + 2, 6 * element.Node1.Number + 2] += element.GlobalMatrix[2, 2];
                globalMatrix[6 * element.Node1.Number + 3, 6 * element.Node1.Number + 2] += element.GlobalMatrix[3, 2];
                globalMatrix[6 * element.Node1.Number + 4, 6 * element.Node1.Number + 2] += element.GlobalMatrix[4, 2];
                globalMatrix[6 * element.Node1.Number + 5, 6 * element.Node1.Number + 2] += element.GlobalMatrix[5, 2];

                globalMatrix[6 * element.Node1.Number + 0, 6 * element.Node1.Number + 3] += element.GlobalMatrix[0, 3];
                globalMatrix[6 * element.Node1.Number + 1, 6 * element.Node1.Number + 3] += element.GlobalMatrix[1, 3];
                globalMatrix[6 * element.Node1.Number + 2, 6 * element.Node1.Number + 3] += element.GlobalMatrix[2, 3];
                globalMatrix[6 * element.Node1.Number + 3, 6 * element.Node1.Number + 3] += element.GlobalMatrix[3, 3];
                globalMatrix[6 * element.Node1.Number + 4, 6 * element.Node1.Number + 3] += element.GlobalMatrix[4, 3];
                globalMatrix[6 * element.Node1.Number + 5, 6 * element.Node1.Number + 3] += element.GlobalMatrix[5, 3];

                globalMatrix[6 * element.Node1.Number + 0, 6 * element.Node1.Number + 4] += element.GlobalMatrix[0, 4];
                globalMatrix[6 * element.Node1.Number + 1, 6 * element.Node1.Number + 4] += element.GlobalMatrix[1, 4];
                globalMatrix[6 * element.Node1.Number + 2, 6 * element.Node1.Number + 4] += element.GlobalMatrix[2, 4];
                globalMatrix[6 * element.Node1.Number + 3, 6 * element.Node1.Number + 4] += element.GlobalMatrix[3, 4];
                globalMatrix[6 * element.Node1.Number + 4, 6 * element.Node1.Number + 4] += element.GlobalMatrix[4, 4];
                globalMatrix[6 * element.Node1.Number + 5, 6 * element.Node1.Number + 4] += element.GlobalMatrix[5, 4];

                globalMatrix[6 * element.Node1.Number + 0, 6 * element.Node1.Number + 5] += element.GlobalMatrix[0, 5];
                globalMatrix[6 * element.Node1.Number + 1, 6 * element.Node1.Number + 5] += element.GlobalMatrix[1, 5];
                globalMatrix[6 * element.Node1.Number + 2, 6 * element.Node1.Number + 5] += element.GlobalMatrix[2, 5];
                globalMatrix[6 * element.Node1.Number + 3, 6 * element.Node1.Number + 5] += element.GlobalMatrix[3, 5];
                globalMatrix[6 * element.Node1.Number + 4, 6 * element.Node1.Number + 5] += element.GlobalMatrix[4, 5];
                globalMatrix[6 * element.Node1.Number + 5, 6 * element.Node1.Number + 5] += element.GlobalMatrix[5, 5];

                //Bottom Right Local
                globalMatrix[6 * element.Node2.Number + 0, 6 * element.Node2.Number + 0] += element.GlobalMatrix[6, 6];
                globalMatrix[6 * element.Node2.Number + 1, 6 * element.Node2.Number + 0] += element.GlobalMatrix[7, 6];
                globalMatrix[6 * element.Node2.Number + 2, 6 * element.Node2.Number + 0] += element.GlobalMatrix[8, 6];
                globalMatrix[6 * element.Node2.Number + 3, 6 * element.Node2.Number + 0] += element.GlobalMatrix[9, 6];
                globalMatrix[6 * element.Node2.Number + 4, 6 * element.Node2.Number + 0] += element.GlobalMatrix[10, 6];
                globalMatrix[6 * element.Node2.Number + 5, 6 * element.Node2.Number + 0] += element.GlobalMatrix[11, 6];

                globalMatrix[6 * element.Node2.Number + 0, 6 * element.Node2.Number + 1] += element.GlobalMatrix[6, 7];
                globalMatrix[6 * element.Node2.Number + 1, 6 * element.Node2.Number + 1] += element.GlobalMatrix[7, 7];
                globalMatrix[6 * element.Node2.Number + 2, 6 * element.Node2.Number + 1] += element.GlobalMatrix[8, 7];
                globalMatrix[6 * element.Node2.Number + 3, 6 * element.Node2.Number + 1] += element.GlobalMatrix[9, 7];
                globalMatrix[6 * element.Node2.Number + 4, 6 * element.Node2.Number + 1] += element.GlobalMatrix[10, 7];
                globalMatrix[6 * element.Node2.Number + 5, 6 * element.Node2.Number + 1] += element.GlobalMatrix[11, 7];

                globalMatrix[6 * element.Node2.Number + 0, 6 * element.Node2.Number + 2] += element.GlobalMatrix[6, 8];
                globalMatrix[6 * element.Node2.Number + 1, 6 * element.Node2.Number + 2] += element.GlobalMatrix[7, 8];
                globalMatrix[6 * element.Node2.Number + 2, 6 * element.Node2.Number + 2] += element.GlobalMatrix[8, 8];
                globalMatrix[6 * element.Node2.Number + 3, 6 * element.Node2.Number + 2] += element.GlobalMatrix[9, 8];
                globalMatrix[6 * element.Node2.Number + 4, 6 * element.Node2.Number + 2] += element.GlobalMatrix[10, 8];
                globalMatrix[6 * element.Node2.Number + 5, 6 * element.Node2.Number + 2] += element.GlobalMatrix[11, 8];

                globalMatrix[6 * element.Node2.Number + 0, 6 * element.Node2.Number + 3] += element.GlobalMatrix[6, 9];
                globalMatrix[6 * element.Node2.Number + 1, 6 * element.Node2.Number + 3] += element.GlobalMatrix[7, 9];
                globalMatrix[6 * element.Node2.Number + 2, 6 * element.Node2.Number + 3] += element.GlobalMatrix[8, 9];
                globalMatrix[6 * element.Node2.Number + 3, 6 * element.Node2.Number + 3] += element.GlobalMatrix[9, 9];
                globalMatrix[6 * element.Node2.Number + 4, 6 * element.Node2.Number + 3] += element.GlobalMatrix[10, 9];
                globalMatrix[6 * element.Node2.Number + 5, 6 * element.Node2.Number + 3] += element.GlobalMatrix[11, 9];

                globalMatrix[6 * element.Node2.Number + 0, 6 * element.Node2.Number + 4] += element.GlobalMatrix[6, 10];
                globalMatrix[6 * element.Node2.Number + 1, 6 * element.Node2.Number + 4] += element.GlobalMatrix[7, 10];
                globalMatrix[6 * element.Node2.Number + 2, 6 * element.Node2.Number + 4] += element.GlobalMatrix[8, 10];
                globalMatrix[6 * element.Node2.Number + 3, 6 * element.Node2.Number + 4] += element.GlobalMatrix[9, 10];
                globalMatrix[6 * element.Node2.Number + 4, 6 * element.Node2.Number + 4] += element.GlobalMatrix[10, 10];
                globalMatrix[6 * element.Node2.Number + 5, 6 * element.Node2.Number + 4] += element.GlobalMatrix[11, 10];

                globalMatrix[6 * element.Node2.Number + 0, 6 * element.Node2.Number + 5] += element.GlobalMatrix[6, 11];
                globalMatrix[6 * element.Node2.Number + 1, 6 * element.Node2.Number + 5] += element.GlobalMatrix[7, 11];
                globalMatrix[6 * element.Node2.Number + 2, 6 * element.Node2.Number + 5] += element.GlobalMatrix[8, 11];
                globalMatrix[6 * element.Node2.Number + 3, 6 * element.Node2.Number + 5] += element.GlobalMatrix[9, 11];
                globalMatrix[6 * element.Node2.Number + 4, 6 * element.Node2.Number + 5] += element.GlobalMatrix[10, 11];
                globalMatrix[6 * element.Node2.Number + 5, 6 * element.Node2.Number + 5] += element.GlobalMatrix[11, 11];

                //Top Right Local
                globalMatrix[6 * element.Node1.Number + 0, 6 * element.Node2.Number + 0] += element.GlobalMatrix[0, 6];
                globalMatrix[6 * element.Node1.Number + 1, 6 * element.Node2.Number + 0] += element.GlobalMatrix[1, 6];
                globalMatrix[6 * element.Node1.Number + 2, 6 * element.Node2.Number + 0] += element.GlobalMatrix[2, 6];
                globalMatrix[6 * element.Node1.Number + 3, 6 * element.Node2.Number + 0] += element.GlobalMatrix[3, 6];
                globalMatrix[6 * element.Node1.Number + 4, 6 * element.Node2.Number + 0] += element.GlobalMatrix[4, 6];
                globalMatrix[6 * element.Node1.Number + 5, 6 * element.Node2.Number + 0] += element.GlobalMatrix[5, 6];

                globalMatrix[6 * element.Node1.Number + 0, 6 * element.Node2.Number + 1] += element.GlobalMatrix[0, 7];
                globalMatrix[6 * element.Node1.Number + 1, 6 * element.Node2.Number + 1] += element.GlobalMatrix[1, 7];
                globalMatrix[6 * element.Node1.Number + 2, 6 * element.Node2.Number + 1] += element.GlobalMatrix[2, 7];
                globalMatrix[6 * element.Node1.Number + 3, 6 * element.Node2.Number + 1] += element.GlobalMatrix[3, 7];
                globalMatrix[6 * element.Node1.Number + 4, 6 * element.Node2.Number + 1] += element.GlobalMatrix[4, 7];
                globalMatrix[6 * element.Node1.Number + 5, 6 * element.Node2.Number + 1] += element.GlobalMatrix[5, 7];

                globalMatrix[6 * element.Node1.Number + 0, 6 * element.Node2.Number + 2] += element.GlobalMatrix[0, 8];
                globalMatrix[6 * element.Node1.Number + 1, 6 * element.Node2.Number + 2] += element.GlobalMatrix[1, 8];
                globalMatrix[6 * element.Node1.Number + 2, 6 * element.Node2.Number + 2] += element.GlobalMatrix[2, 8];
                globalMatrix[6 * element.Node1.Number + 3, 6 * element.Node2.Number + 2] += element.GlobalMatrix[3, 8];
                globalMatrix[6 * element.Node1.Number + 4, 6 * element.Node2.Number + 2] += element.GlobalMatrix[4, 8];
                globalMatrix[6 * element.Node1.Number + 5, 6 * element.Node2.Number + 2] += element.GlobalMatrix[5, 8];

                globalMatrix[6 * element.Node1.Number + 0, 6 * element.Node2.Number + 3] += element.GlobalMatrix[0, 9];
                globalMatrix[6 * element.Node1.Number + 1, 6 * element.Node2.Number + 3] += element.GlobalMatrix[1, 9];
                globalMatrix[6 * element.Node1.Number + 2, 6 * element.Node2.Number + 3] += element.GlobalMatrix[2, 9];
                globalMatrix[6 * element.Node1.Number + 3, 6 * element.Node2.Number + 3] += element.GlobalMatrix[3, 9];
                globalMatrix[6 * element.Node1.Number + 4, 6 * element.Node2.Number + 3] += element.GlobalMatrix[4, 9];
                globalMatrix[6 * element.Node1.Number + 5, 6 * element.Node2.Number + 3] += element.GlobalMatrix[5, 9];

                globalMatrix[6 * element.Node1.Number + 0, 6 * element.Node2.Number + 4] += element.GlobalMatrix[0, 10];
                globalMatrix[6 * element.Node1.Number + 1, 6 * element.Node2.Number + 4] += element.GlobalMatrix[1, 10];
                globalMatrix[6 * element.Node1.Number + 2, 6 * element.Node2.Number + 4] += element.GlobalMatrix[2, 10];
                globalMatrix[6 * element.Node1.Number + 3, 6 * element.Node2.Number + 4] += element.GlobalMatrix[3, 10];
                globalMatrix[6 * element.Node1.Number + 4, 6 * element.Node2.Number + 4] += element.GlobalMatrix[4, 10];
                globalMatrix[6 * element.Node1.Number + 5, 6 * element.Node2.Number + 4] += element.GlobalMatrix[5, 10];

                globalMatrix[6 * element.Node1.Number + 0, 6 * element.Node2.Number + 5] += element.GlobalMatrix[0, 11];
                globalMatrix[6 * element.Node1.Number + 1, 6 * element.Node2.Number + 5] += element.GlobalMatrix[1, 11];
                globalMatrix[6 * element.Node1.Number + 2, 6 * element.Node2.Number + 5] += element.GlobalMatrix[2, 11];
                globalMatrix[6 * element.Node1.Number + 3, 6 * element.Node2.Number + 5] += element.GlobalMatrix[3, 11];
                globalMatrix[6 * element.Node1.Number + 4, 6 * element.Node2.Number + 5] += element.GlobalMatrix[4, 11];
                globalMatrix[6 * element.Node1.Number + 5, 6 * element.Node2.Number + 5] += element.GlobalMatrix[5, 11];

                //Bottom Left Local
                globalMatrix[6 * element.Node2.Number + 0, 6 * element.Node1.Number + 0] += element.GlobalMatrix[6, 0];
                globalMatrix[6 * element.Node2.Number + 1, 6 * element.Node1.Number + 0] += element.GlobalMatrix[7, 0];
                globalMatrix[6 * element.Node2.Number + 2, 6 * element.Node1.Number + 0] += element.GlobalMatrix[8, 0];
                globalMatrix[6 * element.Node2.Number + 3, 6 * element.Node1.Number + 0] += element.GlobalMatrix[9, 0];
                globalMatrix[6 * element.Node2.Number + 4, 6 * element.Node1.Number + 0] += element.GlobalMatrix[10, 0];
                globalMatrix[6 * element.Node2.Number + 5, 6 * element.Node1.Number + 0] += element.GlobalMatrix[11, 0];

                globalMatrix[6 * element.Node2.Number + 0, 6 * element.Node1.Number + 1] += element.GlobalMatrix[6, 1];
                globalMatrix[6 * element.Node2.Number + 1, 6 * element.Node1.Number + 1] += element.GlobalMatrix[7, 1];
                globalMatrix[6 * element.Node2.Number + 2, 6 * element.Node1.Number + 1] += element.GlobalMatrix[8, 1];
                globalMatrix[6 * element.Node2.Number + 3, 6 * element.Node1.Number + 1] += element.GlobalMatrix[9, 1];
                globalMatrix[6 * element.Node2.Number + 4, 6 * element.Node1.Number + 1] += element.GlobalMatrix[10, 1];
                globalMatrix[6 * element.Node2.Number + 5, 6 * element.Node1.Number + 1] += element.GlobalMatrix[11, 1];

                globalMatrix[6 * element.Node2.Number + 0, 6 * element.Node1.Number + 2] += element.GlobalMatrix[6, 2];
                globalMatrix[6 * element.Node2.Number + 1, 6 * element.Node1.Number + 2] += element.GlobalMatrix[7, 2];
                globalMatrix[6 * element.Node2.Number + 2, 6 * element.Node1.Number + 2] += element.GlobalMatrix[8, 2];
                globalMatrix[6 * element.Node2.Number + 3, 6 * element.Node1.Number + 2] += element.GlobalMatrix[9, 2];
                globalMatrix[6 * element.Node2.Number + 4, 6 * element.Node1.Number + 2] += element.GlobalMatrix[10, 2];
                globalMatrix[6 * element.Node2.Number + 5, 6 * element.Node1.Number + 2] += element.GlobalMatrix[11, 2];

                globalMatrix[6 * element.Node2.Number + 0, 6 * element.Node1.Number + 3] += element.GlobalMatrix[6, 3];
                globalMatrix[6 * element.Node2.Number + 1, 6 * element.Node1.Number + 3] += element.GlobalMatrix[7, 3];
                globalMatrix[6 * element.Node2.Number + 2, 6 * element.Node1.Number + 3] += element.GlobalMatrix[8, 3];
                globalMatrix[6 * element.Node2.Number + 3, 6 * element.Node1.Number + 3] += element.GlobalMatrix[9, 3];
                globalMatrix[6 * element.Node2.Number + 4, 6 * element.Node1.Number + 3] += element.GlobalMatrix[10, 3];
                globalMatrix[6 * element.Node2.Number + 5, 6 * element.Node1.Number + 3] += element.GlobalMatrix[11, 3];

                globalMatrix[6 * element.Node2.Number + 0, 6 * element.Node1.Number + 4] += element.GlobalMatrix[6, 4];
                globalMatrix[6 * element.Node2.Number + 1, 6 * element.Node1.Number + 4] += element.GlobalMatrix[7, 4];
                globalMatrix[6 * element.Node2.Number + 2, 6 * element.Node1.Number + 4] += element.GlobalMatrix[8, 4];
                globalMatrix[6 * element.Node2.Number + 3, 6 * element.Node1.Number + 4] += element.GlobalMatrix[9, 4];
                globalMatrix[6 * element.Node2.Number + 4, 6 * element.Node1.Number + 4] += element.GlobalMatrix[10, 4];
                globalMatrix[6 * element.Node2.Number + 5, 6 * element.Node1.Number + 4] += element.GlobalMatrix[11, 4];

                globalMatrix[6 * element.Node2.Number + 0, 6 * element.Node1.Number + 5] += element.GlobalMatrix[6, 5];
                globalMatrix[6 * element.Node2.Number + 1, 6 * element.Node1.Number + 5] += element.GlobalMatrix[7, 5];
                globalMatrix[6 * element.Node2.Number + 2, 6 * element.Node1.Number + 5] += element.GlobalMatrix[8, 5];
                globalMatrix[6 * element.Node2.Number + 3, 6 * element.Node1.Number + 5] += element.GlobalMatrix[9, 5];
                globalMatrix[6 * element.Node2.Number + 4, 6 * element.Node1.Number + 5] += element.GlobalMatrix[10, 5];
                globalMatrix[6 * element.Node2.Number + 5, 6 * element.Node1.Number + 5] += element.GlobalMatrix[11, 5];
            }

            return globalMatrix;
        }
    }
}
