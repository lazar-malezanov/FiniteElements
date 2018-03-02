using Bytes2you.Validation;
using FiniteElements.Core.Contracts;
using FiniteElements.Core.Factories;
using FiniteElements.Models.Contracts;
using FiniteElements.Models.ServiceClasses;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Assign
{
    internal class AssignConcentratedNormalLoadToFrame : AssignCommand
    {
        private IFrameLoadFactory factory;

        public AssignConcentratedNormalLoadToFrame(IDatabase dbctx, IFrameLoadFactory factory) : base(dbctx)
        {
            Guard.WhenArgument(factory, "factory").IsNull().Throw();

            this.factory = factory;
        }

        public override string Execute(IList<string> parameters)
        {
            int elementId;
            int loadCaseNumber;
            double loadValue;
            double loadPosition;

            try
            {
                elementId = int.Parse(parameters[0]);
                loadCaseNumber = int.Parse(parameters[1]);
                loadValue = double.Parse(parameters[2]);
                loadPosition = double.Parse(parameters[3]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse AssignConcentratedNormalLoadToFrame command parameters.");
            }

            IFrameElement frameElement = base.dbctx.FrameElements[elementId];
            ILoadCase loadCase = base.dbctx.LoadCases[loadCaseNumber];

            IFrameLoad frameLoad = this.factory.CreateConcentratedNormalLoad(loadCase, frameElement.ElementLength, 0.0,
                loadValue, loadPosition);

            FrameService.AddLoad(frameElement, frameLoad);

            return $"Concentrated normal frame load with intensity {loadValue} and Load Case Numeber {loadCaseNumber} has been assigned to element with ID {frameElement.Number}.";
        }
    }
}
