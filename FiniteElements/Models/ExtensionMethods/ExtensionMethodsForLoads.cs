using FiniteElements.Models.Contracts;
using System.Text;

namespace FiniteElements.Models.ExtensionMethods
{
    internal static class ExtensionMethodsForLoads
    {
        public static string AsString(this ILoad frameLoad)
        {
            var result = new StringBuilder();

            result.AppendLine($"Load type: {frameLoad.Type}");
            result.AppendLine($"Load Case Number: {frameLoad.LoadCaseNumber}");
            result.AppendLine($"Load Case Name: {frameLoad.LoadCase.Name}");
            result.AppendLine($"----");

            return result.ToString();
        }

        public static string AsString(this ILoad frameLoad, string characters)
        {
            var result = new StringBuilder();

            result.AppendLine($"{characters}Load type: {frameLoad.Type}");
            result.AppendLine($"{characters}Load Case Number: {frameLoad.LoadCaseNumber}");
            result.AppendLine($"{characters}Load Case Name: {frameLoad.LoadCase.Name}");
            result.AppendLine($"{characters}----");

            return result.ToString();
        }
    }
}
