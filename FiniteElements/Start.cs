using FiniteElements.Container;
using FiniteElements.Core.Contracts;
using Ninject;

namespace FiniteElements
{
    public class Start
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel(new FiniteElementsModule());
            var engine = kernel.Get<IEngine>();
            engine.Start();
        }
    }
}
