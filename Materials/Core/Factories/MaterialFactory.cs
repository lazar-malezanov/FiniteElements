using Materials.Contracts;
using Materials.Materials;

namespace Materials.Core.Factories
{
    internal class MaterialFactory : IMaterialFactory
    {
        public IMaterialFromLibrary SelectConcrete(string concreteType)
        {
            return new Concrete(concreteType);
        }

        public IMaterialFromLibrary SelectRebarSteel(string rebarType)
        {
            return new RebarSteel(rebarType);
        }
    }
}
