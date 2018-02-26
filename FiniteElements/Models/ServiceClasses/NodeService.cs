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
            result.AppendLine($"Translational constraints (U, V, W): {node.UConstraint}, {node.VConstraint}, {node.WConstraint}");
            result.AppendLine($"Rotational constraints (Rx, Ry, Rz): {node.RxConstraint}, {node.RyConstraint}, {node.RzConstraint}");
            result.AppendLine("----");

            return result.ToString();
        }
    }
}
