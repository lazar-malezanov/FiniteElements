using MathNet.Numerics.LinearAlgebra;
using System.Collections.Generic;

namespace FiniteElements.Models.Contracts
{
    internal interface IElement
    {
        IMaterial MaterialProp { get; set; }

        IFrameSection SectionProp { get; set; }

        List<IFrameLoad> Loads { get; }

        double Number { get; set; }
    }
}
