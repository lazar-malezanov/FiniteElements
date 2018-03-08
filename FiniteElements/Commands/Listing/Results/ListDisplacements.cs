using FiniteElements.Core.Contracts;
using System.Collections.Generic;
using System.Text;

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
                
                for (int i = 0; i < displacement.Value.Count; i++)
                {
                    if (i % 6 == 0)
                    {
                        result.AppendLine($"Node {i / 6}:");
                    }
                    result.AppendLine($"***{i}: {displacement.Value[i]:f5}");
                }
            }

            return result.ToString();
        }
    }
}
