using FiniteElements.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiniteElements.Commands.Listing.Results
{
    internal class ListFrameElementInternalForces : ListCommand
    {
        public ListFrameElementInternalForces(IDatabase dbctx) : base(dbctx) { }

        public override string Execute(IList<string> parameters)
        {
            int loadCaseNumber;
            try
            {
                loadCaseNumber = int.Parse(parameters[0]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse ListFrameElementInternalForces command parameters.");
            }

            var result = new StringBuilder();

            foreach (var element in this.dbctx.FrameElements)
            {
                result.AppendLine($"Element {element.Number} Internal Forces:");
                result.AppendLine($"***Start Node {element.Node1.Number}:");
                result.AppendLine($"******Fx = {element.LocalInternalForceVectors[loadCaseNumber][0]:f2}");
                result.AppendLine($"******Fy = {element.LocalInternalForceVectors[loadCaseNumber][1]:f2}");
                result.AppendLine($"******Fz = {element.LocalInternalForceVectors[loadCaseNumber][2]:f2}");
                result.AppendLine($"******Mx = {element.LocalInternalForceVectors[loadCaseNumber][3]:f2}");
                result.AppendLine($"******My = {element.LocalInternalForceVectors[loadCaseNumber][4]:f2}");
                result.AppendLine($"******Mz = {element.LocalInternalForceVectors[loadCaseNumber][5]:f2}");

                result.AppendLine($"***End Node {element.Node2.Number}:");
                result.AppendLine($"******Fx = {element.LocalInternalForceVectors[loadCaseNumber][6]:f2}");
                result.AppendLine($"******Fy = {element.LocalInternalForceVectors[loadCaseNumber][7]:f2}");
                result.AppendLine($"******Fz = {element.LocalInternalForceVectors[loadCaseNumber][8]:f2}");
                result.AppendLine($"******Mx = {element.LocalInternalForceVectors[loadCaseNumber][9]:f2}");
                result.AppendLine($"******My = {element.LocalInternalForceVectors[loadCaseNumber][10]:f2}");
                result.AppendLine($"******Mz = {element.LocalInternalForceVectors[loadCaseNumber][11]:f2}");
            }

            return result.ToString();
        }
    }
}
