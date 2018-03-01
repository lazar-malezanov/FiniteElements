﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiniteElements.Models.Contracts
{
    internal interface INodalLoad : ILoad
    {
        double LoadValue { get; }
    }
}