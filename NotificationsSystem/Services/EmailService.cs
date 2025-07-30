using NotificationsSystem.Interfaces;

namespace NotificationsSystem.Services
{
    internal class EmailService : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine("Sending Email: " + message);
        }
    }
}
