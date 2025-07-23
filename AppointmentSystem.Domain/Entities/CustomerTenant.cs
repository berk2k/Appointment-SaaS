using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSystem.Domain.Entities
{
    public class CustomerTenant
    {
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }

}
