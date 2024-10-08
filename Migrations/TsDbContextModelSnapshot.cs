﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using technical_service_tracking_system.Entity;

#nullable disable

namespace technical_service_tracking_system.Migrations
{
    [DbContext(typeof(TsDbContext))]
    partial class TsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("technical_service_tracking_system.Entity.CustomerProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("WarrantyEndDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("WarrantyStartDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("CustomerProducts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 2,
                            ProductId = 1,
                            WarrantyEndDate = new DateOnly(2025, 1, 1),
                            WarrantyStartDate = new DateOnly(2023, 1, 1)
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            ProductId = 2,
                            WarrantyEndDate = new DateOnly(2024, 1, 1),
                            WarrantyStartDate = new DateOnly(2022, 1, 1)
                        });
                });

            modelBuilder.Entity("technical_service_tracking_system.Entity.FaultType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FaultTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Hardware"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Software"
                        });
                });

            modelBuilder.Entity("technical_service_tracking_system.Entity.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("SerialNumber")
                        .IsUnique();

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Dell",
                            ImageName = "",
                            Model = "XPS 13",
                            SerialNumber = "ABC123"
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Apple",
                            ImageName = "",
                            Model = "MacBook Pro",
                            SerialNumber = "DEF456"
                        });
                });

            modelBuilder.Entity("technical_service_tracking_system.Entity.RequestIntervention", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("InterventionDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServiceRequestId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.Property<int>("TechnicianId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceRequestId");

                    b.HasIndex("TechnicianId");

                    b.ToTable("RequestInterventions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndDate = new DateOnly(2024, 9, 3),
                            InterventionDetails = "Replaced screen",
                            ServiceRequestId = 1,
                            StartDate = new DateOnly(2024, 9, 2),
                            TechnicianId = 3
                        },
                        new
                        {
                            Id = 2,
                            EndDate = new DateOnly(2024, 9, 12),
                            InterventionDetails = "Reinstalled operating system",
                            ServiceRequestId = 2,
                            StartDate = new DateOnly(2024, 9, 11),
                            TechnicianId = 3
                        });
                });

            modelBuilder.Entity("technical_service_tracking_system.Entity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Technician"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Customer"
                        });
                });

            modelBuilder.Entity("technical_service_tracking_system.Entity.ServiceRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerProductId")
                        .HasColumnType("int");

                    b.Property<string>("FaultDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FaultTypeId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("RequestDate")
                        .HasColumnType("date");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("TicketNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("CustomerProductId");

                    b.HasIndex("FaultTypeId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TicketNumber")
                        .IsUnique();

                    b.ToTable("ServiceRequests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 2,
                            CustomerProductId = 1,
                            FaultDetails = "Screen not turning on",
                            FaultTypeId = 1,
                            RequestDate = new DateOnly(2024, 9, 1),
                            StatusId = 1,
                            TicketNumber = 1001
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            CustomerProductId = 2,
                            FaultDetails = "Operating system crash",
                            FaultTypeId = 2,
                            RequestDate = new DateOnly(2024, 9, 10),
                            StatusId = 1,
                            TicketNumber = 1002
                        });
                });

            modelBuilder.Entity("technical_service_tracking_system.Entity.SpareItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SpareItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "LCD Screen",
                            Stock = 5
                        },
                        new
                        {
                            Id = 2,
                            Name = "SSD Drive",
                            Stock = 10
                        });
                });

            modelBuilder.Entity("technical_service_tracking_system.Entity.SpareItemUseActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RequestInterventionId")
                        .HasColumnType("int");

                    b.Property<int>("SpareItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RequestInterventionId");

                    b.HasIndex("SpareItemId");

                    b.ToTable("SpareItemUseActivities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RequestInterventionId = 1,
                            SpareItemId = 1
                        },
                        new
                        {
                            Id = 2,
                            RequestInterventionId = 2,
                            SpareItemId = 2
                        });
                });

            modelBuilder.Entity("technical_service_tracking_system.Entity.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ready"
                        },
                        new
                        {
                            Id = 2,
                            Name = "In Progress"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Done"
                        });
                });

            modelBuilder.Entity("technical_service_tracking_system.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Main St",
                            Email = "john@example.com",
                            Name = "John Doe",
                            Password = "$2a$11$iaEhkYYAe31wcEQ7az8g4ezvEzZf9FeydTUei9bNQny9onWZOE6MG",
                            PhoneNumber = "1234567890",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            Address = "456 Elm St",
                            Email = "jane@example.com",
                            Name = "Jane Smith",
                            Password = "$2a$11$ZK6AdNK/ENSLo6y6eLSjEumoDux9BiA6jQOACFJ0fSiRcn5X0puEG",
                            PhoneNumber = "0987654321",
                            RoleId = 3
                        },
                        new
                        {
                            Id = 3,
                            Address = "789 Pine St",
                            Email = "mike@example.com",
                            Name = "Technician Mike",
                            Password = "$2a$11$RN1H0xchqDF.qKZLg.lV5.gerAiYqAy.eImY.ZcIT7hJNpuZVBz.C",
                            PhoneNumber = "1112223333",
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("technical_service_tracking_system.Entity.CustomerProduct", b =>
                {
                    b.HasOne("technical_service_tracking_system.Entity.User", "Customer")
                        .WithMany("CustomerProducts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("technical_service_tracking_system.Entity.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("technical_service_tracking_system.Entity.RequestIntervention", b =>
                {
                    b.HasOne("technical_service_tracking_system.Entity.ServiceRequest", "ServiceRequest")
                        .WithMany("RequestInterventions")
                        .HasForeignKey("ServiceRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("technical_service_tracking_system.Entity.User", "Technician")
                        .WithMany("RequestInterventions")
                        .HasForeignKey("TechnicianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServiceRequest");

                    b.Navigation("Technician");
                });

            modelBuilder.Entity("technical_service_tracking_system.Entity.ServiceRequest", b =>
                {
                    b.HasOne("technical_service_tracking_system.Entity.User", "Customer")
                        .WithMany("ServiceRequests")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("technical_service_tracking_system.Entity.CustomerProduct", "CustomerProduct")
                        .WithMany("ServiceRequests")
                        .HasForeignKey("CustomerProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("technical_service_tracking_system.Entity.FaultType", "FaultType")
                        .WithMany("ServiceRequests")
                        .HasForeignKey("FaultTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("technical_service_tracking_system.Entity.Status", "Status")
                        .WithMany("ServiceRequests")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("CustomerProduct");

                    b.Navigation("FaultType");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("technical_service_tracking_system.Entity.SpareItemUseActivity", b =>
                {
                    b.HasOne("technical_service_tracking_system.Entity.RequestIntervention", "RequestIntervention")
                        .WithMany("SpareItemUseActivities")
                        .HasForeignKey("RequestInterventionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("technical_service_tracking_system.Entity.SpareItem", "SpareItem")
                        .WithMany("SpareItemUseActivities")
                        .HasForeignKey("SpareItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RequestIntervention");

                    b.Navigation("SpareItem");
                });

            modelBuilder.Entity("technical_service_tracking_system.Entity.User", b =>
                {
                    b.HasOne("technical_service_tracking_system.Entity.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("technical_service_tracking_system.Entity.CustomerProduct", b =>
                {
                    b.Navigation("ServiceRequests");
                });

            modelBuilder.Entity("technical_service_tracking_system.Entity.FaultType", b =>
                {
                    b.Navigation("ServiceRequests");
                });

            modelBuilder.Entity("technical_service_tracking_system.Entity.RequestIntervention", b =>
                {
                    b.Navigation("SpareItemUseActivities");
                });

            modelBuilder.Entity("technical_service_tracking_system.Entity.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("technical_service_tracking_system.Entity.ServiceRequest", b =>
                {
                    b.Navigation("RequestInterventions");
                });

            modelBuilder.Entity("technical_service_tracking_system.Entity.SpareItem", b =>
                {
                    b.Navigation("SpareItemUseActivities");
                });

            modelBuilder.Entity("technical_service_tracking_system.Entity.Status", b =>
                {
                    b.Navigation("ServiceRequests");
                });

            modelBuilder.Entity("technical_service_tracking_system.Entity.User", b =>
                {
                    b.Navigation("CustomerProducts");

                    b.Navigation("RequestInterventions");

                    b.Navigation("ServiceRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
