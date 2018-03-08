using FiniteElements.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    result.AppendLine($"{i}: {reaction.Value[i]:f5}");
                }

            }

            return result.ToString();
        }
    }
}
