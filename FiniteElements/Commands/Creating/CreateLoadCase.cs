using FiniteElements.Core.Contracts;
using FiniteElements.Models.Contracts;
using FiniteElements.Models.LoadCases;
using System;
using System.Collections.Generic;

namespace FiniteElements.Commands.Creating
{
    internal class CreateLoadCase : CreateCommand
    {
        public CreateLoadCase(IDatabase dbctx) : base(dbctx) { }

        public override string Execute(IList<string> parameters)
        {
            string name;
            
            try
            {
                name = parameters[0];
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateLoadCase command parameters.");
            }

            ILoadCase loadCase = new LoadCase(name);

            base.dbctx.LoadCases.Add(loadCase);
            loadCase.Number = base.dbctx.LoadCases.Count - 1;
            return $"Load Case with ID {loadCase.Number} was created.";
        }
    }
}
