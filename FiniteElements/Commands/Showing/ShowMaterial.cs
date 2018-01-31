using FiniteElements.Core.Contracts;
using FiniteElements.Models.Contracts;
using FiniteElements.Models.ExtensionMethods;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Showing
{
    internal class ShowMaterial : ShowCommand
    {
        public ShowMaterial(IDatabase dbctx) : base(dbctx) { }

        public override string Execute(IList<string> parameters)
        {
            int materialId;

            try
            {
                materialId = int.Parse(parameters[0]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse ShowMaterial command parameters.");
            }

            IMaterial material = base.dbctx.Materials[materialId];
            string result = material.AsString();

            return result;
        }
    }
}
