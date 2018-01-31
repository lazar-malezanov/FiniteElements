using FiniteElements.Models.Nodes;
using System.Collections.Generic;

namespace FiniteElements.Models.Contracts
{
    internal interface IFrameElement : IElement
    {  
        Node Node1 { get; }    

        Node Node2 { get; }

        double Alfa { get; }

        double ElementLength { get; }     
    }
}
