using Bytes2you.Validation;
using FiniteElements.Core.Contracts;
using FiniteElements.Core.Factories;
using FiniteElements.Models.Contracts;
using FiniteElements.Models.ServiceClasses;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Assign
{
    internal class AssignConcentratedMomentXZPlaneToFrame : AssignCommand
    {
        private IFrameLoadFactory factory;

        public AssignConcentratedMomentXZPlaneToFrame(IDatabase dbctx, IFrameLoadFactory factory) : base(dbctx)
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
                throw new ArgumentException("Failed to parse AssignConcentratedMomentXZPlaneToFrame command parameters.");
            }

            IFrameElement frameElement = base.dbctx.FrameElements[elementId];
            ILoadCase loadCase = base.dbctx.LoadCases[loadCaseNumber];
            double gCoefficient = (frameElement.MaterialProp.EModule * frameElement.SectionProp.MomentOfInertiaY * frameElement.SectionProp.Mju)
                / (frameElement.SectionProp.Area * frameElement.MaterialProp.GModule);

            IFrameLoad frameLoad = this.factory.CreateConcentratedMomentXZPlane(loadCase, frameElement.ElementLength, gCoefficient,
                loadValue, loadPosition);

            FrameService.AddLoad(frameElement, frameLoad);

            return $"Concentrated moment frame load in XZ plane with intensity {loadValue} and Load Case Numeber {loadCaseNumber} has been assigned to element with ID {frameElement.Number}.";
        }
    }
}
