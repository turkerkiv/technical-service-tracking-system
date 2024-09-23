using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace technical_service_tracking_system.Models
{
    public class ServiceRequestViewModel
    {
        public int CustomerProductId { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; } = string.Empty;
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; } = string.Empty;
        [Display(Name = "Warranty Start Date")]
        public DateOnly WarrantyStartDate { get; set; }
        [Display(Name = "Warranty End Date")]
        public DateOnly WarrantyEndDate { get; set; }
        [Display(Name = "Has Warranty")]
        public bool HasWarranty { get; set; }
        [Required]
        [Display(Name = "Fault Details")]
        public string FaultDetails { get; set; } = string.Empty;
        
    }
}