using FiniteElements.Core.Contracts;
using FiniteElements.Models;

namespace FiniteElements.Core.Factories
{
    internal class GlobalStiffnessMatrixFactory : IGlobalStiffnessMatrixFactory
    {
        public GlobalStiffnessMatrix CreateGlobalFrameStiffnessMatrix(IDatabase dbctx)
        {
            return new GlobalFrameStiffnessMatrix(dbctx);
        }
    }
}
