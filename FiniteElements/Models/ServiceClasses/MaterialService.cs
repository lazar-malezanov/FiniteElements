using FiniteElements.Models.Contracts;
using System.Text;

namespace FiniteElements.Models.ServiceClasses
{
    internal static class MaterialService
    {
        public static string AsString(IMaterial material)
        {
            return Initialize(material, string.Empty);
        }

        public static string AsString(IMaterial material, string characters)
        {
            return Initialize(material, characters);
        }

        private static string Initialize(IMaterial material, string characters)
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
