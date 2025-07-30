namespace NotificationsSystem.Services
{
    internal class Notifier
    {
        public delegate void NotifierDelegate(string message);

        public NotifierDelegate OnNotificationSent;

        public Notifier(){}

        public void Send(string message)
        {
            OnNotificationSent?.Invoke(message);
        }

    }
}
