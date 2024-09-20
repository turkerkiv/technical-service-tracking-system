using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using technical_service_tracking_system.Entity;

namespace technical_service_tracking_system.Repository.Abstract
{
    public interface IRequestInterventionRepository
    {
        Task<RequestIntervention?> GetRequestInterventionByIdAsync(int id);
        Task AddRequestInterventionAsync(RequestIntervention requestIntervention);
        Task UpdateRequestInterventionAsync(RequestIntervention requestIntervention);
        Task DeleteRequestInterventionAsync(RequestIntervention requestIntervention);
    }
}