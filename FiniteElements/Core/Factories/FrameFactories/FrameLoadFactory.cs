using FiniteElements.Models.Contracts;
using FiniteElements.Models.FrameModels.FrameLoads.TypesOfConcentratedLoads.Force;
using FiniteElements.Models.FrameModels.FrameLoads.TypesOfConcentratedLoads.Moment;
using FiniteElements.Models.FrameModels.FrameLoads.TypesOfDistributedLoads.Force;
using FiniteElements.Models.FrameModels.FrameLoads.TypesOfDistributedLoads.Moment;

namespace FiniteElements.Core.Factories
{
    internal class FrameLoadFactory : IFrameLoadFactory
    {
        //Distributed forces
        public IFrameLoad CreateDistributedNormalLoad(ILoadCase loadCase, double elementLength, double gCoefficient, double loadAtStart, double loadAtEnd,
            double loadStartsAt, double loadEndsAt)
        {
            return new DistributedNormalForce(loadCase, elementLength, gCoefficient, loadAtStart, loadAtEnd, loadStartsAt, loadEndsAt);
        }

        public IFrameLoad CreateDistributedShearLoadXYPlane(ILoadCase loadCase, double elementLength, double gCoefficient, double loadAtStart, double loadAtEnd,
            double loadStartsAt, double loadEndsAt)
        {
            return new DistributedShearXYPlane(loadCase, elementLength, gCoefficient, loadAtStart, loadAtEnd, loadStartsAt, loadEndsAt);
        }

        public IFrameLoad CreateDistributedShearLoadXZPlane(ILoadCase loadCase, double elementLength, double gCoefficient, double loadAtStart, double loadAtEnd,
            double loadStartsAt, double loadEndsAt)
        {
            return new DistributedShearXZPlane(loadCase, elementLength, gCoefficient, loadAtStart, loadAtEnd, loadStartsAt, loadEndsAt);
        }

        //Distributed moments
        public IFrameLoad CreateDistributedTorsion(ILoadCase loadCase, double elementLength, double gCoefficient, double loadAtStart, double loadAtEnd,
            double loadStartsAt, double loadEndsAt)
        {
            return new DistributedTorsion(loadCase, elementLength, gCoefficient, loadAtStart, loadAtEnd, loadStartsAt, loadEndsAt);
        }

        public IFrameLoad CreateDistributedMomentXYPlane(ILoadCase loadCase, double elementLength, double gCoefficient, double loadAtStart, double loadAtEnd,
            double loadStartsAt, double loadEndsAt)
        {
            return new DistributedMomentXYPlane(loadCase, elementLength, gCoefficient, loadAtStart, loadAtEnd, loadStartsAt, loadEndsAt);
        }

        public IFrameLoad CreateDistributedMomentXZPlane(ILoadCase loadCase, double elementLength, double gCoefficient, double loadAtStart, double loadAtEnd,
            double loadStartsAt, double loadEndsAt)
        {
            return new DistributedMomentXZPlane(loadCase, elementLength, gCoefficient, loadAtStart, loadAtEnd, loadStartsAt, loadEndsAt);
        }

        //Concentrated forces
        public IFrameLoad CreateConcentratedNormalLoad(ILoadCase loadCase, double elementLength, double gCoefficient,
            double loadValue, double loadPosition)
        {
            return new ConcentratedNormalForce(loadCase, elementLength, gCoefficient, loadValue, loadPosition);
        }

        public IFrameLoad CreateConcentratedShearLoadXYPlane(ILoadCase loadCase, double elementLength, double gCoefficient,
            double loadValue, double loadPosition)
        {
            return new ConcentratedShearXYPlane(loadCase, elementLength, gCoefficient, loadValue, loadPosition);
        }

        public IFrameLoad CreateConcentratedShearLoadXZPlane(ILoadCase loadCase, double elementLength, double gCoefficient,
            double loadValue, double loadPosition)
        {
            return new ConcentratedShearXZPlane(loadCase, elementLength, gCoefficient, loadValue, loadPosition);
        }

        //Concentrated moments
        public IFrameLoad CreateConcentratedTorsion(ILoadCase loadCase, double elementLength, double gCoefficient,
            double loadValue, double loadPosition)
        {
            return new ConcentratedTorsion(loadCase, elementLength, gCoefficient, loadValue, loadPosition);
        }

        public IFrameLoad CreateConcentratedMomentXYPlane(ILoadCase loadCase, double elementLength, double gCoefficient,
            double loadValue, double loadPosition)
        {
            return new ConcentratedMomentXYPlane(loadCase, elementLength, gCoefficient, loadValue, loadPosition);
        }

        public IFrameLoad CreateConcentratedMomentXZPlane(ILoadCase loadCase, double elementLength, double gCoefficient,
            double loadValue, double loadPosition)
        {
            return new ConcentratedMomentXZPlane(loadCase, elementLength, gCoefficient, loadValue, loadPosition);
        }
    }
}
