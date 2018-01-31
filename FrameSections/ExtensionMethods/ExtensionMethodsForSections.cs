using FrameSections.Contracts;
using System.Text;

namespace FrameSections.ExtensionMethods
{
    internal static class ExtensionMethodsForSections
    {
        public static string AsString(this ISection frameSection)
        {
            var result = new StringBuilder();

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
    }
}
