using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace technical_service_tracking_system.Models
{
    public class ListSpareItemViewModel
    {
        public int SpareItemId { get; set; }
        [Display(Name = "Spare Item Name")]
        public string SpareItemName { get; set; } = string.Empty;
        public int Stock { get; set; }
    }
}