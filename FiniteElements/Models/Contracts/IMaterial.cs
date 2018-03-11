namespace FiniteElements.Models.Contracts
{
    internal interface IMaterial
    {
        string Name { get; set; }

        string Type { get; }

        double EModule { get; }

        double GModule { get; }

        int Number { get; set; }
    }
}
