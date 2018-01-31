using FiniteElements.Core.Contracts;
using FiniteElements.Models.Nodes;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Creating
{
    internal class CreateNode : CreateCommand
    {
        public CreateNode(IDatabase dbctx) : base(dbctx) { }

        public override string Execute(IList<string> parameters)
        {
            double xCoord;
            double yCoord;
            double zCoord;

            try
            {
                xCoord = double.Parse(parameters[0]);
                yCoord = double.Parse(parameters[1]);
                zCoord = double.Parse(parameters[2]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateNode command parameters.");
            }

            Node node = new Node(xCoord, yCoord, zCoord);

            base.dbctx.Nodes.Add(node);
            node.Number = base.dbctx.Nodes.Count - 1;
            return $"Node with ID {node.Number} was created.";
        }
    }
}
