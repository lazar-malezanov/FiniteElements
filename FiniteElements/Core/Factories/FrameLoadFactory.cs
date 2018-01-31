using FiniteElements.Models.Contracts;
using FiniteElements.Models.FrameModels.FrameLoads;
using System.Collections.Generic;

namespace FiniteElements.Core.Factories
{
    internal class FrameLoadFactory : IFrameLoadFactory
    {
        public ILoad CreateLinearlyDistributedLoad(double intensity, double elementLength)
        {
            return new LinearlyDistributedLoad(intensity, elementLength);
        }

        public ILoad CreateTrapezoidLoad(double intensityAtNode1, double intensityAtNode2, double elementLength)
        {
            return new TrapezoidLoad(intensityAtNode1, intensityAtNode2, elementLength);
        }
    }
}
