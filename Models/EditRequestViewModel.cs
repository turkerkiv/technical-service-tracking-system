using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using technical_service_tracking_system.Entity;

namespace technical_service_tracking_system.Models
{
    public class EditRequestViewModel
    {
        public int ServiceRequestId { get; set; }
        public int StatusId { get; set; }
        public int? FaultTypeId { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; } = string.Empty;
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; } = string.Empty;
        [Display(Name = "Fault Details")]
        public string FaultDetails { get; set; } = string.Empty;

        public List<Status> Statuses { get; set; } = new();
        public List<FaultType> FaultTypes { get; set; } = new();
    }
}