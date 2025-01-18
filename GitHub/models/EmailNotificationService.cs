using GitHub.interfaces;

namespace GitHub.models
{
    public class EmailNotificationService : INotificationService
    {
        public void SendNotification(Recipient recipient, string msg)
        {
            Console.WriteLine($"Via Email\nthe msg :\n\t {msg} \n\t\tto {recipient.Name}");
        }
    }
}