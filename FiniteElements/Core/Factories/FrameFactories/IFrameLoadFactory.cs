using FiniteElements.Models.Contracts;
using System.Collections.Generic;

namespace FiniteElements.Core.Factories
{
    internal interface IFrameLoadFactory
    {
        //Distributed forces
        ILoad CreateDistributedNormalLoad(ILoadCase loadCase, double elementLength, double gCoefficient, double loadAtStart, double loadAtEnd,
            double loadStartsAt, double loadEndsAt);

        ILoad CreateDistributedShearLoadXYPlane(ILoadCase loadCase, double elementLength, double gCoefficient, double loadAtStart, double loadAtEnd,
            double loadStartsAt, double loadEndsAt);

        ILoad CreateDistributedShearLoadXZPlane(ILoadCase loadCase, double elementLength, double gCoefficient, double loadAtStart, double loadAtEnd,
            double loadStartsAt, double loadEndsAt);

        //Distributed moments
        ILoad CreateDistributedTorsion(ILoadCase loadCase, double elementLength, double gCoefficient, double loadAtStart, double loadAtEnd,
            double loadStartsAt, double loadEndsAt);

        ILoad CreateDistributedMomentXYPlane(ILoadCase loadCase, double elementLength, double gCoefficient, double loadAtStart, double loadAtEnd,
            double loadStartsAt, double loadEndsAt);

        ILoad CreateDistributedMomentXZPlane(ILoadCase loadCase, double elementLength, double gCoefficient, double loadAtStart, double loadAtEnd,
            double loadStartsAt, double loadEndsAt);

        //Concentrated forces
        ILoad CreateConcentratedNormalLoad(ILoadCase loadCase, double elementLength, double gCoefficient,
            double loadValue, double loadPosition);

        ILoad CreateConcentratedShearLoadXYPlane(ILoadCase loadCase, double elementLength, double gCoefficient,
            double loadValue, double loadPosition);

        ILoad CreateConcentratedShearLoadXZPlane(ILoadCase loadCase, double elementLength, double gCoefficient,
            double loadValue, double loadPosition);

        //Concentrated moments
        ILoad CreateConcentratedTorsion(ILoadCase loadCase, double elementLength, double gCoefficient,
            double loadValue, double loadPosition);

        ILoad CreateConcentratedMomentXYPlane(ILoadCase loadCase, double elementLength, double gCoefficient,
            double loadValue, double loadPosition);

        ILoad CreateConcentratedMomentXZPlane(ILoadCase loadCase, double elementLength, double gCoefficient,
            double loadValue, double loadPosition);
    }
}
