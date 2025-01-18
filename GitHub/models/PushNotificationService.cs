using GitHub.interfaces;

namespace GitHub.models
{
    public class PushNotificationService : INotificationService
    {
        public void SendNotification(Recipient recipient, string msg)
        {
            Console.WriteLine($"Via Push-Notification\nthe msg :\n\t {msg} \n\t\tto {recipient.Name}");
        }
    }
}