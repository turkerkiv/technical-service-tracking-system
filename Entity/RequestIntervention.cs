using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace technical_service_tracking_system.Entity
{
    public class RequestIntervention
    {
        public int Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string InterventionDetails { get; set; } = string.Empty;
        
        public int TechnicianId { get; set; }
        public User Technician { get; set; } = null!;
        public int ServiceRequestId { get; set; }
        public ServiceRequest ServiceRequest { get; set; } = null!;

        public List<SpareItemUseActivity> SpareItemUseActivities { get; set; } = new();
    }
}