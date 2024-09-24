using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using technical_service_tracking_system.Entity;

namespace technical_service_tracking_system.Models
{
    public class AddInterventionViewModel
    {
        [Required]
        public int ServiceRequestId { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        public DateOnly? StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        public DateOnly? EndDate { get; set; }
        [Required]
        [Display(Name = "Intervention Details")]
        public string InterventionDetails { get; set; } = string.Empty;

        public List<SpareItem> SpareItems { get; set; } = new();
        public List<int> SelectedSpareItemIds { get; set; } = new();
    }
}