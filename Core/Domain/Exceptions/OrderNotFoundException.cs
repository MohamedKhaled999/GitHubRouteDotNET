using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class OrderNotFoundException:NotFoundException
    {

        public OrderNotFoundException(Guid id):base($"The Order with id: {id}") { }
        public OrderNotFoundException(string email):base($"The Order with email: {email}") { }
    }
}
