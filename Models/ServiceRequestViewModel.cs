using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace technical_service_tracking_system.Models
{
    public class ServiceRequestViewModel
    {
        [Required]
        [DisplayName("Fault Details")]
        public string FaultDetails { get; set;} = string.Empty;
        public List<CustomerProductViewModel> CustomerProductViewModels { get; set; } = new(); //change this into id name list
    }
}