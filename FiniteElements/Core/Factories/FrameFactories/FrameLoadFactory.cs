using FiniteElements.Models.Contracts;
using FiniteElements.Models.FrameModels.FrameLoads;
using FiniteElements.Models.FrameModels.FrameLoads.TypesOfConcentratedLoads.Force;
using FiniteElements.Models.FrameModels.FrameLoads.TypesOfConcentratedLoads.Moment;
using FiniteElements.Models.FrameModels.FrameLoads.TypesOfDistributedLoads.Force;
using FiniteElements.Models.FrameModels.FrameLoads.TypesOfDistributedLoads.Moment;
using System.Collections.Generic;

namespace FiniteElements.Core.Factories
{
    internal class FrameLoadFactory : IFrameLoadFactory
    {
        //Distributed forces
        public ILoad CreateDistributedNormalLoad(ILoadCase loadCase, double elementLength, double gCoefficient, double loadAtStart, double loadAtEnd,
            double loadStartsAt, double loadEndsAt)
        {
            return new DistributedNormalForce(loadCase, elementLength, gCoefficient, loadAtStart, loadAtEnd, loadStartsAt, loadEndsAt);
        }

        public ILoad CreateDistributedShearLoadXYPlane(ILoadCase loadCase, double elementLength, double gCoefficient, double loadAtStart, double loadAtEnd,
            double loadStartsAt, double loadEndsAt)
        {
            return new DistributedShearXYPlane(loadCase, elementLength, gCoefficient, loadAtStart, loadAtEnd, loadStartsAt, loadEndsAt);
        }

        public ILoad CreateDistributedShearLoadXZPlane(ILoadCase loadCase, double elementLength, double gCoefficient, double loadAtStart, double loadAtEnd,
            double loadStartsAt, double loadEndsAt)
        {
            return new DistributedShearXZPlane(loadCase, elementLength, gCoefficient, loadAtStart, loadAtEnd, loadStartsAt, loadEndsAt);
        }

        //Distributed moments
        public ILoad CreateDistributedTorsion(ILoadCase loadCase, double elementLength, double gCoefficient, double loadAtStart, double loadAtEnd,
            double loadStartsAt, double loadEndsAt)
        {
            return new DistributedTorsion(loadCase, elementLength, gCoefficient, loadAtStart, loadAtEnd, loadStartsAt, loadEndsAt);
        }

        public ILoad CreateDistributedMomentXYPlane(ILoadCase loadCase, double elementLength, double gCoefficient, double loadAtStart, double loadAtEnd,
            double loadStartsAt, double loadEndsAt)
        {
            return new DistributedMomentXYPlane(loadCase, elementLength, gCoefficient, loadAtStart, loadAtEnd, loadStartsAt, loadEndsAt);
        }

        public ILoad CreateDistributedMomentXZPlane(ILoadCase loadCase, double elementLength, double gCoefficient, double loadAtStart, double loadAtEnd,
            double loadStartsAt, double loadEndsAt)
        {
            return new DistributedMomentXZPlane(loadCase, elementLength, gCoefficient, loadAtStart, loadAtEnd, loadStartsAt, loadEndsAt);
        }

        //Concentrated forces
        public ILoad CreateConcentratedNormalLoad(ILoadCase loadCase, double elementLength, double gCoefficient,
            double loadValue, double loadPosition)
        {
            return new ConcentratedNormalForce(loadCase, elementLength, gCoefficient, loadValue, loadPosition);
        }

        public ILoad CreateConcentratedShearLoadXYPlane(ILoadCase loadCase, double elementLength, double gCoefficient,
            double loadValue, double loadPosition)
        {
            return new ConcentratedShearXYPlane(loadCase, elementLength, gCoefficient, loadValue, loadPosition);
        }

        public ILoad CreateConcentratedShearLoadXZPlane(ILoadCase loadCase, double elementLength, double gCoefficient,
            double loadValue, double loadPosition)
        {
            return new ConcentratedShearXZPlane(loadCase, elementLength, gCoefficient, loadValue, loadPosition);
        }

        //Concentrated moments
        public ILoad CreateConcentratedTorsion(ILoadCase loadCase, double elementLength, double gCoefficient,
            double loadValue, double loadPosition)
        {
            return new ConcentratedTorsion(loadCase, elementLength, gCoefficient, loadValue, loadPosition);
        }

        public ILoad CreateConcentratedMomentXYPlane(ILoadCase loadCase, double elementLength, double gCoefficient,
            double loadValue, double loadPosition)
        {
            return new ConcentratedMomentXYPlane(loadCase, elementLength, gCoefficient, loadValue, loadPosition);
        }

        public ILoad CreateConcentratedMomentXZPlane(ILoadCase loadCase, double elementLength, double gCoefficient,
            double loadValue, double loadPosition)
        {
            return new ConcentratedMomentXZPlane(loadCase, elementLength, gCoefficient, loadValue, loadPosition);
        }
    }
}
