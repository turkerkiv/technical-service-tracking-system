using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace technical_service_tracking_system.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

     
        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;
        public List<CustomerProduct> CustomerProducts { get; set; } = new();
        public List<ServiceRequest> ServiceRequests { get; set; } = new();
        public List<RequestIntervention> RequestInterventions { get; set; } = new();
    }
}