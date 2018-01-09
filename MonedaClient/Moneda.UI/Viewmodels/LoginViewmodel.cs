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
    public class LoginViewmodel
    {
        IAPIAccess API;

        string _username;
        string _password;

        public LoginViewmodel()
        {
            API = new APIAccess();

            LoginCommand = new RelayCommand(Login,CanLogin);
            CreateCommand = new RelayCommand(Create);
        }

        async void Login(object obj)
        {
            try
            {
                await API.Post("login", new User { Username = _username, Password = _password });

            }
            catch (HttpRequestException)
            {
                System.Windows.MessageBox.Show("Ingen forbindelse til API");
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
        }

        void Create(object obj)
        {

        }

        bool CanLogin(object obj)
        {
            if (!String.IsNullOrEmpty(_username) && !String.IsNullOrEmpty(_password))
            {
                return true;
            }
            return false; 
        }
        

        public ICommand LoginCommand { get; private set; }
        public ICommand CreateCommand { get; private set; }

        public string Username
        {
            get { return _username; }
            set { _username = value;}
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
    }
}
