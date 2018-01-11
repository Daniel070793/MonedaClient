namespace Moneda.UI.Utilities
{
    public interface IEventAggregator
    {
        void PublishMessage(string receiver, string data);
        void PublishNavigation(string receiver, object data);
        void Subscribe(string message, IListen subscriber);
        void Unsubscribe(string message);
    }
}