using Autofac;
using System.Linq;
using View.Locator;
using View.Service;
using View.Services.Interfaces;
using ViewModel;
using ViewModel.Builder;
using ViewModel.Interfaces;
using ViewModel.Services;
using IMessenger = MVVMBase.MessengerPattern.IMessenger;
using Messenger = MVVMBase.MessengerPattern.Messenger;

namespace View.Helper
{
    public static class Bootstraper
    {
        //public static void SetupConfiguration()
        //{
        //    var cBuilder = new ContainerBuilder();
        //    cBuilder.RegisterType<CfgRepository>().AsImplementedInterfaces();
        //    cBuilder.RegisterType<XMLFile>().AsImplementedInterfaces();

        //    var container = cBuilder.Build();
        //    IocContainer.Instance.Container = container;
        //}

        public static void SetupContainer()
        {
            var builder = new ContainerBuilder();

            //var cfgRepo = IocContainer.Instance.Container.Resolve<ICfgRepository>();
            //cfgRepo.Init();

            // Register ViewModel
            builder.RegisterAssemblyTypes(typeof(TrayViewModel).Assembly)
                .Where(t => t.Name.EndsWith("ViewModel") && !t.Name.StartsWith("Mock")).AsImplementedInterfaces();

            // register instance of Messenger as its implemented interface as a singleton class.
            builder.RegisterType<Messenger>().As<IMessenger>().SingleInstance();
            builder.RegisterType<DialogService>().As<IDialogService>().SingleInstance();
            //builder.RegisterType<TVDirectoryModelBuilder>().AsImplementedInterfaces();

            // register config repository
            //builder.RegisterType<XMLFile>().AsImplementedInterfaces();
            //builder.RegisterType<CfgRepository>().AsImplementedInterfaces();

            // Register factories and builder
            builder.RegisterType<NoteTreeViewBuilder>().AsImplementedInterfaces().SingleInstance();
            // Register helper

            // Register Services
            builder.RegisterType<NoteSaverService>().AsImplementedInterfaces().SingleInstance();

            // register ViewModelLocator
            builder.RegisterType<ViewModelLocator>().SingleInstance();

            var container = builder.Build();

            // Set container property
            IocContainer.Instance.Container = container;
        }
    }
}