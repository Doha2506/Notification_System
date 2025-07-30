using NotificationsSystem.Interfaces;

namespace NotificationsSystem.Services
{
    internal class PushNotificationService : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine("Sending Push Notification: " + message);
        }
    }
}
