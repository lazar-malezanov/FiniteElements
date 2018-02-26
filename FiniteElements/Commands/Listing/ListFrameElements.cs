using FiniteElements.Core.Contracts;
using FiniteElements.Models.Contracts;
using FiniteElements.Models.ServiceClasses;
using System.Collections.Generic;
using System.Text;

namespace FiniteElements.Commands.Listing
{
    internal class ListFrameElements : ListCommand
    {
        public ListFrameElements(IDatabase dbctx) : base(dbctx) { }

        public override string Execute(IList<string> parameters)
        {
            List<IFrameElement> frameElements = base.dbctx.FrameElements;
            var result = new StringBuilder();

            foreach (var frameElement in frameElements)
            {
                result.AppendLine(FrameService.AsString(frameElement));   
            }

            return result.ToString();
        }
    }
}
