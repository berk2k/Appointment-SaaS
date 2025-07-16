using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSystem.Domain.Entities
{
    public class Tenant
    {
        public Guid TenantId { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Plan { get; set; }
        public string Status { get; set; }
        public ICollection<Branch> Branches { get; set; }
        //public ICollection<User> Users { get; set; }
    }

}
