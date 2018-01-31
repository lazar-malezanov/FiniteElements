namespace FiniteElements.Models.Contracts
{
    internal interface ILoad
    {
        ILoadCase LoadCase { get; set; }

        double LoadCaseNumber { get; set; }

        string Type { get; }
    }
}
