using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace technical_service_tracking_system.Entity
{
    public class CustomerProduct
    {
        public int Id { get; set; }
        public bool HasWarranty { get; set; }
        public DateOnly WarrantyStartDate { get; set; }
        public DateOnly WarrantyEndDate { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int CustomerId { get; set; }
        public User Customer { get; set; } = null!;

        public List<ServiceRequest> ServiceRequests { get; set; } = new();

    }
}