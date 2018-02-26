﻿using FiniteElements.Models.Nodes;
using System.Collections.Generic;

namespace FiniteElements.Models.Contracts
{
    internal interface IFrameElement : IElement
    {  
        Node Node1 { get; }    

        Node Node2 { get; }

        double Alfa { get; }

        double ElementLength { get; }

        bool TorsionReleaseNode1 { get; set; }

        bool MomentAroundYReleaseNode1 { get; set; }

        bool MomentAroundZReleaseNode1 { get; set; }

        bool NormalReleaseNode1 { get; set; }

        bool ShearYReleaseNode1 { get; set; }

        bool ShearZReleaseNode1 { get; set; }

        bool TorsionReleaseNode2 { get; set; }

        bool MomentAroundYReleaseNode2 { get; set; }

        bool MomentAroundZReleaseNode2 { get; set; }

        bool NormalReleaseNode2 { get; set; }
    
        bool ShearYReleaseNode2 { get; set; }

        bool ShearZReleaseNode2 { get; set; }
    }
}
