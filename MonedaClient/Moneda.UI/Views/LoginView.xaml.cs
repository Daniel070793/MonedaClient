using Moneda.UI.Utilities;
using MonedaClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Moneda.UI.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    /// 
    
    //TODO: textbox focus fix
    public partial class LoginView : Window, IListen<User>
    {
        EventAggregator eventAggregator;
        public LoginView()
        {
            InitializeComponent();
            eventAggregator = new EventAggregator();
            eventAggregator.Subscribe(this);
        }

        public void DisplayMessage(string message)
        {
            MessageBox.Show(message, "ok");
        }

        public void Navigate(string page, User obj)
        {
            switch (page)
            {
                case "Dashboard":
                    App.Current.MainWindow.Content = new DashboardView();
                    break;               
            }
            
        }
    }
}
