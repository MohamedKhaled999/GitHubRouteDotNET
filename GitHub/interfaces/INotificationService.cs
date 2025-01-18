using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitHub.models;

namespace GitHub.interfaces
{
    internal interface INotificationService
    {
        void SendNotification(Recipient recipient, string msg  );
    }
}
