﻿using Bytes2you.Validation;
using FiniteElements.Core.Contracts;
using FiniteElements.Core.Factories;
using FiniteElements.Models.Contracts;
using FiniteElements.Models.ServiceClasses;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Assign.Loads.FrameLoads.InGlobalAxisDirections.ConcentratedLoad
{
    internal class AssignConcentratedLoadGlobalXDirection : AssignCommand
    {
        private IFrameLoadFactory factory;

        public AssignConcentratedLoadGlobalXDirection(IDatabase dbctx, IFrameLoadFactory factory) : base(dbctx)
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
                throw new ArgumentException("Failed to parse AssignConcentratedLoadGlobalXDirection command parameters.");
            }

            IFrameElement frameElement = base.dbctx.FrameElements[elementId];
            ILoadCase loadCase = base.dbctx.LoadCases[loadCaseNumber];
            double gCoefficientY = (frameElement.MaterialProp.EModule * frameElement.SectionProp.MomentOfInertiaZ * frameElement.SectionProp.Mju)
                / (frameElement.SectionProp.Area * frameElement.MaterialProp.GModule);

            double gCoefficientZ = (frameElement.MaterialProp.EModule * frameElement.SectionProp.MomentOfInertiaY * frameElement.SectionProp.Mju)
                / (frameElement.SectionProp.Area * frameElement.MaterialProp.GModule);

            Vector<double> EntryLoad = Vector<double>.Build.SparseOfArray(new double[] { loadValue, 0, 0 });

            Vector<double> LoadVector = FrameService.InclinedLoadVector(frameElement, EntryLoad);

            IFrameLoad frameLoadLocalX = this.factory.CreateConcentratedNormalLoad(loadCase, frameElement.ElementLength, 0.0,
                LoadVector[0], loadPosition);

            IFrameLoad frameLoadLocalY = this.factory.CreateConcentratedShearLoadXYPlane(loadCase, frameElement.ElementLength, gCoefficientY,
                LoadVector[1], loadPosition);

            IFrameLoad frameLoadLocalZ = this.factory.CreateConcentratedShearLoadXZPlane(loadCase, frameElement.ElementLength, gCoefficientZ,
                LoadVector[2], loadPosition);

            FrameService.AddLoad(frameElement, frameLoadLocalX);
            FrameService.AddLoad(frameElement, frameLoadLocalY);
            FrameService.AddLoad(frameElement, frameLoadLocalZ);

            return $"Concentrated frame load in global X direction with intensity {loadValue} and Load Case Numeber {loadCaseNumber} has been assigned to element with ID {frameElement.Number}.";
        }
    }
}
