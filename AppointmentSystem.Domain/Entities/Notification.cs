using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSystem.Domain.Entities
{
    public class Notification
    {
        public Guid NotificationId { get; set; }
        public Guid TenantId { get; set; }
        public Guid AppointmentId { get; set; }

        public string Type { get; set; }    // Email, SMS, Push
        public string Status { get; set; }  // ex -> Pending, Sent, Failed
        public string Message { get; set; }
        public DateTime? SentAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public Tenant Tenant { get; set; }
        public Appointment Appointment { get; set; }
    }
}
