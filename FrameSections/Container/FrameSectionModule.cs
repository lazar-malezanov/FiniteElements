using FrameSections.Commands.Contracts;
using FrameSections.Commands.SectionCommands;
using FrameSections.Contracts;
using FrameSections.Core.Contracts;
using FrameSections.Core.Factories;
using FrameSections.Core.Providers;
using FrameSections.Sections;
using Ninject.Modules;

namespace FrameSections.Container
{
    internal class FrameSectionModule : NinjectModule
    {
        public override void Load()
        {   
            //Providers
            this.Bind<IParser>().To<CommandParser>().InSingletonScope();
            this.Bind<ICommandProcessor>().To<CommandProcessor>().InSingletonScope();

            //Factories
            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();
            this.Bind<IFrameSectionFactory>().To<FrameSectionFactory>().InSingletonScope();

            //Sections
            this.Bind<ISection>().To<RectangularSection>().InSingletonScope();
            this.Bind<ISection>().To<CircularSection>().InSingletonScope();

            //Commands
            this.Bind<ICommand>().To<Rectangular>().Named("rectangular");
            this.Bind<ICommand>().To<Circular>().Named("circular");

        }
    }
}
