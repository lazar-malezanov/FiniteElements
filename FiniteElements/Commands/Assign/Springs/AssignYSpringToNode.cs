using FiniteElements.Core.Contracts;
using FiniteElements.Models.Nodes;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Assign.Springs
{
    internal class AssignYSpringToNode : AssignCommand
    {
        public AssignYSpringToNode(IDatabase dbctx) : base(dbctx) { }

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
                throw new ArgumentException("Failed to parse AssignYSpringToNode command parameters.");
            }

            Node node = base.dbctx.Nodes[nodeId];

            node.YSpring = springValue;
            if (!this.dbctx.Springs.Contains(node))
            {
                this.dbctx.Springs.Add(node);
            }
            return $"Node with ID {node.Number} was assigned a spring (in Y direction) with a value of {springValue}.";
        }
    }
}
