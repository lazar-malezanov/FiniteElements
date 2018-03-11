namespace FiniteElements.Models.Contracts
{
    internal interface ILoadCase
    {
        string Name { get; set; }  

        int Number { get; set; }
    }
}
