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
        private ObservableCollection<Account> _accounts;
        private Account _selectedAccount;

        public DashboardViewmodel()
        {
            _accounts = new ObservableCollection<Account>();
            ObservableCollection<CashFlow> _transactions = new ObservableCollection<CashFlow>();
            _transactions.Add(new CashFlow { Amount = 1000, Description = "Jomfru ane gade" });
            _transactions.Add(new CashFlow { Amount = -1000000m, Description = "Bajerekkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk" });

            _accounts.Add(new Account { Name = "Opsparing", Balance = 500, Transactions = _transactions });
            _accounts.Add(new Account { Name = "Lønkonto", Balance = 250.5m });
        }

        public Account SelectedAccount
        {
            get { return _selectedAccount; }
            set
            {
                _selectedAccount = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Account> Accounts
        {
            get { return _accounts; }
            set { _accounts = value; }
        }
    }
}
