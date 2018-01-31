using FiniteElements.Core.Contracts;
using FiniteElements.Models.Contracts;
using FiniteElements.Models.ExtensionMethods;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Showing
{
    internal class ShowFrameSection : ShowCommand
    {
        public ShowFrameSection(IDatabase dbctx) : base(dbctx) { }

        public override string Execute(IList<string> parameters)
        {
            int sectionId;      

            try
            {
                sectionId = int.Parse(parameters[0]);   
            }
            catch
            {
                throw new ArgumentException("Failed to parse ShowFrameSection command parameters.");
            }  

            IFrameSection frameSection = base.dbctx.FrameSections[sectionId];                                
            string result = frameSection.AsString();            

            return result;
        }
    }
}
