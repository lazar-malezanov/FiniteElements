using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiniteElements.Models.Contracts
{
    internal interface IFrameLoad : ILoad
    {        
        double ElementLength { get; set; }
    }
}
