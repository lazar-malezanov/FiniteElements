namespace FiniteElements.Models.Contracts
{
    internal interface ILoadCase
    {
        string Name { get; set; }  

        double Number { get; set; }
    }
}
