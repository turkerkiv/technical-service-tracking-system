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

                    b.Property<bool>("HasWarranty")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateOnly>("WarrantyEndDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("WarrantyStartDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SerialNumber")
                        .IsUnique();

                    b.ToTable("CustomerProducts");
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

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
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

                    b.ToTable("Role");
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

                    b.Property<int>("FaultTypeId")
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
                });

            modelBuilder.Entity("technical_service_tracking_system.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
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
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

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
