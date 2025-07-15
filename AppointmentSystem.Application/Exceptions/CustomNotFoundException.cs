using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSystem.Application.Exceptions
{
    public class CustomNotFoundException : Exception
    {
        public CustomNotFoundException(string message) : base(message) {  }
        public CustomNotFoundException(string name, object key) : base($"{name} with key {key} was not found") { }

        // example usage
        // if (user == null)
        //  throw new NotFoundException("User", id);


    }
}
