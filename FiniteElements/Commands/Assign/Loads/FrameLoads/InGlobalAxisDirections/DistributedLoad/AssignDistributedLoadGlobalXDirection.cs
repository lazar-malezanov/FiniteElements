using Bytes2you.Validation;
using FiniteElements.Core.Contracts;
using FiniteElements.Core.Factories;
using FiniteElements.Models.Contracts;
using FiniteElements.Models.ServiceClasses;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Assign.Loads.FrameLoads.InGlobalAxisDirections.DistributedLoad
{
    internal class AssignDistributedLoadGlobalXDirection : AssignCommand
    {
        private IFrameLoadFactory factory;

        public AssignDistributedLoadGlobalXDirection(IDatabase dbctx, IFrameLoadFactory factory) : base(dbctx)
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
                throw new ArgumentException("Failed to parse AssignDistributedLoadGlobalXDirection command parameters.");
            }

            IFrameElement frameElement = base.dbctx.FrameElements[elementId];
            ILoadCase loadCase = base.dbctx.LoadCases[loadCaseNumber];
            double gCoefficientY = (frameElement.MaterialProp.EModule * frameElement.SectionProp.MomentOfInertiaZ * frameElement.SectionProp.Mju)
                / (frameElement.SectionProp.Area * frameElement.MaterialProp.GModule);

            double gCoefficientZ = (frameElement.MaterialProp.EModule * frameElement.SectionProp.MomentOfInertiaY * frameElement.SectionProp.Mju)
                / (frameElement.SectionProp.Area * frameElement.MaterialProp.GModule);

            Vector<double> startPointEntryLoad = Vector<double>.Build.SparseOfArray(new double[] { loadAtStart, 0, 0 });
            Vector<double> endPointEntryLoad = Vector<double>.Build.SparseOfArray(new double[] { loadAtEnd, 0, 0 });

            Vector<double> startPointLoadVector = FrameService.InclinedLoadVector(frameElement, startPointEntryLoad);
            Vector<double> endPointLoadVector = FrameService.InclinedLoadVector(frameElement, endPointEntryLoad);

            IFrameLoad frameLoadLocalX = this.factory.CreateDistributedNormalLoad(loadCase, frameElement.ElementLength, 0.0,
                startPointLoadVector[0], endPointLoadVector[0], loadStartsAt, loadEndsAt);

            IFrameLoad frameLoadLocalY = this.factory.CreateDistributedShearLoadXYPlane(loadCase, frameElement.ElementLength, gCoefficientY,
                startPointLoadVector[2], endPointLoadVector[2], loadStartsAt, loadEndsAt);

            IFrameLoad frameLoadLocalZ = this.factory.CreateDistributedShearLoadXZPlane(loadCase, frameElement.ElementLength, gCoefficientZ,
                startPointLoadVector[1], endPointLoadVector[1], loadStartsAt, loadEndsAt);

            FrameService.AddLoad(frameElement, frameLoadLocalX);
            FrameService.AddLoad(frameElement, frameLoadLocalY);
            FrameService.AddLoad(frameElement, frameLoadLocalZ);

            return $"Distributed frame load in global X direction with intensities {loadAtStart} and {loadAtEnd} and Load Case Numeber {loadCaseNumber} has been assigned to element with ID {frameElement.Number}.";
        }
    }
}
