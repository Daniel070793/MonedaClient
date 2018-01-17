using Microsoft.Practices.Unity;
using Moneda.UI.Utilities;
using MonedaClient.Model;
using System;
using System.Net.Http;
using System.Windows.Input;

namespace Moneda.UI.Viewmodels
{
    public class LoginViewmodel : ILoginViewmodel
    {
        IAPIAccess _api;
        IEventAggregator _eventAggregator;
        public static string CurrentUser;

        string _username;
        string _password;

        public LoginViewmodel(IAPIAccess api, IEventAggregator eventAggregator)
        {
            _api = api;
            _eventAggregator = eventAggregator;

            Username = "admin";
            Password = "admin";

            LoginCommand = new RelayCommand(Login, CanLogin);
            CreateCommand = new RelayCommand(Create);
        }

        async void Login(object obj)
        {
            try
            {
                await _api.Post("login", new User { Username = _username, Password = _password });
                //TODO fiks navigation
                _eventAggregator.PublishNavigation("Dashboard", new User());
            }
            catch (HttpRequestException)
            {
                _eventAggregator.PublishMessage("LoginViewError", "Ingen forbindelse til API");
            }
            catch (Exception e)
            {
                _eventAggregator.PublishMessage("LoginViewError", e.Message);
            }
       
        }

        void Create(object obj)
        {
            _eventAggregator.PublishNavigation("CreateUserNav", "hej");
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
            set
            {
                _username = value;
                CurrentUser = _username;
            }
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
        
        [Dependency]
        public IEventAggregator MyProperty
        {
            get { return _eventAggregator; }
            set { _eventAggregator = value; }
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
