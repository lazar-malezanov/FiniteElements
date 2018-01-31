using Bytes2you.Validation;
using FiniteElements.Core.Contracts;
using FiniteElements.Core.Factories;
using FiniteElements.Models.Contracts;
using FiniteElements.Models.Nodes;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Creating
{
    internal class CreateFrameElement : CreateCommand
    {
        private readonly IElementFactory factory;

        public CreateFrameElement(IElementFactory factory, IDatabase dbctx) : base(dbctx)
        {
            Guard.WhenArgument(factory, "factory").IsNull().Throw();

            this.factory = factory;
        }

        public override string Execute(IList<string> parameters)
        {
            int firstNodeId;
            int secondNodeId;

            try
            {
                firstNodeId = int.Parse(parameters[0]);
                secondNodeId = int.Parse(parameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateFrameElement command parameters.");
            }

            Node firstNode = base.dbctx.Nodes[firstNodeId];
            Node secondNode = base.dbctx.Nodes[secondNodeId];

            IFrameElement frameElement = this.factory.CreateFrameElement(firstNode, secondNode);

            this.dbctx.FrameElements.Add(frameElement);
            frameElement.Number = base.dbctx.FrameElements.Count - 1;
            return $"Frame Element with ID {frameElement.Number} was created.";
        }
    }
}
