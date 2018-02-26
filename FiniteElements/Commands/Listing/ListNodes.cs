using FiniteElements.Core.Contracts;
using FiniteElements.Models.Nodes;
using FiniteElements.Models.ServiceClasses;
using System.Collections.Generic;
using System.Text;

namespace FiniteElements.Commands.Listing
{
    internal class ListNodes : ListCommand
    {
        public ListNodes(IDatabase dbctx) : base(dbctx) { }

        public override string Execute(IList<string> parameters)
        {
            List<Node> nodes = base.dbctx.Nodes;
            var result = new StringBuilder();

            foreach (var node in nodes)
            {
                result.AppendLine(NodeService.AsString(node));
            }

            return result.ToString();
        }
    }
}
