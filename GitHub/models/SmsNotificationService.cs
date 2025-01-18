using GitHub.interfaces;

namespace GitHub.models
{
    public class SmsNotificationService : INotificationService
    {
        public void SendNotification(Recipient recipient, string msg)
        {
            Console.WriteLine($"Via SMS\nthe msg :\n\t {msg} \n\t\tto {recipient.Name}");
        }
    }
}