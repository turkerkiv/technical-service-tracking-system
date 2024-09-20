using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace technical_service_tracking_system.Entity
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<ServiceRequest> ServiceRequests { get; set; } = new();
    }
}