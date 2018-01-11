using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Moneda.UI.Utilities;
using Moneda.UI.Viewmodels;
using Moneda.UI.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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

            //UnityConfigurationSection configSection = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            //configSection.Configure(container);

            LoginView view = new LoginView();
            LoginViewmodel vm = container.Resolve<LoginViewmodel>();
            view.DataContext = vm;
            view.Show();
        }
    }
}
