using Bytes2you.Validation;
using FiniteElements.Models.Contracts;
using FiniteElements.Models.Nodes;
using System.Text;

namespace FiniteElements.Models.ServiceClasses
{
    internal static class NodeService
    {
        public static string AsString(this Node node)
        {
            var result = new StringBuilder();

            result.AppendLine($"ID: {node.Number}");
            result.AppendLine($"Coordinates (X, Y, Z): {node.XCoord}, {node.YCoord}, {node.ZCoord}");
            result.AppendLine($"Translational constraints (U, V, W): {node.XSupport}, {node.YSupport}, {node.ZSupport}");
            result.AppendLine($"Rotational constraints (Rx, Ry, Rz): {node.RxSupport}, {node.RySupport}, {node.RzSupport}");
            result.AppendLine($"Translational springs (U, V, W): {node.XSpring}, {node.YSpring}, {node.ZSpring}");
            result.AppendLine($"Rotational springs (Rx, Ry, Rz): {node.RxSpring}, {node.RySpring}, {node.RzSpring}");
            foreach (var load in node.Loads)
            {
                result.AppendLine($"{load.LoadCase.Name} Loads: {load.Type} {load.LoadValue}");
            }
            
            result.AppendLine("----");

            return result.ToString();
        }

        public static void AddLoad(Node node, INodalLoad load)
        {
            Guard.WhenArgument(load, "load").IsNull().Throw();
            node.Loads.Add(load);
        }

        public static bool HasSupport(Node node)
        {
            if (node.Supports.Contains(true))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public static bool HasSpring(Node node)
        {
            if (node.Springs.Exists(x => x > 0.0))
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
