using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace technical_service_tracking_system.Models
{
    public class ListServiceRequestsViewModel
    {
        public int ServiceRequestId { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; } = string.Empty;
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        [Display(Name = "Fault Type")]
        public string FaultType { get; set; } = string.Empty;
        [Display(Name = "Fault Details")]
        public string FaultDetails { get; set; } = string.Empty;
    }
}