using Bytes2you.Validation;
using FiniteElements.Commands.Contracts;
using FiniteElements.Core.Contracts;
using FiniteElements.Models.ServiceClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiniteElements.Commands
{
    internal class GenerateLocalFrameStiffnessMatrices : ICommand
    {
        private readonly IDatabase dbctx;

        public GenerateLocalFrameStiffnessMatrices(IDatabase dbctx)
        {
            Guard.WhenArgument(dbctx, "dbctx").IsNull().Throw();

            this.dbctx = dbctx;
        }

        public string Execute(IList<string> parameters)
        {
            foreach (var element in this.dbctx.FrameElements)
            {
                element.LocalMatrix = FrameService.GenerateLocalMatrix(element);
            }

            return $"Local stiffness matrices generatex.";
        }
    }
}
