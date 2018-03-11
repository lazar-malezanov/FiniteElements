using FiniteElements.Core.Contracts;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System.Collections.Generic;

namespace FiniteElements.Models
{
    internal class GlobalNodalLoadVectors : GlobalLoadVector
    {
        public GlobalNodalLoadVectors(IDatabase dbctx) : base(dbctx) { }

        public override Dictionary<int, Vector<double>> Assemble()
        {
            Dictionary<int, Vector<double>> globalLoadVectors = new Dictionary<int, Vector<double>>();

            foreach (var loadCase in this.dbctx.LoadCases)
            {
                int vectorDimension = this.dbctx.Nodes.Count * 6;
                Vector<double> globalVector = SparseVector.Create(vectorDimension, 0.0);

                foreach (var node in this.dbctx.Nodes)
                {
                    foreach (var load in node.Loads)
                    {
                        if (load.LoadCase.Number == loadCase.Number)
                        {
                            Vector<double> generatedLoad = load.GenerateLoad();

                            globalVector[6 * node.Number + 0] += generatedLoad[0];
                            globalVector[6 * node.Number + 1] += generatedLoad[1];
                            globalVector[6 * node.Number + 2] += generatedLoad[2];
                            globalVector[6 * node.Number + 3] += generatedLoad[3];
                            globalVector[6 * node.Number + 4] += generatedLoad[4];
                            globalVector[6 * node.Number + 5] += generatedLoad[5];
                        }
                    }                   
                }

                globalLoadVectors.Add(loadCase.Number, globalVector);
            }

            return globalLoadVectors;
        }
    }
}
