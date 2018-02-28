using FiniteElements.Core.Contracts;
using FiniteElements.Models.Nodes;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Assign.Supports
{
    internal class AssignRzSupportToNode : AssignCommand
    {
        public AssignRzSupportToNode(IDatabase dbctx) : base(dbctx) { }

        public override string Execute(IList<string> parameters)
        {
            int nodeId;

            try
            {
                nodeId = int.Parse(parameters[0]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse AssignRzSupportToNode command parameters.");
            }

            Node node = base.dbctx.Nodes[nodeId];

            node.RzSupport = true;
            return $"Node with ID {node.Number} was assigned with an Rz support.";
        }
    }
}
