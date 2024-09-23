using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace technical_service_tracking_system.Entity
{
    public class ServiceRequest
    {
        public int Id { get; set; }
        public string FaultDetails { get; set; } = string.Empty;
        public int TicketNumber { get; set; }
        public DateOnly RequestDate { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; } = null!;
        public int CustomerProductId { get; set; }
        public CustomerProduct CustomerProduct { get; set; } = null!;
        public int CustomerId { get; set; }
        public User Customer { get; set; } = null!;
        public int? FaultTypeId { get; set; }
        public FaultType? FaultType { get; set; } = null!;

        public List<RequestIntervention> RequestInterventions { get; set; } = new();
    }
}