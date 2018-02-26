using FiniteElements.Core.Contracts;
using FiniteElements.Models.Contracts;
using FiniteElements.Models.ServiceClasses;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Showing
{
    internal class ShowFrameElement : ShowCommand
    {
        public ShowFrameElement(IDatabase dbctx) : base(dbctx) { }

        public override string Execute(IList<string> parameters)
        {
            int frameId;

            try
            {
                frameId = int.Parse(parameters[0]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse ShowFrameElement command parameters.");
            }

            IFrameElement frameElement = base.dbctx.FrameElements[frameId];
            string result = FrameService.AsString(frameElement);

            return result;
        }
    }
}
