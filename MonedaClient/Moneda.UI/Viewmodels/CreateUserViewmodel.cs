using Moneda.UI.Utilities;
using MonedaClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Moneda.UI.Viewmodels
{
    public class CreateUserViewmodel
    {
        User _currentUser;
        IAPIAccess _api;
        IEventAggregator _eventAggregator;

        public CreateUserViewmodel()
        {
            _eventAggregator = new EventAggregator();
            _currentUser = new User();
            _api = new APIAccess();
            CreateCommand = new RelayCommand(Create,CanCreate);
        }

        async void Create(object obj)
        {
            try
            {
                await _api.Post("/users/create", _currentUser);
                _eventAggregator.PublishNavigation("userCreatedNav", null);
            }
            catch (HttpRequestException)
            {
                _eventAggregator.PublishMessage("userCreatedError", "Ingen forbindelse til API");
            }
            catch (Exception e)
            {
                _eventAggregator.PublishMessage("userCreatedError", e.Message);
            }
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
