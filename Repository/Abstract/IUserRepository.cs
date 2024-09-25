using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using technical_service_tracking_system.Entity;

namespace technical_service_tracking_system.Repository.Abstract
{
    public interface IUserRepository
    {
        public IQueryable<User> Users { get; }
        Task<User?> GetUserByIdAsync(int id);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);
    }
}