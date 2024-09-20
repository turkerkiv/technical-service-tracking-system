using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using technical_service_tracking_system.Entity;
using technical_service_tracking_system.Repository.Abstract;

namespace technical_service_tracking_system.Repository.Concrete
{
    public class EFStatusRepository(TsDbContext context) : IStatusRepository
    {
        readonly TsDbContext _context = context;
        public IQueryable<Status> Statuss => _context.Statuses;

        public async Task AddStatusAsync(Status status)
        {
            _context.Statuses.Add(status);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStatusAsync(Status status)
        {
            _context.Statuses.Remove(status);
            await _context.SaveChangesAsync();
        }

        public async Task<Status?> GetStatusByIdAsync(int id)
        {
            return await _context.Statuses.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateStatusAsync(Status status)
        {
            _context.Statuses.Update(status);
            await _context.SaveChangesAsync();
        }
    }
}