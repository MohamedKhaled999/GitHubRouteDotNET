using GitHub.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.models
{
    internal class BasicAuthenticationService : IAuthenticationService
    {
        private static List<User> USERS = new List<User>() { new User { Name ="Mohamed Khaled",Password="123456" ,Role=Role.Developer},new User { Name ="Mohamed Ahmed",Password="123456",Role = Role.Admin},
        };
        public User Userx { get; set; }
        public BasicAuthenticationService(User user)
        {
            Userx = user;
        }
        public bool AuthenticateUser()
        {
            
          return  USERS.Find(u => u.Name == Userx.Name && u.Password == Userx.Password) != null;
        }

        public  bool AuthorizeUser()
        {
            return AuthenticateUser()&& Userx.Role != Role.None;
        }


       public class User
        {
            public string Name { get; set; }
            public string Password { get; set; }
            public Role Role { get; set; }
            public User() { }
        }
    }
    public enum Role
    {   
        None,
        Guest,
        Admin,
        Developer
    }
}
