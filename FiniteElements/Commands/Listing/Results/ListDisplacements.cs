using FiniteElements.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiniteElements.Commands.Listing.Results
{
    internal class ListDisplacements : ListCommand
    {
        public ListDisplacements(IDatabase dbctx) : base(dbctx) { }

        public override string Execute(IList<string> parameters)
        {            
            var result = new StringBuilder();

            foreach (var displacement in this.dbctx.ResultNodalDisplacementVectors)
            {
                result.AppendLine($"{displacement:f2}");
            }

            return result.ToString();
        }
    }
}
