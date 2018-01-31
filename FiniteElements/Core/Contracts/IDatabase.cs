using FiniteElements.Models.Contracts;
using FiniteElements.Models.Nodes;
using System.Collections.Generic;

namespace FiniteElements.Core.Contracts
{
    internal interface IDatabase
    {
        List<Node> Nodes { get; }

        List<IFrameElement> FrameElements { get; }

        List<IFrameSection> FrameSections { get; }

        List<IMaterial> Materials { get; }

        List<ILoadCase> LoadCases { get; }
    }
}
