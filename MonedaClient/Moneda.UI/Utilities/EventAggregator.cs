using System.Collections.Generic;
using System.Linq;

namespace Moneda.UI.Utilities
{
    public class EventAggregator : IEventAggregator
    {
        public static Dictionary<string, IListen> subscribers = new Dictionary<string, IListen>();

        public void Subscribe(string message, IListen subscriber)
        {
            if(!subscribers.ContainsKey(message))
            {
                subscribers.Add(message, subscriber);
            }
            else
            {
                subscribers[message] = subscriber;
            }
        }

        public void Unsubscribe(string message)
        {
            subscribers.Remove(message);
        }

        public void PublishMessage(string receiver, string data)
        {
            Dictionary<string, IListen> subs = new Dictionary<string, IListen>(subscribers);

            foreach (var item in subs)
            {
                if(item.Key == receiver)
                {
                    item.Value.HandleMessage(data);
                }
            }
        }

        public void PublishNavigation(string receiver, object data)
        {
            Dictionary<string, IListen> subs = new Dictionary<string, IListen>(subscribers);

            foreach (var item in subs)
            {
                if (item.Key == receiver)
                {
                    item.Value.HandleNavigation(receiver, data);
                }
            }
        }
    }
}
