using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using technical_service_tracking_system.Entity;
using technical_service_tracking_system.Repository.Abstract;

namespace technical_service_tracking_system.Repository.Concrete
{
    public class EFRequestInterventionRepository(TsDbContext context) : IRequestInterventionRepository
    {
        readonly TsDbContext _context = context;
        public IQueryable<RequestIntervention> RequestInterventions => _context.RequestInterventions;

        public async Task AddRequestInterventionAsync(RequestIntervention requestIntervention)
        {
            _context.RequestInterventions.Add(requestIntervention);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRequestInterventionAsync(RequestIntervention requestIntervention)
        {
            _context.RequestInterventions.Remove(requestIntervention);
            await _context.SaveChangesAsync();
        }

        public async Task<RequestIntervention?> GetRequestInterventionByIdAsync(int id)
        {
            return await _context.RequestInterventions.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateRequestInterventionAsync(RequestIntervention requestIntervention)
        {
            _context.RequestInterventions.Update(requestIntervention);
            await _context.SaveChangesAsync();
        }
    }
}