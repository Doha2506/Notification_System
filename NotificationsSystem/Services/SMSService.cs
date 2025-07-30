
using NotificationsSystem.Interfaces;

namespace NotificationsSystem.Services
{
    internal class SMSService : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine("Sending SMS: " + message);
        }
    }
}
