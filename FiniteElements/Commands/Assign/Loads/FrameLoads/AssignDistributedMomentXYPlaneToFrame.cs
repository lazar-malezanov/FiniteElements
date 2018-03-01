using Bytes2you.Validation;
using FiniteElements.Core.Contracts;
using FiniteElements.Core.Factories;
using FiniteElements.Models.Contracts;
using FiniteElements.Models.ServiceClasses;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Assign
{
    internal class AssignDistributedMomentXYPlaneToFrame : AssignCommand
    {
        private IFrameLoadFactory factory;

        public AssignDistributedMomentXYPlaneToFrame(IDatabase dbctx, IFrameLoadFactory factory) : base(dbctx)
        {
            Guard.WhenArgument(factory, "factory").IsNull().Throw();

            this.factory = factory;
        }

        public override string Execute(IList<string> parameters)
        {
            int elementId;
            int loadCaseNumber;
            double loadAtStart;
            double loadAtEnd;
            double loadStartsAt;
            double loadEndsAt;

            try
            {
                elementId = int.Parse(parameters[0]);
                loadCaseNumber = int.Parse(parameters[1]);
                loadAtStart = double.Parse(parameters[2]);
                loadAtEnd = double.Parse(parameters[3]);
                loadStartsAt = double.Parse(parameters[4]);
                loadEndsAt = double.Parse(parameters[5]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse AssignDistributedMomentXYPlaneToFrame command parameters.");
            }

            IFrameElement frameElement = base.dbctx.FrameElements[elementId];
            ILoadCase loadCase = base.dbctx.LoadCases[loadCaseNumber];
            double gCoefficient = (frameElement.MaterialProp.EModule * frameElement.SectionProp.MomentOfInertiaZ * frameElement.SectionProp.Mju)
                / (frameElement.SectionProp.Area * frameElement.MaterialProp.GModule);

            IFrameLoad frameLoad = this.factory.CreateDistributedMomentXYPlane(loadCase, frameElement.ElementLength, gCoefficient,
                loadAtStart, loadAtEnd, loadStartsAt, loadEndsAt);

            FrameService.AddLoad(frameElement, frameLoad);

            return $"Distributed moment frame load in XY plane with intensities {loadAtStart} and {loadAtEnd} and Load Case Numeber {loadCaseNumber} has been assigned to element with ID {frameElement.Number}.";
        }
    }
}
