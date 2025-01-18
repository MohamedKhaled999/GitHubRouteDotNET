using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.interfaces
{
    internal interface IAuthenticationService
    {
       bool AuthenticateUser();
       bool AuthorizeUser();

    }
}
