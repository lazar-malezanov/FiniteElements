using FiniteElements.Models.Contracts;

namespace FiniteElements.Core.Factories
{
    internal interface IFrameLoadFactory
    {
        //Distributed forces
        IFrameLoad CreateDistributedNormalLoad(ILoadCase loadCase, double elementLength, double gCoefficient, double loadAtStart, double loadAtEnd,
            double loadStartsAt, double loadEndsAt);

        IFrameLoad CreateDistributedShearLoadXYPlane(ILoadCase loadCase, double elementLength, double gCoefficient, double loadAtStart, double loadAtEnd,
            double loadStartsAt, double loadEndsAt);

        IFrameLoad CreateDistributedShearLoadXZPlane(ILoadCase loadCase, double elementLength, double gCoefficient, double loadAtStart, double loadAtEnd,
            double loadStartsAt, double loadEndsAt);

        //Distributed moments
        IFrameLoad CreateDistributedTorsion(ILoadCase loadCase, double elementLength, double gCoefficient, double loadAtStart, double loadAtEnd,
            double loadStartsAt, double loadEndsAt);

        IFrameLoad CreateDistributedMomentXYPlane(ILoadCase loadCase, double elementLength, double gCoefficient, double loadAtStart, double loadAtEnd,
            double loadStartsAt, double loadEndsAt);

        IFrameLoad CreateDistributedMomentXZPlane(ILoadCase loadCase, double elementLength, double gCoefficient, double loadAtStart, double loadAtEnd,
            double loadStartsAt, double loadEndsAt);

        //Concentrated forces
        IFrameLoad CreateConcentratedNormalLoad(ILoadCase loadCase, double elementLength, double gCoefficient,
            double loadValue, double loadPosition);

        IFrameLoad CreateConcentratedShearLoadXYPlane(ILoadCase loadCase, double elementLength, double gCoefficient,
            double loadValue, double loadPosition);

        IFrameLoad CreateConcentratedShearLoadXZPlane(ILoadCase loadCase, double elementLength, double gCoefficient,
            double loadValue, double loadPosition);

        //Concentrated moments
        IFrameLoad CreateConcentratedTorsion(ILoadCase loadCase, double elementLength, double gCoefficient,
            double loadValue, double loadPosition);

        IFrameLoad CreateConcentratedMomentXYPlane(ILoadCase loadCase, double elementLength, double gCoefficient,
            double loadValue, double loadPosition);

        IFrameLoad CreateConcentratedMomentXZPlane(ILoadCase loadCase, double elementLength, double gCoefficient,
            double loadValue, double loadPosition);
    }
}
