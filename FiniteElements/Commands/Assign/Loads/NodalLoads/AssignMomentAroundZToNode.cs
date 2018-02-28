using FiniteElements.Core.Contracts;
using FiniteElements.Models.Contracts;
using FiniteElements.Models.Nodes;
using FiniteElements.Models.Nodes.NodeLoads.Moment;
using FiniteElements.Models.ServiceClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiniteElements.Commands.Assign.Loads.NodalLoads
{
    internal class AssignMomentAroundZToNode : AssignCommand
    {
        public AssignMomentAroundZToNode(IDatabase dbctx) : base(dbctx) { }

        public override string Execute(IList<string> parameters)
        {
            int nodeId;
            int loadCaseNumber;
            double loadValue;

            try
            {
                nodeId = int.Parse(parameters[0]);
                loadCaseNumber = int.Parse(parameters[1]);
                loadValue = double.Parse(parameters[2]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse AssignMomentAroundZToNode command parameters.");
            }

            Node node = base.dbctx.Nodes[nodeId];
            ILoadCase loadCase = base.dbctx.LoadCases[loadCaseNumber];


            INodalLoad nodeLoad = new MomentAroundZ(loadCase, loadValue);

            NodeService.AddLoad(node, nodeLoad);

            return $"Nodal moment load around Z axis with intensity {loadValue} and Load Case Numeber {loadCaseNumber} has been assigned to node with ID {node.Number}.";
        }
    }
}
