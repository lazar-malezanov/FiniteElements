using FiniteElements.Core.Contracts;
using FiniteElements.Models.Nodes;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Assign.Supports
{
    internal class AssignXSupportToNode : AssignCommand
    {
        public AssignXSupportToNode(IDatabase dbctx) : base(dbctx) { }

        public override string Execute(IList<string> parameters)
        {
            int nodeId;

            try
            {
                nodeId = int.Parse(parameters[0]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse AssignXSupportToNode command parameters.");
            }

            Node node = base.dbctx.Nodes[nodeId];

            node.XSupport = true;
            if (!this.dbctx.Supports.Contains(node))
            {
                this.dbctx.Supports.Add(node);
            }
            return $"Node with ID {node.Number} was assigned with an X support.";
        }
    }
}
