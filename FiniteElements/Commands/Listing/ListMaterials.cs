﻿using FiniteElements.Core.Contracts;
using FiniteElements.Models.Contracts;
using FiniteElements.Models.ServiceClasses;
using System.Collections.Generic;
using System.Text;

namespace FiniteElements.Commands.Listing
{
    internal class ListMaterials : ListCommand
    {
        public ListMaterials(IDatabase dbctx) : base(dbctx) { }

        public override string Execute(IList<string> parameters)
        {
            List<IMaterial> materials = base.dbctx.Materials;
            var result = new StringBuilder();

            foreach (var material in materials)
            {
                result.AppendLine(MaterialService.AsString(material)); 
            }

            return result.ToString();
        }
    }
}
