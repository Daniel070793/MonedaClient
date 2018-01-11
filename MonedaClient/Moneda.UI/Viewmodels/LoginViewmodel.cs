using Microsoft.Practices.Unity;
using Moneda.UI.Utilities;
using Moneda.UI.Views;
using MonedaClient.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Moneda.UI.Viewmodels
{
    public class LoginViewmodel
    {
        IAPIAccess _api;

        string _username;
        string _password;

        EventAggregator eventAggregator;

        public LoginViewmodel(IAPIAccess API)
        {
            _api = API;

            LoginCommand = new RelayCommand(Login,CanLogin);
            CreateCommand = new RelayCommand(Create);
            eventAggregator = new EventAggregator();
        }

        async void Login(object obj)
        {
            try
            {
                await _api.Post("login", new User { Username = _username, Password = _password });
                //TODO fiks navigation
                eventAggregator.PublishNavigation("Dashboard", new User());
            }
            catch (HttpRequestException)
            {
                eventAggregator.PublishMessage<User>("Ingen forbindelse til API");
            }
            catch (Exception e)
            {
                eventAggregator.PublishMessage<User>(e.Message);
            }
        }

        void Create(object obj)
        {
            //eventAggregator.Publish("Bruger oprettet");
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

        [Dependency]
        public IAPIAccess APIAccess
        {
            get { return _api; }
            set { _api = value; }
        }


        //public string Error{ get; private set; }

        //public string this[string columnName]
        //{
        //    get
        //    {
        //        if(columnName == "Username")
        //        {
        //            if (String.IsNullOrEmpty(Username))
        //            {
        //                Error = "Indtast brugernavn";
        //            }
        //            else
        //            {
        //                Error = null;
        //            }                 
        //        }
        //        return Error;
        //    }
        //}
    }
}
