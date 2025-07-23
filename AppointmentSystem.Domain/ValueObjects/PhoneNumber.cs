using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSystem.Domain.ValueObjects
{
    public class PhoneNumber : ValueObject
    {
        public string Value { get; }

        private PhoneNumber() { }

        public PhoneNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 10)
                throw new ArgumentException("Invalid phone number");

            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString() => Value;
    }

}
