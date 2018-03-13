using FiniteElements.Core.Contracts;
using System.Collections.Generic;
using System.Text;

namespace FiniteElements.Commands.Listing.Results
{
    internal class ListReactions : ListCommand
    {
        public ListReactions(IDatabase dbctx) : base(dbctx) { }

        public override string Execute(IList<string> parameters)
        {
            var result = new StringBuilder();

            foreach (var reaction in this.dbctx.ResultNodalReactionVectors)
            {
                for (int i = 0; i < reaction.Value.Count; i++)
                {
                    if (i % 6 == 0)
                    {
                        result.AppendLine($"Node {i / 6}:");
                    }
                    result.AppendLine($"***{i}: {reaction.Value[i]:f5}");
                }
            }

            return result.ToString();
        }
    }
}
