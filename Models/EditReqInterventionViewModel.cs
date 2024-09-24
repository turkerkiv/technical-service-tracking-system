using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace technical_service_tracking_system.Models
{
    public class EditReqInterventionViewModel
    {
        public EditRequestViewModel EditRequestViewModel { get; set; } = null!;
        public List<ListInterventionViewModel> InterventionsViewModels { get; set; } = new();
    }
}
