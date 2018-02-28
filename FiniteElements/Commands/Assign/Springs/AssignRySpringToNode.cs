using FiniteElements.Core.Contracts;
using FiniteElements.Models.Nodes;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Assign.Springs
{
    internal class AssignRySpringToNode : AssignCommand
    {
        public AssignRySpringToNode(IDatabase dbctx) : base(dbctx) { }

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
                throw new ArgumentException("Failed to parse AssignRySpringToNode command parameters.");
            }

            Node node = base.dbctx.Nodes[nodeId];

            node.RySpring = springValue;
            return $"Node with ID {node.Number} was assigned a spring (around Y axis) with a value of {springValue}.";
        }
    }
}
