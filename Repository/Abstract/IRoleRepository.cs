using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using technical_service_tracking_system.Entity;

namespace technical_service_tracking_system.Repository.Abstract
{
    public interface IRoleRepository
    {
        Task<Role?> GetRoleByIdAsync(int id);
        Task AddRoleAsync(Role role);
        Task UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(Role role);
    }
}