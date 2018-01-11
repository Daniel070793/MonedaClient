using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Moneda.UI.Utilities;
using Moneda.UI.Viewmodels;
using Moneda.UI.Views;
using System.Windows;

namespace Moneda.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IAPIAccess, APIAccess>();
            container.RegisterType<IEventAggregator, EventAggregator>();

            LoginView view = new LoginView();
            LoginViewmodel vm = container.Resolve<LoginViewmodel>();
            view.DataContext = vm;
            view.Show();
        }
    }
}
