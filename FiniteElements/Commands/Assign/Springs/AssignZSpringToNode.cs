using FiniteElements.Core.Contracts;
using FiniteElements.Models.Nodes;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Assign.Springs
{
    internal class AssignZSpringToNode : AssignCommand
    {
        public AssignZSpringToNode(IDatabase dbctx) : base(dbctx) { }

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
                throw new ArgumentException("Failed to parse AssignZSpringToNode command parameters.");
            }

            Node node = base.dbctx.Nodes[nodeId];

            node.ZSpring = springValue;
            if (!this.dbctx.Springs.Contains(node))
            {
                this.dbctx.Springs.Add(node);
            }
            return $"Node with ID {node.Number} was assigned a spring (in Z direction) with a value of {springValue}.";
        }
    }
}
