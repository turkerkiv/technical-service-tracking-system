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
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<ServiceRequest> ServiceRequests => Set<ServiceRequest>();
    public DbSet<SpareItem> SpareItems => Set<SpareItem>();
    public DbSet<SpareItemUseActivity> SpareItemUseActivities => Set<SpareItemUseActivity>();
    public DbSet<Status> Statuses => Set<Status>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Product>()
      .HasIndex(cp => cp.SerialNumber)
      .IsUnique();

      modelBuilder.Entity<ServiceRequest>()
      .HasIndex(cp => cp.TicketNumber)
      .IsUnique();

      /*if we use clientCascade: on some row deletion, to delete all related rows we need to 
      include that related entities but for every entity while getting
      it from db and then delete to make related one tracked too.*/
      //restrict chosen bc it reminds to delete every related childs
      modelBuilder.Entity<ServiceRequest>()
      .HasOne(sr => sr.Customer)
      .WithMany(c => c.ServiceRequests)
      .HasForeignKey(sr => sr.CustomerId)
      .OnDelete(DeleteBehavior.Restrict);

      modelBuilder.Entity<ServiceRequest>()
    .HasOne(sr => sr.CustomerProduct)
    .WithMany(cp => cp.ServiceRequests)
    .HasForeignKey(sr => sr.CustomerProductId)
    .OnDelete(DeleteBehavior.Restrict);

      modelBuilder.Entity<ServiceRequest>()
    .HasOne(sr => sr.Status)
    .WithMany(c => c.ServiceRequests)
    .HasForeignKey(sr => sr.StatusId)
    .OnDelete(DeleteBehavior.Restrict);

      modelBuilder.Entity<ServiceRequest>()
    .HasOne(sr => sr.FaultType)
    .WithMany(c => c.ServiceRequests)
    .HasForeignKey(sr => sr.FaultTypeId)
    .OnDelete(DeleteBehavior.Restrict);


      // seed data
      // Seeding Roles
      modelBuilder.Entity<Role>().HasData(
          new Role { Id = 1, Name = "Admin" },
          new Role { Id = 2, Name = "Technician" },
          new Role { Id = 3, Name = "Customer" }
      );

      // Seeding Users
      modelBuilder.Entity<User>().HasData(
          new User { Id = 1, Name = "John Doe", Address = "123 Main St", PhoneNumber = "1234567890", Email = "john@example.com", Password = "hashedpassword1", RoleId = 1 },
          new User { Id = 2, Name = "Jane Smith", Address = "456 Elm St", PhoneNumber = "0987654321", Email = "jane@example.com", Password = "hashedpassword2", RoleId = 3 },
          new User { Id = 3, Name = "Technician Mike", Address = "789 Pine St", PhoneNumber = "1112223333", Email = "mike@example.com", Password = "hashedpassword3", RoleId = 2 }
      );

      // Seeding Fault Types
      modelBuilder.Entity<FaultType>().HasData(
          new FaultType { Id = 1, Name = "Hardware" },
          new FaultType { Id = 2, Name = "Software" }
      );

      // Seeding Statuses
      modelBuilder.Entity<Status>().HasData(
          new Status { Id = 1, Name = "Open" },
          new Status { Id = 2, Name = "In Progress" },
          new Status { Id = 3, Name = "Closed" }
      );

      // Seeding Products
      modelBuilder.Entity<Product>().HasData(
          new Product { Id = 1, Brand = "Dell", Model = "XPS 13", SerialNumber = "ABC123" },
          new Product { Id = 2, Brand = "Apple", Model = "MacBook Pro", SerialNumber = "DEF456" }
      );

      // Seeding Customer Products
      modelBuilder.Entity<CustomerProduct>().HasData(
          new CustomerProduct { Id = 1, WarrantyStartDate = new DateOnly(2023, 01, 01), WarrantyEndDate = new DateOnly(2025, 01, 01), CustomerId = 2, ProductId = 1 },
          new CustomerProduct { Id = 2,WarrantyStartDate = new DateOnly(2022, 01, 01), WarrantyEndDate = new DateOnly(2024, 01, 01), CustomerId = 2, ProductId = 2 }
      );

      // Seeding Service Requests
      modelBuilder.Entity<ServiceRequest>().HasData(
          new ServiceRequest
          {
            Id = 1,
            CustomerProductId = 1,
            CustomerId = 2,
            FaultTypeId = 1,
            FaultDetails = "Screen not turning on",
            TicketNumber = 1001,
            StatusId = 1,
            RequestDate = new DateOnly(2024, 09, 01)
          },
          new ServiceRequest
          {
            Id = 2,
            CustomerProductId = 2,
            CustomerId = 2,
            FaultTypeId = 2,
            FaultDetails = "Operating system crash",
            TicketNumber = 1002,
            StatusId = 1,
            RequestDate = new DateOnly(2024, 09, 10)
          }
      );

      // Seeding Request Interventions
      modelBuilder.Entity<RequestIntervention>().HasData(
          new RequestIntervention
          {
            Id = 1,
            ServiceRequestId = 1,
            StartDate = new DateOnly(2024, 09, 02),
            EndDate = new DateOnly(2024, 09, 03),
            InterventionDetails = "Replaced screen",
            TechnicianId = 3
          },
          new RequestIntervention
          {
            Id = 2,
            ServiceRequestId = 2,
            StartDate = new DateOnly(2024, 09, 11),
            EndDate = new DateOnly(2024, 09, 12),
            InterventionDetails = "Reinstalled operating system",
            TechnicianId = 3
          }
      );

      // Seeding Spare Items
      modelBuilder.Entity<SpareItem>().HasData(
          new SpareItem { Id = 1, Name = "LCD Screen", Stock = 5 },
          new SpareItem { Id = 2, Name = "SSD Drive", Stock = 10 }
      );

      // Seeding Spare Item Use Activities
      modelBuilder.Entity<SpareItemUseActivity>().HasData(
          new SpareItemUseActivity { Id = 1, SpareItemId = 1, RequestInterventionId = 1 },
          new SpareItemUseActivity { Id = 2, SpareItemId = 2, RequestInterventionId = 2 }
      );
    }
  }
}