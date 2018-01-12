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
            DependencyContainer container = DependencyContainer.GetInstance;
            MainMoneda view = new MainMoneda();
            LoginView loginview = new LoginView();
            LoginViewmodel vm = container.Container.Resolve<LoginViewmodel>();
            loginview.DataContext = vm;
            view.Content = loginview;
            view.Show();
        }
    }
}
