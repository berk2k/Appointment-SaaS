using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSystem.Application.Exceptions
{
    public class CustomValidationException : Exception
    {
        public CustomValidationException(string message) : base(message) { }
        public CustomValidationException(IEnumerable<string> errors) : base(string.Join("; ", errors)) { }
    }
}
