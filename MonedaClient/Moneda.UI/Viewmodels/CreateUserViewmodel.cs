using Moneda.UI.Utilities;
using MonedaClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Moneda.UI.Viewmodels
{
    public class CreateUserViewmodel
    {
        User _currentUser;
        IAPIAccess _api;

        public CreateUserViewmodel()
        {
            _currentUser = new User();
            _api = new APIAccess();
            CreateCommand = new RelayCommand(Create,CanCreate);
        }

        void Create(object obj)
        {

        }

        bool CanCreate(object obj)
        {
            if(!string.IsNullOrWhiteSpace(_currentUser.Username) && !string.IsNullOrWhiteSpace(_currentUser.Password))
            {
                return true;
            }
            return false;
        }

        public ICommand CreateCommand { get; private set; }

        public User CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }
    }
}
