using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace technical_service_tracking_system.Entity
{
    public class TsDbContext(DbContextOptions<TsDbContext> options) : DbContext(options)
    {
        public DbSet<CustomerProduct> CustomerProducts => Set<CustomerProduct>();
        public DbSet<FaultType> FaultTypes => Set<FaultType>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<RequestIntervention> RequestInterventions => Set<RequestIntervention>();
        public DbSet<Role> Role => Set<Role>();
        public DbSet<ServiceRequest> ServiceRequests => Set<ServiceRequest>();
        public DbSet<SpareItem> SpareItems => Set<SpareItem>();
        public DbSet<SpareItemUseActivity> SpareItemUseActivities => Set<SpareItemUseActivity>();
        public DbSet<Status> Statuses => Set<Status>();
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CustomerProduct>()
            .HasIndex(cp => cp.SerialNumber)
            .IsUnique();

            modelBuilder.Entity<ServiceRequest>()
            .HasIndex(cp => cp.TicketNumber)
            .IsUnique();

            /*on some row deletion, to delete all related rows we need to 
            include that related entities but for every entity while getting
            it from db and then delete to make related one tracked too.*/ 
            modelBuilder.Entity<ServiceRequest>()
            .HasOne(sr => sr.Customer)
            .WithMany(c => c.ServiceRequests)
            .HasForeignKey(sr => sr.CustomerId)
            .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<ServiceRequest>()
          .HasOne(sr => sr.CustomerProduct)
          .WithMany(cp => cp.ServiceRequests)
          .HasForeignKey(sr => sr.CustomerProductId)
          .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<ServiceRequest>()
          .HasOne(sr => sr.Status)
          .WithMany(c => c.ServiceRequests)
          .HasForeignKey(sr => sr.StatusId)
          .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<ServiceRequest>()
          .HasOne(sr => sr.FaultType)
          .WithMany(c => c.ServiceRequests)
          .HasForeignKey(sr => sr.FaultTypeId)
          .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}