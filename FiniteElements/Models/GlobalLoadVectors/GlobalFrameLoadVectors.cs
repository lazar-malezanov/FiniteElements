using FiniteElements.Core.Contracts;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
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

                            globalVector[6 * (int)frameElement.Node1.Number + 0] += localLoadVector[0];
                            globalVector[6 * (int)frameElement.Node1.Number + 1] += localLoadVector[1];
                            globalVector[6 * (int)frameElement.Node1.Number + 2] += localLoadVector[2];
                            globalVector[6 * (int)frameElement.Node1.Number + 3] += localLoadVector[3];
                            globalVector[6 * (int)frameElement.Node1.Number + 4] += localLoadVector[4];
                            globalVector[6 * (int)frameElement.Node1.Number + 5] += localLoadVector[5];

                            globalVector[6 * (int)frameElement.Node2.Number + 0] += localLoadVector[6];
                            globalVector[6 * (int)frameElement.Node2.Number + 1] += localLoadVector[7];
                            globalVector[6 * (int)frameElement.Node2.Number + 2] += localLoadVector[8];
                            globalVector[6 * (int)frameElement.Node2.Number + 3] += localLoadVector[9];
                            globalVector[6 * (int)frameElement.Node2.Number + 4] += localLoadVector[10];
                            globalVector[6 * (int)frameElement.Node2.Number + 5] += localLoadVector[11];
                        }
                    }
                }

                globalLoadVectors.Add(loadCase.Number, globalVector);
            }

            return globalLoadVectors;
        }
    }
}
