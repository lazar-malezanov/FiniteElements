using Bytes2you.Validation;
using FiniteElements.Core.Contracts;
using FiniteElements.Core.Factories;
using FiniteElements.Models.Contracts;
using FiniteElements.Models.ServiceClasses;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Assign.Loads.FrameLoads.InGlobalAxisDirections.DistributedLoad.Moment
{
    internal class AssignDistributedMomentAroundGlobalZDirection : AssignCommand
    {
        private IFrameLoadFactory factory;

        public AssignDistributedMomentAroundGlobalZDirection(IDatabase dbctx, IFrameLoadFactory factory) : base(dbctx)
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
                throw new ArgumentException("Failed to parse AssignDistributedMomentAroundGlobalZDirection command parameters.");
            }

            IFrameElement frameElement = base.dbctx.FrameElements[elementId];
            ILoadCase loadCase = base.dbctx.LoadCases[loadCaseNumber];
            double gCoefficientY = (frameElement.MaterialProp.EModule * frameElement.SectionProp.MomentOfInertiaY * frameElement.SectionProp.Mju)
                / (frameElement.SectionProp.Area * frameElement.MaterialProp.GModule);

            double gCoefficientZ = (frameElement.MaterialProp.EModule * frameElement.SectionProp.MomentOfInertiaZ * frameElement.SectionProp.Mju)
                / (frameElement.SectionProp.Area * frameElement.MaterialProp.GModule);

            Vector<double> startPointEntryLoad = Vector<double>.Build.SparseOfArray(new double[] { 0, 0, loadAtStart });
            Vector<double> endPointEntryLoad = Vector<double>.Build.SparseOfArray(new double[] { 0, 0, loadAtEnd });

            Vector<double> startPointLoadVector = FrameService.InclinedLoadVector(frameElement, startPointEntryLoad);
            Vector<double> endPointLoadVector = FrameService.InclinedLoadVector(frameElement, endPointEntryLoad);

            IFrameLoad frameMomentAroundLocalX = this.factory.CreateDistributedTorsion(loadCase, frameElement.ElementLength, 0.0,
                startPointLoadVector[0], endPointLoadVector[0], loadStartsAt, loadEndsAt);

            IFrameLoad frameMomentAroundLocalY = this.factory.CreateDistributedMomentXZPlane(loadCase, frameElement.ElementLength, gCoefficientY,
                startPointLoadVector[1], endPointLoadVector[1], loadStartsAt, loadEndsAt);

            IFrameLoad frameMomentAroundLocalZ = this.factory.CreateDistributedMomentXYPlane(loadCase, frameElement.ElementLength, gCoefficientZ,
                startPointLoadVector[2], endPointLoadVector[2], loadStartsAt, loadEndsAt);

            FrameService.AddLoad(frameElement, frameMomentAroundLocalX);
            FrameService.AddLoad(frameElement, frameMomentAroundLocalY);
            FrameService.AddLoad(frameElement, frameMomentAroundLocalZ);

            return $"Distributed frame moment around global Z direction with intensities {loadAtStart} and {loadAtEnd} and Load Case Numeber {loadCaseNumber} has been assigned to element with ID {frameElement.Number}.";
        }
    }
}
