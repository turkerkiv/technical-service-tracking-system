using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace technical_service_tracking_system.Models
{
    public class RequestDetailsViewModel
    {
        public string RequestStatus { get; set; } = string.Empty;
        public List<ListInterventionViewModel> InterventionsViewModels { get; set; } = new();
    }
}