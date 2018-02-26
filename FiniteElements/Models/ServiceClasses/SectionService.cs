using FiniteElements.Models.Contracts;
using System.Text;

namespace FiniteElements.Models.ServiceClasses
{
    internal static class SectionService
    {
        public static string AsString(IFrameSection frameSection)
        {
            return Initialize(frameSection, string.Empty);
        }

        public static string AsString(IFrameSection frameSection, string characters)
        {
            return Initialize(frameSection, characters);
        }

        private static string Initialize(IFrameSection frameSection, string characters)
        {
            var result = new StringBuilder();

            result.AppendLine($"{characters}Section");
            result.AppendLine($"{characters}ID: {frameSection.Number}");
            result.AppendLine($"{characters}Name: {frameSection.Name}");
            result.AppendLine($"{characters}Type: {frameSection.Type}");
            result.AppendLine($"{characters}Area: {frameSection.Area}");
            result.AppendLine($"{characters}Local moment of inertia Y: {frameSection.MomentOfInertiaY}");
            result.AppendLine($"{characters}Local moment of inertia Z: {frameSection.MomentOfInertiaZ}");
            result.AppendLine($"{characters}Torsional constant X: {frameSection.TorsionalConstantX}");
            result.AppendLine($"{characters}Mju: {frameSection.Mju}");
            result.AppendLine($"{characters}----");

            return result.ToString();
        }
    }
}
