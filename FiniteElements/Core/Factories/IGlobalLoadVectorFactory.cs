using FiniteElements.Core.Contracts;
using FiniteElements.Models;

namespace FiniteElements.Core.Factories
{
    internal interface IGlobalLoadVectorFactory
    {
        GlobalLoadVector CreateGlobalFrameLoadVectors(IDatabase dbctx);

        GlobalLoadVector CreateGlobalNodalLoadVectors(IDatabase dbctx);
    }
}
