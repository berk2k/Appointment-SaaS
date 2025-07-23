using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSystem.Domain.Entities
{
    public class Service
    {
        public Guid ServiceId { get; set; }
        public Guid TenantId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }

        public Tenant Tenant { get; set; }
        public ICollection<AppointmentService> AppointmentServices { get; set; }  
    }

}
