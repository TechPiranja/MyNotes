using Autofac;
using System.Windows;
using View.Helper;
using View.Service.Interfaces;

namespace View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //Bootstraper.SetupConfiguration();
            Bootstraper.SetupContainer();
            IocContainer.Instance.Container.Resolve<IDialogService>();
            base.OnStartup(e);
        }
    }
}
