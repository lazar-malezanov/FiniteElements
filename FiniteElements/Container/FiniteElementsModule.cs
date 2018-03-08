using FiniteElements.Adapters;
using FiniteElements.Commands;
using FiniteElements.Commands.Assemble.AssembleLoadVectors;
using FiniteElements.Commands.Assemble.AssembleStiffnessMatrices;
using FiniteElements.Commands.Assign;
using FiniteElements.Commands.Assign.Loads.FrameLoads.InGlobalAxisDirections.ConcentratedLoad;
using FiniteElements.Commands.Assign.Loads.FrameLoads.InGlobalAxisDirections.DistributedLoad;
using FiniteElements.Commands.Assign.Loads.NodalLoads;
using FiniteElements.Commands.Assign.Releases;
using FiniteElements.Commands.Assign.Springs;
using FiniteElements.Commands.Assign.Supports;
using FiniteElements.Commands.Contracts;
using FiniteElements.Commands.Creating;
using FiniteElements.Commands.Listing;
using FiniteElements.Commands.Listing.Results;
using FiniteElements.Commands.Showing;
using FiniteElements.Commands.Solvers;
using FiniteElements.ContractsForExternalLibraries;
using FiniteElements.Core;
using FiniteElements.Core.Contracts;
using FiniteElements.Core.Factories;
using FiniteElements.Core.Providers;
using FiniteElements.Models.Contracts;
using FiniteElements.Models.FrameModels.FrameElements;
using FrameSections;
using Materials;
using Ninject.Modules;

