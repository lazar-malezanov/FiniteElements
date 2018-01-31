using Materials.Contracts;
using System.Text;

namespace Materials.ExtensionMethods
{
    internal static class ExtensionMethodsForMaterials
    {
        public static string AsString(this IMaterialFromLibrary material)
        {
            var result = new StringBuilder();

            result.AppendLine($"ID: {material.Number}");
            result.AppendLine($"Name: {material.Name}");
            result.AppendLine($"E-module: {material.EModule}");
            result.AppendLine($"G-module: {material.GModule}");
            result.AppendLine("----");

            return result.ToString();
        }
    }
}
