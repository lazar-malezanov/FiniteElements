using FiniteElements.Models.Contracts;
using System.Collections.Generic;

namespace FiniteElements.Core.Factories
{
    internal interface IFrameLoadFactory
    {
        ILoad CreateTrapezoidLoad(double intensityAtNode1, double intensityAtNode2, double elementLength);

        ILoad CreateLinearlyDistributedLoad(double intensity, double elementLength);
    }
}
