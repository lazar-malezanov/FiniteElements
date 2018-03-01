using Bytes2you.Validation;
using FiniteElements.Commands.Contracts;
using FiniteElements.Core.Contracts;
using System.Collections.Generic;

namespace FiniteElements.Commands
{
    internal class FormGlobalLoadVectors : ICommand
    {
        private readonly IDatabase dbctx;

        public FormGlobalLoadVectors(IDatabase dbctx)
        {
            Guard.WhenArgument(dbctx, "dbctx").IsNull().Throw();

            this.dbctx = dbctx;
        }

        public string Execute(IList<string> parameters)
        {
            this.dbctx.GlobalLoadVectors = this.dbctx.GlobalNodeLoadVectors;

            for (int i = 0; i < this.dbctx.LoadCases.Count; i++)
            {
                this.dbctx.GlobalLoadVectors[i] += this.dbctx.GlobalFrameLoadVectors[i];
            }

            return $"Global load vectors are ready.";
        }
    }
}
