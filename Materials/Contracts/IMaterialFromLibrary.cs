namespace Materials.Contracts
{
    public interface IMaterialFromLibrary
    {
        string Name { get; set; }

        string Type { get; }

        double EModule { get; }

        double GModule { get; }

        int Number { get; set; }
    }
}
