using FiniteElements.Core.Contracts;
using FiniteElements.Models.Contracts;
using FiniteElements.Models.ExtensionMethods;
using System.Collections.Generic;
using System.Text;

namespace FiniteElements.Commands.Listing
{
    internal class ListFrameSections : ListCommand
    {
        public ListFrameSections(IDatabase dbctx) : base(dbctx) { }

        public override string Execute(IList<string> parameters)
        {
            List<IFrameSection> frameSections = base.dbctx.FrameSections;
            var result = new StringBuilder();

            foreach (var frameSection in frameSections)
            {
                result.AppendLine(frameSection.AsString());
            }

            return result.ToString();
        }
    }
}
