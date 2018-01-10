using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moneda.UI.Utilities
{
    public class EventAggregator
    {
        static List<IListen> subscribers;
        public EventAggregator()
        {
            subscribers = new List<IListen>();
        }

        public void Subscribe(IListen model)
        {
            subscribers.Add(model);
        }

        public void Unsubscribe(IListen model)
        {
            subscribers.Remove(model);
        }

        public void PublishMessage(string obj)
        {
            foreach(var item in subscribers.OfType<IListen<string>>())
            {
                item.DisplayMessage(obj);
            }
        }

        public void PublishNavigation<T1, T2>(T1 page, T2 obj)
        {
            foreach (var item in subscribers.OfType<IListen<T1>>())
            {
                item.Handle(obj);
            }
        }
    }
    
}
