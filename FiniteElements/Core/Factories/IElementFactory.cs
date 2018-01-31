using FiniteElements.Models.Contracts;
using FiniteElements.Models.Nodes;

namespace FiniteElements.Core.Factories
{
    internal interface IElementFactory
    {
        IFrameElement CreateFrameElement(Node node1, Node node2);
    }
}
