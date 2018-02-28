using Bytes2you.Validation;
using FiniteElements.Core.Contracts;
using MathNet.Numerics.LinearAlgebra;

namespace FiniteElements.Models
{
    internal abstract class GlobalStiffnessMatrix
    {
        protected IDatabase dbctx;

        protected GlobalStiffnessMatrix(IDatabase dbctx)
        {
            Guard.WhenArgument(dbctx, "dbctx").IsNull().Throw();
            this.dbctx = dbctx;
        }

        public abstract Matrix<double> Assemble(); 
    }
}
