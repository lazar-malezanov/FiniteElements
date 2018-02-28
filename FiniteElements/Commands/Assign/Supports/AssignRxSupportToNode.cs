using FiniteElements.Core.Contracts;
using FiniteElements.Models.Nodes;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Assign.Supports
{
    internal class AssignRxSupportToNode : AssignCommand
    {
        public AssignRxSupportToNode(IDatabase dbctx) : base(dbctx) { }

        public override string Execute(IList<string> parameters)
        {
            int nodeId;

            try
            {
                nodeId = int.Parse(parameters[0]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse AssignRxSupportToNode command parameters.");
            }

            Node node = base.dbctx.Nodes[nodeId];

            node.RxSupport = true;
            return $"Node with ID {node.Number} was assigned with an Rx support.";
        }
    }
}
