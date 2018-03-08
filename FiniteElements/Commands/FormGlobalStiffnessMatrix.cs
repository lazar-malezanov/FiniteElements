using Bytes2you.Validation;
using FiniteElements.Commands.Contracts;
using FiniteElements.Core.Contracts;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands
{
    internal class FormGlobalStiffnessMatrix : ICommand
    {
        private readonly IDatabase dbctx;

        public FormGlobalStiffnessMatrix(IDatabase dbctx)
        {
            Guard.WhenArgument(dbctx, "dbctx").IsNull().Throw();

            this.dbctx = dbctx;
        }

        public string Execute(IList<string> parameters)
        {
            for (int i = 0; i < this.dbctx.GlobalStiffnessMatrices.Count; i++)
            {
                if (i == 0)
                {
                    this.dbctx.GlobalStiffnessMatrix = this.dbctx.GlobalStiffnessMatrices[i];
                }

                else
                {
                    this.dbctx.GlobalStiffnessMatrix += this.dbctx.GlobalStiffnessMatrices[i];
                }
            }

            foreach (var node in this.dbctx.Supports)
            {
                if (node.XSupport == true)
                {
                    this.dbctx.GlobalStiffnessMatrix[6 * (int)node.Number + 0, 6 * (int)node.Number + 0] = double.MaxValue;
                }

                if (node.YSupport == true)
                {
                    this.dbctx.GlobalStiffnessMatrix[6 * (int)node.Number + 1, 6 * (int)node.Number + 1] = double.MaxValue;
                }

                if (node.ZSupport == true)
                {
                    this.dbctx.GlobalStiffnessMatrix[6 * (int)node.Number + 2, 6 * (int)node.Number + 2] = double.MaxValue;
                }

                if (node.RxSupport == true)
                {
                    this.dbctx.GlobalStiffnessMatrix[6 * (int)node.Number + 3, 6 * (int)node.Number + 3] = double.MaxValue;
                }

                if (node.RzSupport == true)
                {
                    this.dbctx.GlobalStiffnessMatrix[6 * (int)node.Number + 4, 6 * (int)node.Number + 4] = double.MaxValue;
                }

                if (node.RySupport == true)
                {
                    this.dbctx.GlobalStiffnessMatrix[6 * (int)node.Number + 5, 6 * (int)node.Number + 5] = double.MaxValue;
                }            
            }

            return $"Global stiffness matrix is ready.";
        }
    }
}
