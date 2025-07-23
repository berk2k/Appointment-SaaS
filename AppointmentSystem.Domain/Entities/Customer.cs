using AppointmentSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSystem.Domain.Entities
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public Email Email { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<CustomerTenant> CustomerTenants { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }


}
