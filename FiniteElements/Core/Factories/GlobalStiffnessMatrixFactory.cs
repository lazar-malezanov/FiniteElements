using FiniteElements.Core.Contracts;
using FiniteElements.Models;
using FiniteElements.Models.GlobalStiffnessMatrices;

namespace FiniteElements.Core.Factories
{
    internal class GlobalStiffnessMatrixFactory : IGlobalStiffnessMatrixFactory
    {
        public GlobalStiffnessMatrix CreateGlobalFrameStiffnessMatrix(IDatabase dbctx)
        {
            return new GlobalFrameStiffnessMatrix(dbctx);
        }

        public GlobalStiffnessMatrix CreateGlobalNodeStiffnessMatrix(IDatabase dbctx)
        {
            return new GlobalNodeStiffnessMatrix(dbctx);
        }
    }
}
