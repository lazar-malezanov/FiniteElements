using Bytes2you.Validation;
using FiniteElements.Core.Contracts;
using MathNet.Numerics.LinearAlgebra;
using System.Collections.Generic;

namespace FiniteElements.Models
{
    internal abstract class GlobalLoadVector
    {
        protected IDatabase dbctx;

        protected GlobalLoadVector(IDatabase dbctx)
        {
            Guard.WhenArgument(dbctx, "dbctx").IsNull().Throw();
            this.dbctx = dbctx;
        }

        public abstract Dictionary<int, Vector<double>> Assemble();
    }
}
