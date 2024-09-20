using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace technical_service_tracking_system.Entity
{
    public class SpareItemUseActivity
    {
        public int Id { get; set; }

        public int SpareItemId { get; set; }
        public SpareItem SpareItem { get; set; } = null!;
        public int RequestInterventionId { get; set; }
        public RequestIntervention RequestIntervention { get; set; } = null!;
        
    }
}