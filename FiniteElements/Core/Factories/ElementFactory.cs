using FiniteElements.Models.Contracts;
using FiniteElements.Models.FrameModels.FrameElements;
using FiniteElements.Models.Nodes;

namespace FiniteElements.Core.Factories
{
    internal class ElementFactory : IElementFactory
    {
        public IFrameElement CreateFrameElement(Node node1, Node node2)
        {
            return new FrameElement(node1, node2);
        }
    }
}
