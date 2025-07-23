using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSystem.Domain.Entities
{
    public class AppointmentHistory
    {
        public Guid AppointmentHistoryId { get; set; } 
        public Guid AppointmentId { get; set; } 
        public Guid ChangedByUserId { get; set; } 
        public DateTime ChangedAt { get; set; } 
        public string PropertyName { get; set; } 
        public string OldValue { get; set; } 
        public string NewValue { get; set; } 

        public Appointment Appointment { get; set; }
        public User ChangedByUser { get; set; }
    }
}

