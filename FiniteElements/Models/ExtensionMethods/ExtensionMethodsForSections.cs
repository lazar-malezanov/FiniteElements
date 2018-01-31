using FiniteElements.Models.Contracts;
using System.Text;

namespace FiniteElements.Models.ExtensionMethods
{
    internal static class ExtensionMethodsForSections
    {
        public static string AsString(this IFrameSection frameSection)
        {
            var result = new StringBuilder();

            result.AppendLine($"Section");
            result.AppendLine($"ID: {frameSection.Number}");
            result.AppendLine($"Name: {frameSection.Name}");
            result.AppendLine($"Type: {frameSection.Type}");
            result.AppendLine($"Area: {frameSection.Area}");
            result.AppendLine($"Local moment of inertia Y: {frameSection.MomentOfInertiaY}");
            result.AppendLine($"Local moment of inertia Z: {frameSection.MomentOfInertiaZ}");
            result.AppendLine($"Mju: {frameSection.Mju}");
            result.AppendLine("----");

            return result.ToString();
        }

        public static string AsString(this IFrameSection frameSection, string characters)
        {
            var result = new StringBuilder();

            result.AppendLine($"{characters}Section");
            result.AppendLine($"{characters}ID: {frameSection.Number}");
            result.AppendLine($"{characters}Name: {frameSection.Name}");
            result.AppendLine($"{characters}Type: {frameSection.Type}");
            result.AppendLine($"{characters}Area: {frameSection.Area}");
            result.AppendLine($"{characters}Local moment of inertia Y: {frameSection.MomentOfInertiaY}");
            result.AppendLine($"{characters}Local moment of inertia Z: {frameSection.MomentOfInertiaZ}");
            result.AppendLine($"{characters}Mju: {frameSection.Mju}");
            result.AppendLine($"{characters}----");

            return result.ToString();
        }
    }
}
