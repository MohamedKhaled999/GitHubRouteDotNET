using GitHub.interfaces;
using GitHub.models;

namespace GitHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            #region Part 1

            #region Q1 : What is the primary purpose of an interface in C#?
            //a) To provide a way to implement multiple inheritance
            #endregion
            #region Q2 : Which of the following is NOT a valid access modifier for interface members in C#?
            // private
            #endregion
            #region Q3 : Can an interface contain fields in C#?
            //NO
            #endregion
            #region Q4 : In C#, can an interface inherit from another interface?
            //b) Yes, interfaces can inherit from multiple interfaces
            #endregion
            #region Q5 : Which keyword is used to implement an interface in a class in C#?
            //no any keywords
            #endregion
            #region Q6 : Can an interface contain static methods in C#?
            //b) No
            #endregion
            #region Q7 : In C#, can an interface have explicit access modifiers for its members?
            //and based on vesion of C# 
            //b) No, all members are implicitly public
            #endregion
            #region Q8 : What is the purpose of an explicit interface implementation in C#?
            //c) To allow multiple classes to implement the same interface
            #endregion
            #region Q9 : In C#, can an interface have a constructor?
            //b) No, interfaces cannot have constructors
            #endregion
            #region Q10 : How can a C# class implement multiple interfaces?
            //c) By separating interface names with commas
            #endregion
            #endregion

            #region Part 2

            #region Q1

            var circle = new Circle(10);
                var rect = new Rectangle(10, 15);
                circle.DisplayShapeInfo();
                rect.DisplayShapeInfo();

            #endregion


            #region Q2
            IAuthenticationService authenticationService  = new BasicAuthenticationService(new BasicAuthenticationService.User() { Name = "Mohamed Khaled", Password = "123456", Role = Role.Admin });
            Console.WriteLine($"Is AuthenticateUser ? {authenticationService.AuthenticateUser()}");
            Console.WriteLine($"Is AuthorizeUser    ? {authenticationService.AuthorizeUser()}");

            #endregion



            #region Q3
            Recipient recipient = new Recipient() { Name ="Mohamed Khaled" ,Id=777};
            INotificationService notification1 = new SmsNotificationService();
            INotificationService notification2 = new PushNotificationService();
            INotificationService notification3 = new EmailNotificationService();


            notification1.SendNotification(recipient,"it's good to know you");
            notification2.SendNotification(recipient,"it's good to know you");
            notification3.SendNotification(recipient,"it's good to know you");


            #endregion






            #endregion
        }
    }
}
