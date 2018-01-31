using FiniteElements.Models.Contracts;
using System.Text;

namespace FiniteElements.Models.ExtensionMethods
{
    internal static class ExtensionMethodsForMaterials
    {
        public static string AsString(this IMaterial material)
        {
            var result = new StringBuilder();

            result.AppendLine($"Material");
            result.AppendLine($"ID: {material.Number}");
            result.AppendLine($"Name: {material.Name}");
            result.AppendLine($"Type: {material.Type}");
            result.AppendLine($"E-module: {material.EModule}");
            result.AppendLine($"G-module: {material.GModule}");
            result.AppendLine("----");

            return result.ToString();
        }

        public static string AsString(this IMaterial material, string characters)
        {
            var result = new StringBuilder();

            result.AppendLine($"{characters}Material");
            result.AppendLine($"{characters}ID: {material.Number}");
            result.AppendLine($"{characters}Name: {material.Name}");
            result.AppendLine($"{characters}Type: {material.Type}");
            result.AppendLine($"{characters}E-module: {material.EModule}");
            result.AppendLine($"{characters}G-module: {material.GModule}");
            result.AppendLine($"{characters}----");

            return result.ToString();
        }
    }
}
