using FiniteElements.Adapters;
using FiniteElements.Commands.Assign;
using FiniteElements.Commands.Contracts;
using FiniteElements.Commands.Creating;
using FiniteElements.Commands.Listing;
using FiniteElements.Commands.Showing;
using FiniteElements.ContractsForExternalLibraries;
using FiniteElements.Core;
using FiniteElements.Core.Contracts;
using FiniteElements.Core.Factories;
using FiniteElements.Core.Providers;
using FiniteElements.Models.Contracts;
using FiniteElements.Models.FrameModels.FrameElements;
using FiniteElements.Models.FrameModels.FrameLoads;
using FrameSections;
using Materials;
using Ninject.Modules;

namespace FiniteElements.Container
{
    internal class FiniteElementCulvertModule : NinjectModule
    {
        public override void Load()
        {
            //Factories
            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();
            this.Bind<IElementFactory>().To<ElementFactory>().InSingletonScope();
            this.Bind<IFrameLoadFactory>().To<FrameLoadFactory>().InSingletonScope();

            //Providers
            this.Bind<IParser>().To<CommandParser>().InSingletonScope();
            this.Bind<ICommandProcessor>().To<CommandProcessor>().InSingletonScope();
            this.Bind<IReader>().To<ConsoleReader>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();
            this.Bind<IDatabase>().To<Database>().InSingletonScope();
            this.Bind<IEngine>().To<Engine>().InSingletonScope();

            //Models
            this.Bind<IFrameElement>().To<FrameElement>().InSingletonScope();
            this.Bind<IFrameSection>().To<FrameSectionAdapter>().InSingletonScope();
            this.Bind<IMaterial>().To<MaterialAdapter>().InSingletonScope();            

            //External Libraries and Adapters
            this.Bind<IExternalFrameSectionLibrary>().To<FrameSectionLibraryAdapter>().InSingletonScope();
            this.Bind<IExternalMaterialLibrary>().To<MaterialLibraryAdapter>().InSingletonScope();
            this.Bind<IFrameSectionLibrary>().To<FrameSectionLibrary>().InSingletonScope();
            this.Bind<IMaterialLibrary>().To<MaterialLibrary>().InSingletonScope();

            //Assign Commands
            this.Bind<ICommand>().To<AssignFrameSection>().Named("assignsection");
            this.Bind<ICommand>().To<AssignLinearlyDistributedLoadToFrame>().Named("assignlinearlydistributedloadtoframe");
            this.Bind<ICommand>().To<AssignMaterialToFrameElement>().Named("assignmaterial");

            //Create Commands
            this.Bind<ICommand>().To<CreateFrameElement>().Named("createelement");
            this.Bind<ICommand>().To<CreateFrameSection>().Named("createframesection");
            this.Bind<ICommand>().To<CreateLoadCase>().Named("createloadcase");
            this.Bind<ICommand>().To<CreateMaterial>().Named("creatematerial");
            this.Bind<ICommand>().To<CreateNode>().Named("createnode");

            //List Commands
            this.Bind<ICommand>().To<ListFrameElements>().Named("listframeelements");
            this.Bind<ICommand>().To<ListFrameSections>().Named("listframesections");
            this.Bind<ICommand>().To<ListMaterials>().Named("listmaterials");
            this.Bind<ICommand>().To<ListNodes>().Named("listnodes");
            
            //Show Commands
            this.Bind<ICommand>().To<ShowFrameElement>().Named("showframeelement");
            this.Bind<ICommand>().To<ShowFrameSection>().Named("showframesection");
            this.Bind<ICommand>().To<ShowMaterial>().Named("showmaterial");
            this.Bind<ICommand>().To<ShowNode>().Named("shownode");           
        }
    }
}
