using Microsoft.AspNet.SignalR.Client;
using Moneda.UI.Utilities;
using Moneda.UI.Viewmodels;
using Moneda.UI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Moneda.UI.Viewmodels
{
    public class ChatViewmodel : ViewmodelBase
    {
        public System.Threading.Thread Thread { get; set; }
        public string Host = "http://localhost:3465/";
        public IHubProxy Proxy { get; set; }
        public HubConnection Connection { get; set; }


        public ChatViewmodel()
        {
            Chat = new ObservableCollection<string>();
            SendCommand = new RelayCommand(SendMessage);
            Chat.Add("Velkommen til chatten");
        }

        async void SendMessage(object ibj)
        {
            await Proxy.Invoke("SendMessage", LoginViewmodel.CurrentUser, Message);
        }
        
        public void ActionWindowLoaded()
        {
            Thread = new System.Threading.Thread(() =>
            {
                Connection = new HubConnection(Host);
                Proxy = Connection.CreateHubProxy("ChatHub");
                Proxy.On<string, string>("AddMessage", (name, message) => OnSendData(name, message));
                Connection.Start();
        })
            { IsBackground = true };
            Thread.Start();
        }

        private void OnSendData(string name, string message)
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() => { Chat.Add(name + " : " + message); }));
            Message = "";
            //Chat.Add(message);
        }

        #region Properties
        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> _chat;

        public ObservableCollection<string> Chat
        {
            get { return _chat; }
            set { _chat = value; }
        }

        public ICommand SendCommand { get; private set; }
        #endregion
    }
}
