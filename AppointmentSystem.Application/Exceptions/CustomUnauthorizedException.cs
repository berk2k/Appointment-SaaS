using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSystem.Application.Exceptions
{
    public class CustomUnauthorizedException : Exception
    {
        public CustomUnauthorizedException(string message) : base(message) { }
        public CustomUnauthorizedException() : base("Unauthorized access") { }
    }
}
