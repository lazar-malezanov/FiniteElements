using Bytes2you.Validation;
using FiniteElements.Core.Contracts;
using FiniteElements.Core.Factories;
using FiniteElements.Models.Contracts;
using FiniteElements.Models.ExtensionMethods;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Assign
{
    internal class AssignLinearlyDistributedLoadToFrame : AssignCommand
    {
        private IFrameLoadFactory factory;

        public AssignLinearlyDistributedLoadToFrame(IDatabase dbctx, IFrameLoadFactory factory) : base(dbctx)
        {
            Guard.WhenArgument(factory, "factory").IsNull().Throw();

            this.factory = factory;
        }

        public override string Execute(IList<string> parameters)
        {
            int elementId;
            int loadCaseNumber;
            double intensity;

            try
            {
                elementId = int.Parse(parameters[0]);
                loadCaseNumber = int.Parse(parameters[1]);
                intensity = double.Parse(parameters[2]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse AssignLinearlyDistributedLoadToFrame command parameters.");
            }

            IFrameElement frameElement = base.dbctx.FrameElements[elementId];
            ILoadCase loadCase = base.dbctx.LoadCases[loadCaseNumber];

            ILoad frameLoad = this.factory.CreateLinearlyDistributedLoad(intensity, frameElement.ElementLength);
            frameLoad.LoadCaseNumber = loadCaseNumber;
            frameLoad.LoadCase = loadCase;
            frameElement.AddLoad(frameLoad);

            return $"Linearly Distributed frame load with intensity {intensity} and Load Case Numeber {loadCaseNumber} has been assigned to element with ID {frameElement.Number}.";
        }
    }
}
