using FrameSections.Contracts;

namespace FrameSections.Core.Factories
{
    internal interface IFrameSectionFactory
    {
        ISection CreateRectangularSection(double height, double width);

        ISection CreateCircularSection(double diameter);
    }
}
