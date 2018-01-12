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
        ObservableCollection<CashFlow> _fixedCashFlows;
        Account _selectedAccount;
        Account _comboSelectedAccount;
        CashFlow _selectedCashFlow;


        public DashboardViewmodel()
        {
            _eventAggregator = new EventAggregator();
            _fixedCashFlows = new ObservableCollection<CashFlow>();
            _accounts = new ObservableCollection<Account>();
            ObservableCollection<CashFlow> _transactions = new ObservableCollection<CashFlow>();
            _transactions.Add(new CashFlow { Frequency = FrequencyEnum.Ugentlig, Amount = 1000m, Description = "Jomfru ane gade" });
            _transactions.Add(new CashFlow { Frequency = FrequencyEnum.Engang, Amount = -1000000m, Description = "Bajerekkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk" });

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
                    if (cash.Frequency != FrequencyEnum.Engang)
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

                if (_selectedCashFlow != null)
                {
                    _eventAggregator.PublishNavigation("ViewCashFlowNav", this);
                    _selectedCashFlow = null;
                    
                }

                //_selectedCashFlow = null;
                OnPropertyChanged();
            }
        }
        public Account SelectedAccount
        {
            get { return _selectedAccount; }
            set
            {
                _selectedAccount = value;
                _comboSelectedAccount = _selectedAccount;
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

        // Handles selected account in the viewcashflowview window combobox
        public Account ComboSelectedAccount
        {
            get { return _comboSelectedAccount; }
            set { _comboSelectedAccount = value; }
        }
    }
}
