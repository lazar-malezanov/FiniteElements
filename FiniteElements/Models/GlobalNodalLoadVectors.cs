﻿using FiniteElements.Core.Contracts;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System.Collections.Generic;

namespace FiniteElements.Models
{
    internal class GlobalNodalLoadVectors : GlobalLoadVector
    {
        public GlobalNodalLoadVectors(IDatabase dbctx) : base(dbctx) { }

        public override List<Vector<double>> Assemble()
        {
            List<Vector<double>> globalLoadVectors = new List<Vector<double>>();

            foreach (var loadCase in this.dbctx.LoadCases)
            {
                int vectorDimension = this.dbctx.Nodes.Count * 6;
                Vector<double> globalVector = SparseVector.Create(vectorDimension, 0.0);

                foreach (var node in this.dbctx.Nodes)
                {
                    foreach (var load in node.Loads)
                    {
                        if (load.LoadCase == loadCase)
                        {
                            globalVector[6 * (int)node.Number + 0] += load.LoadValue;
                            globalVector[6 * (int)node.Number + 1] += load.LoadValue;
                            globalVector[6 * (int)node.Number + 2] += load.LoadValue;
                            globalVector[6 * (int)node.Number + 3] += load.LoadValue;
                            globalVector[6 * (int)node.Number + 4] += load.LoadValue;
                            globalVector[6 * (int)node.Number + 5] += load.LoadValue;
                        }
                    }                   
                }

                globalLoadVectors.Add(globalVector);
            }

            return globalLoadVectors;
        }
    }
}
