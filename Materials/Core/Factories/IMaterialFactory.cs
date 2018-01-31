using Materials.Contracts;

namespace Materials.Core.Factories
{
    internal interface IMaterialFactory
    {
        IMaterialFromLibrary SelectConcrete(string concreteType);

        IMaterialFromLibrary SelectRebarSteel(string rebarType);
    }
}
