using FiniteElements.Core.Contracts;
using FiniteElements.Models.Nodes;
using FiniteElements.Models.ServiceClasses;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Showing
{
    internal class ShowNode : ShowCommand
    {
        public ShowNode(IDatabase dbctx) : base(dbctx) { }

        public override string Execute(IList<string> parameters)
        {
            int nodeId;

            try
            {
                nodeId = int.Parse(parameters[0]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse ShowNode command parameters.");
            }

            Node node = base.dbctx.Nodes[nodeId];
            string result = NodeService.AsString(node);     

            return result;
        }
    }
}
