using Bytes2you.Validation;
using FiniteElements.Core.Contracts;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiniteElements.Models
{
    internal abstract class GlobalMatrix
    {
        protected IDatabase dbctx;

        protected GlobalMatrix(IDatabase dbctx)
        {
            Guard.WhenArgument(dbctx, "dbctx").IsNull().Throw();
            this.dbctx = dbctx;
        }

        public abstract Matrix<double> Assemble(); 
    }
}
