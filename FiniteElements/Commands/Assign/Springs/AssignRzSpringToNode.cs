using FiniteElements.Core.Contracts;
using FiniteElements.Models.Nodes;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Assign.Springs
{
    internal class AssignRzSpringToNode : AssignCommand
    {
        public AssignRzSpringToNode(IDatabase dbctx) : base(dbctx) { }

        public override string Execute(IList<string> parameters)
        {
            int nodeId;
            double springValue;

            try
            {
                nodeId = int.Parse(parameters[0]);
                springValue = double.Parse(parameters[1]);

                if (springValue < 0)
                {
                    throw new ArgumentException();
                }
            }
            catch
            {
                throw new ArgumentException("Failed to parse AssignRzSpringToNode command parameters.");
            }

            Node node = base.dbctx.Nodes[nodeId];

            node.RzSpring = springValue;
            if (!this.dbctx.Springs.Contains(node))
            {
                this.dbctx.Springs.Add(node);
            }
            return $"Node with ID {node.Number} was assigned a spring (around Z axis) with a value of {springValue}.";
        }
    }
}
