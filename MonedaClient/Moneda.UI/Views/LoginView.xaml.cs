using Microsoft.Practices.Unity;
using Moneda.UI.Utilities;
using MonedaClient.Model;
using System.Windows;
using System;
using Moneda.UI.Viewmodels;

namespace Moneda.UI.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    /// 
    
    //TODO: textbox focus fix
    public partial class LoginView : Window, IListen
    {
        IEventAggregator _eventAggregator;

        public LoginView()
        { 
            InitializeComponent();

            _eventAggregator = new EventAggregator();
            _eventAggregator.Subscribe("LoginViewError", this);
            _eventAggregator.Subscribe("Dashboard", this);
        }

        public void HandleMessage(string data)
        {
            MessageBox.Show(data,"Fejl");
        }

        public void HandleNavigation(string message, object data)
        {
            switch (message)
            {
                case "Dashboard":
                    _eventAggregator.Unsubscribe(message);
                    DashboardView dashboard = new DashboardView();
                    //TODO pass user to vm
                    dashboard.DataContext = new DashboardViewmodel();             
                    Application.Current.MainWindow.Content = dashboard;
                    break;
            }
        }
    }
}
