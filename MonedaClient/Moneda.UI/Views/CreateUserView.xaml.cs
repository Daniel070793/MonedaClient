using Moneda.UI.Utilities;
using Moneda.UI.Viewmodels;
using System.Windows;
using System.Windows.Controls;

namespace Moneda.UI.Views
{
    /// <summary>
    /// Interaction logic for CreateUserView.xaml
    /// </summary>
    public partial class CreateUserView : Page, IListen
    {
        IEventAggregator _eventAggregator;
        public CreateUserView()
        {
            _eventAggregator = new EventAggregator();
            _eventAggregator.Subscribe("userCreatedNav", this);
            _eventAggregator.Subscribe("userCreatedError", this);

            InitializeComponent();

        }

        public void HandleMessage(string data)
        {
            MessageBox.Show(data, "Fejl");
        }

        public void HandleNavigation(string message, object data)
        {
            NavigateBack();
        }

        private void Cancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigateBack();
        }

        public void NavigateBack()
        {
            //TODO: view skal have viewmodel til datacontext + IOC hell
            DependencyContainer container = DependencyContainer.GetInstance;
            LoginViewmodel vm = container.Container.Resolve<LoginViewmodel>();
            Application.Current.MainWindow.Content = new LoginView();
        }
    }
}
