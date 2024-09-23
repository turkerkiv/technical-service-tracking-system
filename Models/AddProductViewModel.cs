using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace technical_service_tracking_system.Models
{
    public class AddProductViewModel
    {
        [Required]
        public string Brand { get; set; } = string.Empty;
        [Required]
        public string Model { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Warranty Start Date")]
        public DateOnly WarrantyStartDate { get; set; }
        [Required]
        [Display(Name = "Warranty End Date")]
        public DateOnly WarrantyEndDate { get; set; }
    }
}
//FIXME dateonly fieldlar erroru garip veriyor nullable falan yapmak lazım