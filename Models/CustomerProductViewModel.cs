using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace technical_service_tracking_system.Models
{
    public class CustomerProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
        public DateOnly WarrantyStartDate { get; set; }
        public DateOnly WarrantyEndDate { get; set; }
        public bool HasWarranty { get; set; }
        
    }
}