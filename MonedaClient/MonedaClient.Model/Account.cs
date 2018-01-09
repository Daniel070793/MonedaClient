using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonedaClient.Model
{
    public class Account
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public User User { get; set; }
        public ObservableCollection<CashFlow> Transactions { get; set; }
    }
}
