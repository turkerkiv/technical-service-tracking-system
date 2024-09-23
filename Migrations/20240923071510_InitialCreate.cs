using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace technical_service_tracking_system.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FaultTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaultTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpareItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpareItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HasWarranty = table.Column<bool>(type: "bit", nullable: false),
                    WarrantyStartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    WarrantyEndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerProducts_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaultDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketNumber = table.Column<int>(type: "int", nullable: false),
                    RequestDate = table.Column<DateOnly>(type: "date", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CustomerProductId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    FaultTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceRequests_CustomerProducts_CustomerProductId",
                        column: x => x.CustomerProductId,
                        principalTable: "CustomerProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceRequests_FaultTypes_FaultTypeId",
                        column: x => x.FaultTypeId,
                        principalTable: "FaultTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceRequests_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceRequests_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RequestInterventions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    InterventionDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechnicianId = table.Column<int>(type: "int", nullable: false),
                    ServiceRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestInterventions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestInterventions_ServiceRequests_ServiceRequestId",
                        column: x => x.ServiceRequestId,
                        principalTable: "ServiceRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestInterventions_Users_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpareItemUseActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpareItemId = table.Column<int>(type: "int", nullable: false),
                    RequestInterventionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpareItemUseActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpareItemUseActivities_RequestInterventions_RequestInterventionId",
                        column: x => x.RequestInterventionId,
                        principalTable: "RequestInterventions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpareItemUseActivities_SpareItems_SpareItemId",
                        column: x => x.SpareItemId,
                        principalTable: "SpareItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FaultTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Hardware" },
                    { 2, "Software" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Model", "SerialNumber" },
                values: new object[,]
                {
                    { 1, "Dell", "XPS 13", "ABC123" },
                    { 2, "Apple", "MacBook Pro", "DEF456" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Technician" },
                    { 3, "Customer" }
                });

            migrationBuilder.InsertData(
                table: "SpareItems",
                columns: new[] { "Id", "Name", "Stock" },
                values: new object[,]
                {
                    { 1, "LCD Screen", 5 },
                    { 2, "SSD Drive", 10 }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "Closed" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[,]
                {
                    { 1, "123 Main St", "john@example.com", "John Doe", "hashedpassword1", "1234567890", 1 },
                    { 2, "456 Elm St", "jane@example.com", "Jane Smith", "hashedpassword2", "0987654321", 3 },
                    { 3, "789 Pine St", "mike@example.com", "Technician Mike", "hashedpassword3", "1112223333", 2 }
                });

            migrationBuilder.InsertData(
                table: "CustomerProducts",
                columns: new[] { "Id", "CustomerId", "HasWarranty", "ProductId", "WarrantyEndDate", "WarrantyStartDate" },
                values: new object[,]
                {
                    { 1, 2, true, 1, new DateOnly(2025, 1, 1), new DateOnly(2023, 1, 1) },
                    { 2, 2, false, 2, new DateOnly(2024, 1, 1), new DateOnly(2022, 1, 1) }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequests",
                columns: new[] { "Id", "CustomerId", "CustomerProductId", "FaultDetails", "FaultTypeId", "RequestDate", "StatusId", "TicketNumber" },
                values: new object[,]
                {
                    { 1, 2, 1, "Screen not turning on", 1, new DateOnly(2024, 9, 1), 1, 1001 },
                    { 2, 2, 2, "Operating system crash", 2, new DateOnly(2024, 9, 10), 1, 1002 }
                });

            migrationBuilder.InsertData(
                table: "RequestInterventions",
                columns: new[] { "Id", "EndDate", "InterventionDetails", "ServiceRequestId", "StartDate", "TechnicianId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2024, 9, 3), "Replaced screen", 1, new DateOnly(2024, 9, 2), 3 },
                    { 2, new DateOnly(2024, 9, 12), "Reinstalled operating system", 2, new DateOnly(2024, 9, 11), 3 }
                });

            migrationBuilder.InsertData(
                table: "SpareItemUseActivities",
                columns: new[] { "Id", "RequestInterventionId", "SpareItemId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProducts_CustomerId",
                table: "CustomerProducts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProducts_ProductId",
                table: "CustomerProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SerialNumber",
                table: "Products",
                column: "SerialNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestInterventions_ServiceRequestId",
                table: "RequestInterventions",
                column: "ServiceRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestInterventions_TechnicianId",
                table: "RequestInterventions",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_CustomerId",
                table: "ServiceRequests",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_CustomerProductId",
                table: "ServiceRequests",
                column: "CustomerProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_FaultTypeId",
                table: "ServiceRequests",
                column: "FaultTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_StatusId",
                table: "ServiceRequests",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_TicketNumber",
                table: "ServiceRequests",
                column: "TicketNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpareItemUseActivities_RequestInterventionId",
                table: "SpareItemUseActivities",
                column: "RequestInterventionId");

            migrationBuilder.CreateIndex(
                name: "IX_SpareItemUseActivities_SpareItemId",
                table: "SpareItemUseActivities",
                column: "SpareItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpareItemUseActivities");

            migrationBuilder.DropTable(
                name: "RequestInterventions");

            migrationBuilder.DropTable(
                name: "SpareItems");

            migrationBuilder.DropTable(
                name: "ServiceRequests");

            migrationBuilder.DropTable(
                name: "CustomerProducts");

            migrationBuilder.DropTable(
                name: "FaultTypes");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
