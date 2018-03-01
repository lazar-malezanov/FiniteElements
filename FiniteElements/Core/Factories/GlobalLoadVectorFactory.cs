using FiniteElements.Core.Contracts;
using FiniteElements.Models;
using FiniteElements.Models.GlobalLoadVectors;

namespace FiniteElements.Core.Factories
{
    internal class GlobalLoadVectorFactory : IGlobalLoadVectorFactory
    {
        public GlobalLoadVector CreateGlobalFrameLoadVectors(IDatabase dbctx)
        {
            return new GlobalFrameLoadVectors(dbctx);
        }
 
        public GlobalLoadVector CreateGlobalNodalLoadVectors(IDatabase dbctx)
        {
            return new GlobalNodalLoadVectors(dbctx);
        }
    }
}
