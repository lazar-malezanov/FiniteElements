using FrameSections.Contracts;
using FrameSections.Sections;

namespace FrameSections.Core.Factories
{
    internal class FrameSectionFactory : IFrameSectionFactory
    {
        public ISection CreateRectangularSection(double height, double width)
        {
            return new RectangularSection(height, width);
        }

        public ISection CreateCircularSection(double diameter)
        {
            return new CircularSection(diameter);
        }
    }
}
