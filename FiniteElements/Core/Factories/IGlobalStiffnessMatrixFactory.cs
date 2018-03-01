using FiniteElements.Core.Contracts;
using FiniteElements.Models;

namespace FiniteElements.Core.Factories
{
    internal interface IGlobalStiffnessMatrixFactory
    {
        GlobalStiffnessMatrix CreateGlobalFrameStiffnessMatrix(IDatabase dbctx);

        GlobalStiffnessMatrix CreateGlobalNodeStiffnessMatrix(IDatabase dbctx);
    }
}
