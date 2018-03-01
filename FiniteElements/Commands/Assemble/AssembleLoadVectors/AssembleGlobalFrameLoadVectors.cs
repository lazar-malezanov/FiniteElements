using FiniteElements.Core.Contracts;
using FiniteElements.Core.Factories;
using FiniteElements.Models;
using System.Collections.Generic;

namespace FiniteElements.Commands.Assemble.AssembleLoadVectors
{
    internal class AssembleGlobalFrameLoadVectors : AssembleGlobalLoadVectors
    {
        public AssembleGlobalFrameLoadVectors(IDatabase dbctx, IGlobalLoadVectorFactory factory) : base(dbctx, factory) { }

        public override string Execute(IList<string> parameters)
        {
            if (this.dbctx.FrameElements.Count > 0)
            {
                GlobalLoadVector globalFrameLoad = factory.CreateGlobalFrameLoadVectors(this.dbctx);

                this.dbctx.GlobalFrameLoadVectors = globalFrameLoad.Assemble();
            }

            return $"Global frame load vector has been assembled.";
        }
    }
}
