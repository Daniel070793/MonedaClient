using Moneda.UI.Utilities;
using Moneda.UI.Viewmodels;
using MonedaClient.Model;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Moneda.UI.Views
{
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : Page, IListen
    {
        EventAggregator _eventAggregrator;
        public DashboardView()
        {
            InitializeComponent();
            _eventAggregrator = new EventAggregator();
            _eventAggregrator.Subscribe("ViewCashFlowNav",this);
            _eventAggregrator.Subscribe("DashboardError", this);
        }

        public void HandleMessage(string data)
        {
            MessageBox.Show(data, "Fejl");
        }

        public void HandleNavigation(string message, object data)
        {
            switch (message)
            {
                case "ViewCashFlowNav":
                    Window window = new ViewCashFlowView((DashboardViewmodel)data);

                    window.ShowDialog();
                    CashFlowList.UnselectAll();
                    break;
            }
        }
    }
}