namespace FiniteElements.Container
{
    internal class FiniteElementsModule : NinjectModule
    {
        public override void Load()
        {
            //Factories
            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();
            this.Bind<IElementFactory>().To<ElementFactory>().InSingletonScope();
            this.Bind<IFrameLoadFactory>().To<FrameLoadFactory>().InSingletonScope();
            this.Bind<IGlobalLoadVectorFactory>().To<GlobalLoadVectorFactory>().InSingletonScope();
            this.Bind<IGlobalStiffnessMatrixFactory>().To<GlobalStiffnessMatrixFactory>().InSingletonScope();

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

            //Assemble Commands
            ////Assemble Load Vectors
            this.Bind<ICommand>().To<AssembleGlobalFrameLoadVectors>().Named("assembleglobalframeloadvectors");
            this.Bind<ICommand>().To<AssembleGlobalNodeLoadVectors>().Named("assembleglobalnodeloadvectors");

            ////Assemble Stiffness Matrix
            this.Bind<ICommand>().To<AssembleGlobalFrameStiffnessMatrix>().Named("assembleglobalframestiffnessmatrix");
            this.Bind<ICommand>().To<AssembleGlobalNodeStiffnessMatrix>().Named("assembleglobalnodestiffnessmatrix");

            //Assign Commands
            this.Bind<ICommand>().To<AssignFrameSection>().Named("assignsection");
            this.Bind<ICommand>().To<AssignMaterialToFrameElement>().Named("assignmaterial");

            ////Concentrated Loads
            //////Local
            this.Bind<ICommand>().To<AssignConcentratedMomentXYPlaneToFrame>().Named("assignconcentratedmomentxyplanetoframe");
            this.Bind<ICommand>().To<AssignConcentratedMomentXZPlaneToFrame>().Named("assignconcentratedmomentxzplanetoframe");
            this.Bind<ICommand>().To<AssignConcentratedNormalLoadToFrame>().Named("assignconcentratednormalloadtoframe");
            this.Bind<ICommand>().To<AssignConcentratedShearLoadXYPlaneToFrame>().Named("assignconcentratedshearloadxyplanetoframe");
            this.Bind<ICommand>().To<AssignConcentratedShearLoadXZPlaneToFrame>().Named("assignconcentratedshearloadxzplanetoframe");
            this.Bind<ICommand>().To<AssignConcentratedTorsionToFrame>().Named("assignconcentratedtorsiontoframe");

            //////Global
            this.Bind<ICommand>().To<AssignConcentratedLoadGlobalXDirection>().Named("assignconcentratedloadglobalxdirection");
            this.Bind<ICommand>().To<AssignConcentratedLoadGlobalYDirection>().Named("assignconcentratedloadglobalydirection");
            this.Bind<ICommand>().To<AssignConcentratedLoadGlobalZDirection>().Named("assignconcentratedloadglobalzdirection");

            ////Distributed Loads
            //////Local
            this.Bind<ICommand>().To<AssignDistributedMomentXYPlaneToFrame>().Named("assigndistributedmomentxyplanetoframe");
            this.Bind<ICommand>().To<AssignDistributedMomentXZPlaneToFrame>().Named("assigndistributedmomentxzplanetoframe");
            this.Bind<ICommand>().To<AssignDistributedNormalLoadToFrame>().Named("assigndistributednormalloadtoframe");
            this.Bind<ICommand>().To<AssignDistributedShearLoadXYPlaneToFrame>().Named("assigndistributedshearloadxyplanetoframe");
            this.Bind<ICommand>().To<AssignDistributedShearLoadXZPlaneToFrame>().Named("assigndistributedshearloadxzplanetoframe");
            this.Bind<ICommand>().To<AssignDistributedTorsionToFrame>().Named("assigndistributedtorsiontoframe");

            //////Global
            this.Bind<ICommand>().To<AssignDistributedLoadGlobalXDirection>().Named("assigndistributedloadglobalxdirection");
            this.Bind<ICommand>().To<AssignDistributedLoadGlobalYDirection>().Named("assigndistributedloadglobalydirection");
            this.Bind<ICommand>().To<AssignDistributedLoadGlobalZDirection>().Named("assigndistributedloadglobalzdirection");

            ////Moment Releases
            this.Bind<ICommand>().To<AssignMomentAroundYReleaseNode1>().Named("assignmomentaroundyreleasenode1");
            this.Bind<ICommand>().To<AssignMomentAroundYReleaseNode2>().Named("assignmomentaroundyreleasenode2");
            this.Bind<ICommand>().To<AssignMomentAroundZReleaseNode1>().Named("assignmomentaroundzreleasenode1");
            this.Bind<ICommand>().To<AssignMomentAroundZReleaseNode2>().Named("assignmomentaroundzreleasenode2");
            this.Bind<ICommand>().To<AssignTorsionReleaseAtNode1>().Named("assigntorsionreleaseatnode1");
            this.Bind<ICommand>().To<AssignTorsionReleaseAtNode2>().Named("assigntorsionreleaseatnode2");

            ////Force Releases
            this.Bind<ICommand>().To<AssignShearYReleaseNode1>().Named("assignshearyreleasenode1");
            this.Bind<ICommand>().To<AssignShearYReleaseNode2>().Named("assignshearyreleasenode2");
            this.Bind<ICommand>().To<AssignShearZReleaseNode1>().Named("assignshearzreleasenode1");
            this.Bind<ICommand>().To<AssignShearZReleaseNode2>().Named("assignshearzreleasenode2");
            this.Bind<ICommand>().To<AssignNormalReleaseAtNode1>().Named("assignnormalreleaseatnode1");
            this.Bind<ICommand>().To<AssignNormalReleaseAtNode2>().Named("assignnormalreleaseatnode2");

            ////Nodal Forces and Moments
            this.Bind<ICommand>().To<AssignForceXToNode>().Named("assignforcextonode");
            this.Bind<ICommand>().To<AssignForceYToNode>().Named("assignforceytonode");
            this.Bind<ICommand>().To<AssignForceZToNode>().Named("assignforceztonode");
            this.Bind<ICommand>().To<AssignMomentAroundXToNode>().Named("assignmomentaroundxtonode");
            this.Bind<ICommand>().To<AssignMomentAroundYToNode>().Named("assignmomentaroundytonode");
            this.Bind<ICommand>().To<AssignMomentAroundZToNode>().Named("assignmomentaroundztonode");

            ////Supports at Nodes
            this.Bind<ICommand>().To<AssignRxSupportToNode>().Named("assignrxsupporttonode");
            this.Bind<ICommand>().To<AssignRySupportToNode>().Named("assignrysupporttonode");
            this.Bind<ICommand>().To<AssignRzSupportToNode>().Named("assignrzsupporttonode");
            this.Bind<ICommand>().To<AssignXSupportToNode>().Named("assignxsupporttonode");
            this.Bind<ICommand>().To<AssignYSupportToNode>().Named("assignysupporttonode");
            this.Bind<ICommand>().To<AssignZSupportToNode>().Named("assignzsupporttonode");

            ////Springs at Nodes
            this.Bind<ICommand>().To<AssignRxSpringToNode>().Named("assignrxspringtonode");
            this.Bind<ICommand>().To<AssignRySpringToNode>().Named("assignryspringtonode");
            this.Bind<ICommand>().To<AssignRzSpringToNode>().Named("assignrzspringtonode");
            this.Bind<ICommand>().To<AssignXSpringToNode>().Named("assignxspringtonode");
            this.Bind<ICommand>().To<AssignYSpringToNode>().Named("assignyspringtonode");
            this.Bind<ICommand>().To<AssignZSpringToNode>().Named("assignzspringtonode");

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

            //Generate local stiffness matrices
            this.Bind<ICommand>().To<GenerateLocalFrameStiffnessMatrices>().Named("generatelocalframestiffnessmatrices");
            this.Bind<ICommand>().To<GenerateGlobalFrameStiffnessMatrices>().Named("generateglobalframestiffnessmatrices");

            //Form Global Load Vectors
            this.Bind<ICommand>().To<FormGlobalLoadVectors>().Named("formgloballoadvectors");
            this.Bind<ICommand>().To<FormGlobalStiffnessMatrix>().Named("formglobalstiffnessmatrix");

            //Solvers
            ////Static solver
            this.Bind<ICommand>().To<StaticSolver>().Named("staticsolver");

            //Results
            this.Bind<ICommand>().To<ListDisplacements>().Named("listdisplacements");
            this.Bind<ICommand>().To<ListReactions>().Named("listreactions");
        }
    }
}
