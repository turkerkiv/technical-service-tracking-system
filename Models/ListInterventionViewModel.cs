using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace technical_service_tracking_system.Models
{
    public class ListInterventionViewModel
    {
        public string TechnicianName { get; set; } = string.Empty;
        public string UsedSpareItems { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string InterventionDetails { get; set; } = string.Empty;
    }
}