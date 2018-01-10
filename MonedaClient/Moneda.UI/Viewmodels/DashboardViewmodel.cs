using Moneda.UI.Utilities;
using MonedaClient.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moneda.UI.Viewmodels
{
    public class DashboardViewmodel : ViewmodelBase
    {
        EventAggregator _eventAggregator;
        ObservableCollection<Account> _accounts;
        Account _selectedAccount;
        ObservableCollection<CashFlow> _fixedCashFlows;
        CashFlow _selectedCashFlow;

        public DashboardViewmodel()
        {
            _eventAggregator = new EventAggregator();
            _fixedCashFlows = new ObservableCollection<CashFlow>();
            _accounts = new ObservableCollection<Account>();
            ObservableCollection<CashFlow> _transactions = new ObservableCollection<CashFlow>();
            _transactions.Add(new CashFlow { Frequency = FrequencyEnum.Weekly, Amount = 1000m, Description = "Jomfru ane gade" });
            _transactions.Add(new CashFlow { Frequency = FrequencyEnum.Single, Amount = -1000000m, Description = "Bajerekkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk" });

            _accounts.Add(new Account { Name = "Opsparing", Balance = 500, Transactions = _transactions });
            _accounts.Add(new Account { Name = "Lønkonto", Balance = 250.5m });       

        }

        private void SortCashflows()
        {
            _fixedCashFlows.Clear();
            if (_selectedAccount.Transactions != null)
            {               
                foreach (var cash in _selectedAccount.Transactions)
                {
                    if (cash.Frequency != FrequencyEnum.Single)
                    {
                        _fixedCashFlows.Add(cash);
                    }
                }
            }                       
        }

        public CashFlow SelectedCashFlow
        {
            get { return _selectedCashFlow; }
            set
            {
                _selectedCashFlow = value;
                _eventAggregator.PublishNavigation("ViewCashFlow", _selectedCashFlow);
            }
        }

        public Account SelectedAccount
        {
            get { return _selectedAccount; }
            set
            {
                _selectedAccount = value;
                OnPropertyChanged();
                SortCashflows();
            }
        }
        public ObservableCollection<CashFlow> FixedCashFlows
        {
            get { return _fixedCashFlows; }
            set
            {
                _fixedCashFlows = value;
            }
        }
        public ObservableCollection<Account> Accounts
        {
            get { return _accounts; }
            set { _accounts = value; }
        }
    }
}
