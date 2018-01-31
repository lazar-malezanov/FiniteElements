using Materials.Commands.Contracts;
using Materials.Commands.SectionCommands;
using Materials.Contracts;
using Materials.Core.Contracts;
using Materials.Core.Factories;
using Materials.Core.Providers;
using Materials.Materials;
using Ninject.Modules;

namespace Materials.Container
{
    internal class MaterialModule : NinjectModule
    {
        public override void Load()
        {       
            //Providers                                                         
            this.Bind<IParser>().To<CommandParser>().InSingletonScope();
            this.Bind<ICommandProcessor>().To<CommandProcessor>().InSingletonScope();

            //Factories
            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();
            this.Bind<IMaterialFactory>().To<MaterialFactory>().InSingletonScope();

            //Materials
            this.Bind<IMaterialFromLibrary>().To<Concrete>().InSingletonScope();
            this.Bind<IMaterialFromLibrary>().To<RebarSteel>().InSingletonScope();

            //Commands
            this.Bind<ICommand>().To<CreateConcrete>().Named("concrete");
            this.Bind<ICommand>().To<CreateRebarSteel>().Named("rebarsteel");
        }
    }
}
