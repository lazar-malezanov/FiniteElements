using Bytes2you.Validation;
using FiniteElements.Commands.Contracts;
using FiniteElements.Core.Contracts;
using FiniteElements.Models.ServiceClasses;
using System.Collections.Generic;

namespace FiniteElements.Commands
{
    internal class GenerateGlobalFrameStiffnessMatrices : ICommand
    {
        private readonly IDatabase dbctx;

        public GenerateGlobalFrameStiffnessMatrices(IDatabase dbctx)
        {
            Guard.WhenArgument(dbctx, "dbctx").IsNull().Throw();

            this.dbctx = dbctx;
        }

        public string Execute(IList<string> parameters)
        {
            foreach (var element in this.dbctx.FrameElements)
            {
                element.GlobalMatrix = FrameService.GenerateGlobalMatrix(element);
            }

            return $"Global stiffness matrices generatex.";
        }
    }
}
