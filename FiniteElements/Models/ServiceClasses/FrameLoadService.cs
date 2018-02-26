using FiniteElements.Models.Contracts;
using System.Text;

namespace FiniteElements.Models.ServiceClasses
{
    internal static class FrameLoadService
    {
        public static string AsString(ILoad frameLoad)
        {
            return Initialize(frameLoad, string.Empty);
        }

        public static string AsString(ILoad frameLoad, string characters)
        {
            return Initialize(frameLoad, characters);
        }

        private static string Initialize(ILoad frameLoad, string characters)
        {
            var result = new StringBuilder();

            result.AppendLine($"{characters}Load type: {frameLoad.Type}");
            result.AppendLine($"{characters}Load Case Name: {frameLoad.LoadCase.Name}");
            result.AppendLine($"{characters}----");

            return result.ToString();
        }
    }
}
