using FiniteElements.Container;
using FiniteElements.Core.Contracts;
using Ninject;

namespace FiniteElements
{
    public class Start
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel(new FiniteElementCulvertModule());
            var engine = kernel.Get<IEngine>();
            engine.Start();
        }
    }
}
