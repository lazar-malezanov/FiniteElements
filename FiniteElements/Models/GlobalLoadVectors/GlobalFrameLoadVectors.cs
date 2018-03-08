using FiniteElements.Core.Contracts;
using FiniteElements.Models.ServiceClasses;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;

namespace FiniteElements.Models.GlobalLoadVectors
{
    internal class GlobalFrameLoadVectors : GlobalLoadVector
    {
        public GlobalFrameLoadVectors(IDatabase dbctx) : base(dbctx) { }

        public override Dictionary<double, Vector<double>> Assemble()
        {
            Dictionary<double, Vector<double>> globalLoadVectors = new Dictionary<double, Vector<double>>();

            foreach (var loadCase in this.dbctx.LoadCases)
            {
                int vectorDimension = this.dbctx.Nodes.Count * 6;
                Vector<double> globalVector = SparseVector.Create(vectorDimension, 0.0);

                foreach (var frameElement in this.dbctx.FrameElements)
                {
                    foreach (var load in frameElement.Loads)
                    {
                        if (load.LoadCase.Number == loadCase.Number)
                        {
                            Vector<double> localLoadVector = load.GenerateLoad();
                            Vector<double> globalLoadVector = FrameService.TransformationMatrix(frameElement).Transpose() * localLoadVector;

                            double constant = Math.Pow(10.0, -10.0);
                            for (int i = 0; i < globalLoadVector.Count; i++)
                            {
                                globalLoadVector[i] = Math.Round(globalLoadVector[i], 5);
                            }

                            globalVector[6 * (int)frameElement.Node1.Number + 0] += globalLoadVector[0];
                            globalVector[6 * (int)frameElement.Node1.Number + 1] += globalLoadVector[1];
                            globalVector[6 * (int)frameElement.Node1.Number + 2] += globalLoadVector[2];
                            globalVector[6 * (int)frameElement.Node1.Number + 3] += globalLoadVector[3];
                            globalVector[6 * (int)frameElement.Node1.Number + 4] += globalLoadVector[4];
                            globalVector[6 * (int)frameElement.Node1.Number + 5] += globalLoadVector[5];

                            globalVector[6 * (int)frameElement.Node2.Number + 0] += globalLoadVector[6];
                            globalVector[6 * (int)frameElement.Node2.Number + 1] += globalLoadVector[7];
                            globalVector[6 * (int)frameElement.Node2.Number + 2] += globalLoadVector[8];
                            globalVector[6 * (int)frameElement.Node2.Number + 3] += globalLoadVector[9];
                            globalVector[6 * (int)frameElement.Node2.Number + 4] += globalLoadVector[10];
                            globalVector[6 * (int)frameElement.Node2.Number + 5] += globalLoadVector[11];
                        }
                    }
                }

                globalLoadVectors.Add(loadCase.Number, globalVector);
            }

            return globalLoadVectors;
        }
    }
}
