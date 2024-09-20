using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using technical_service_tracking_system.Entity;
using technical_service_tracking_system.Repository.Abstract;

namespace technical_service_tracking_system.Repository.Concrete
{
    public class EFSpareItemUseActivityRepository(TsDbContext context) : ISpareItemUseActivityRepository
    {
        readonly TsDbContext _context = context;
        public IQueryable<SpareItemUseActivity> SpareItemUseActivitys => _context.SpareItemUseActivities;

        public async Task AddSpareItemUseActivityAsync(SpareItemUseActivity spareItemUseActivity)
        {
            _context.SpareItemUseActivities.Add(spareItemUseActivity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSpareItemUseActivityAsync(SpareItemUseActivity spareItemUseActivity)
        {
            _context.SpareItemUseActivities.Remove(spareItemUseActivity);
            await _context.SaveChangesAsync();
        }

        public async Task<SpareItemUseActivity?> GetSpareItemUseActivityByIdAsync(int id)
        {
            return await _context.SpareItemUseActivities.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateSpareItemUseActivityAsync(SpareItemUseActivity spareItemUseActivity)
        {
            _context.SpareItemUseActivities.Update(spareItemUseActivity);
            await _context.SaveChangesAsync();
        }
    }
}