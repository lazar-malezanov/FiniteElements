using FiniteElements.Core.Contracts;
using FiniteElements.Models.Nodes;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Assign.Springs
{
    internal class AssignRxSpringToNode : AssignCommand
    {
        public AssignRxSpringToNode(IDatabase dbctx) : base(dbctx) { }

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
                throw new ArgumentException("Failed to parse AssignRxSpringToNode command parameters.");
            }

            Node node = base.dbctx.Nodes[nodeId];

            node.RxSpring = springValue;
            if (!this.dbctx.Springs.Contains(node))
            {
                this.dbctx.Springs.Add(node);
            }           
            return $"Node with ID {node.Number} was assigned a spring (around X axis) with a value of {springValue}.";
        }
    }
}
