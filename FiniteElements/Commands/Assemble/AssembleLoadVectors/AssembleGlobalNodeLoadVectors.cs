using FiniteElements.Core.Contracts;
using FiniteElements.Core.Factories;
using FiniteElements.Models;
using System.Collections.Generic;

namespace FiniteElements.Commands.Assemble.AssembleLoadVectors
{
    internal class AssembleGlobalNodeLoadVectors : AssembleGlobalLoadVectors
    {
        public AssembleGlobalNodeLoadVectors(IDatabase dbctx, IGlobalLoadVectorFactory factory) : base(dbctx, factory) { }

        public override string Execute(IList<string> parameters)
        {
            if (this.dbctx.FrameElements.Count > 0)
            {
                GlobalLoadVector globalNodeLoad = factory.CreateGlobalNodalLoadVectors(this.dbctx);

                this.dbctx.GlobalNodeLoadVectors = globalNodeLoad.Assemble();
            }

            return $"Global nodal load vector has been assembled.";
        }
    }
}
