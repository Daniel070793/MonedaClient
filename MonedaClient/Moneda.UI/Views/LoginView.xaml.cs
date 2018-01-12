using Microsoft.Practices.Unity;
using Moneda.UI.Utilities;
using MonedaClient.Model;
using System.Windows;
using System;
using Moneda.UI.Viewmodels;
using System.Windows.Controls;

namespace Moneda.UI.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    /// 

    //TODO: textbox focus fix
    public partial class LoginView : Page, IListen
    {
        static int _testnumber = 0;
        IEventAggregator _eventAggregator;

        public LoginView()
        {
            _testnumber++;
            Console.WriteLine(_testnumber);
            InitializeComponent();

            _eventAggregator = new EventAggregator();
            _eventAggregator.Subscribe("LoginViewError", this);
            _eventAggregator.Subscribe("Dashboard", this);
            _eventAggregator.Subscribe("CreateUserNav", this);
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
                    DashboardView dashboard = new DashboardView();
                    //TODO pass user to vm
                    dashboard.DataContext = new DashboardViewmodel();             
                    Application.Current.MainWindow.Content = dashboard;
                    break;
                case "CreateUserNav":                   
                    CreateUserView view = new CreateUserView();
                    Application.Current.MainWindow.Content = view;
                    break;
                    
            }
        }
    }
}
