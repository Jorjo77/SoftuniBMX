﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BicycleApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BikesStandartModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of standart bike."),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the creation of the entity"),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of the last update of the entity"),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of deletion of the entity"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Status of the department: Active/Inactive")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BikesStandartModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompatableParts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false, comment: "The name of the compatible part"),
                    Type = table.Column<int>(type: "int", nullable: false, comment: "Type of the part")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompatableParts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The name of the department"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the creation of the entity"),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of the last update of the entity"),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of deletion of the entity"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Status of the department: Active/Inactive")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                },
                comment: "Table of all departments in the database");

            migrationBuilder.CreateTable(
                name: "PartCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Name of the category"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Url of the general image for this category"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the creation of the category"),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of last update of the category"),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of the deletion of the category"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Status of the category: Active/Inactive")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartCategories", x => x.Id);
                },
                comment: "Table of all categories for a part in the database");

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "The name of the status"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the creation of the status"),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of last update of the status"),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of the deletion of the status"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "State of the status: Active/Inactive")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                },
                comment: "Table with all the statuses for the orders");

            migrationBuilder.CreateTable(
                name: "Supliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The name of the firm"),
                    VATNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Unique VAT number of the suplier"),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Main address of the suplier"),
                    PhoneNumeber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Main phone number of the supplier"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Main email of the suplier"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The category name of the suplied part"),
                    ContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The name of the main person for contact with the suplier"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the creation of the entry"),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of last update of the entry"),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of the deletion of the entry"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Status of the entry: Active/Inactive")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supliers", x => x.Id);
                },
                comment: "Table of all supliers in the database");

            migrationBuilder.CreateTable(
                name: "Towns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the town"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the creation of the town entry"),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of last update of the town entry"),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of the deletion of the town entry"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.Id);
                },
                comment: "Table of all towns registered in the database");

            migrationBuilder.CreateTable(
                name: "VATCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VATPercent = table.Column<decimal>(type: "decimal(6,2)", nullable: false, comment: "Current percent of the VAT for this category parts"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the creation of the category"),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of the last update of the category"),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of the deletion of the category"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Status of the category: Active/Inactive")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VATCategories", x => x.Id);
                },
                comment: "Table of all vat categories in the database");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "The first name of the employee"),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "The last name of the employee"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Phone number of the employee"),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Email of the employee"),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Current position of the employee in the company"),
                    DateOfHire = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of hire of the employee"),
                    DateOfLeave = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of termination of the employee"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Status of the account: Active/Inactive"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the creation of the account"),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of last update of account data"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false, comment: "Id of the current department of the employee"),
                    IsManeger = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                },
                comment: "Table of all employees registered in the database");

            migrationBuilder.CreateTable(
                name: "PartsInStock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OemPartNumber = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Unic number of the part"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the creation of the entry"),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of last update of the entry"),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of the deletion of the entry"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Status of the entry: Active/Inactive"),
                    SuplierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsInStock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartsInStock_Supliers_SuplierId",
                        column: x => x.SuplierId,
                        principalTable: "Supliers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "The first name of the client"),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "The last name of the client"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DelivaryAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "The default address of the client for deliveries"),
                    TownId = table.Column<int>(type: "int", nullable: false, comment: "The Id of the default town for this client"),
                    IBAN = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true, comment: "IBAN of the client"),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The amount of the deposited money in this client account"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Status of the account: Active/Inactive"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the creation of the account"),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of last update of account data"),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of the deletion of the account"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Towns_TownId",
                        column: x => x.TownId,
                        principalTable: "Towns",
                        principalColumn: "Id");
                },
                comment: "Table of all clients registered in the database");

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The name of the part"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Full description of the part"),
                    Intend = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Intention of the part"),
                    OEMNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Unique number of the part from the manifacturer"),
                    Type = table.Column<int>(type: "int", nullable: false, comment: "Type of the part"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Id of the category of the part"),
                    Quantity = table.Column<double>(type: "float(2)", nullable: false, comment: "Current quantity of the part in the database"),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Sale price of the part before VAT"),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Discount for part"),
                    VATCategoryId = table.Column<int>(type: "int", nullable: false, comment: "Id of the current vat category of the part"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the creation of the entry in tha database"),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of the last update of the entry in the database"),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of the deletion of the entry from the database"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Status of the part: Deleted/Not deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parts_PartCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "PartCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Parts_VATCategories_VATCategoryId",
                        column: x => x.VATCategoryId,
                        principalTable: "VATCategories",
                        principalColumn: "Id");
                },
                comment: "Table of all the parts in the database");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImagesEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Name of the image"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Url of the image"),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Id of the client"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagesEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagesEmployees_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                },
                comment: "Table with the location of all images of all employees in tha database");

            migrationBuilder.CreateTable(
                name: "ImagesClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Name of the image"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Url of the image"),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Id of the client")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagesClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagesClients_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                },
                comment: "Table with the location of all images of all clients in tha database");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Id of the client of this order"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "All information of the ordered parts from the client, as a string"),
                    SaleAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The amount of the order before discount and tax"),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The amount of the discoint"),
                    VAT = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The amount of the VAT"),
                    FinalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The final amount of the order after discount and tax"),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The amount paid from this order"),
                    UnpaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The amount not paid from this order"),
                    StatusId = table.Column<int>(type: "int", nullable: false, comment: "Id of the current status of the order"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the creation of the order"),
                    DateFinish = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of the completion of the order"),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of last update of the order"),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of the deletion of the order"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Is the order deleted: Yes/No")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                },
                comment: "Table of all orders from clients in the database");

            migrationBuilder.CreateTable(
                name: "BikeModelsParts",
                columns: table => new
                {
                    BikeModelId = table.Column<int>(type: "int", nullable: false),
                    PartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BikeModelsParts", x => new { x.PartId, x.BikeModelId });
                    table.ForeignKey(
                        name: "FK_BikeModelsParts_BikesStandartModels_BikeModelId",
                        column: x => x.BikeModelId,
                        principalTable: "BikesStandartModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BikeModelsParts_Parts_BikeModelId",
                        column: x => x.BikeModelId,
                        principalTable: "Parts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartId = table.Column<int>(type: "int", nullable: false, comment: "Id of the part"),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Title of the comment"),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false, comment: "Description of the comment"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the creation of the entity"),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of the last update of the entity"),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of deletion of the entity"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Status of the department: Active/Inactive")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id");
                },
                comment: "Table of all comments for all parts in the database");

            migrationBuilder.CreateTable(
                name: "CompatiblePartPart",
                columns: table => new
                {
                    CompatablePartsId = table.Column<int>(type: "int", nullable: false),
                    PartsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompatiblePartPart", x => new { x.CompatablePartsId, x.PartsId });
                    table.ForeignKey(
                        name: "FK_CompatiblePartPart_CompatableParts_CompatablePartsId",
                        column: x => x.CompatablePartsId,
                        principalTable: "CompatableParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompatiblePartPart_Parts_PartsId",
                        column: x => x.PartsId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Delivaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartId = table.Column<int>(type: "int", nullable: false, comment: "Id of the part"),
                    QuantityDelivered = table.Column<double>(type: "float(2)", nullable: false, comment: "Quantity delivered of the current part"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Additional info for the current delivary"),
                    DateDelivered = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the creation of the entry"),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of last update of the entry"),
                    SuplierId = table.Column<int>(type: "int", nullable: false, comment: "Id of the suplier for this delivary"),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of deletion of the entity"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Status of the department: Active/Inactive")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Delivaries_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Delivaries_Supliers_SuplierId",
                        column: x => x.SuplierId,
                        principalTable: "Supliers",
                        principalColumn: "Id");
                },
                comment: "Table of all delivaries of all parts in the database");

            migrationBuilder.CreateTable(
                name: "ImagesParts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Name of the image"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Url of the image"),
                    PartId = table.Column<int>(type: "int", nullable: false, comment: "Id of the part"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the creation of the entity"),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of the last update of the entity"),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of deletion of the entity"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Status of the department: Active/Inactive")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagesParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagesParts_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id");
                },
                comment: "Table with the location of all images of all parts in tha database");

            migrationBuilder.CreateTable(
                name: "PartOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartId = table.Column<int>(type: "int", nullable: false, comment: "Id of the part"),
                    QuantityDelivered = table.Column<int>(type: "int", nullable: false, comment: "Quantity delivered of the current part"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Additional info for the current order"),
                    SuplierId = table.Column<int>(type: "int", nullable: false, comment: "Id of the suplier for this delivary"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the creation of the entry"),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of last update of the entry"),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of the deletion of the entry"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Status of the entry: Active/Inactive"),
                    PartId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartOrders_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PartOrders_Parts_PartId1",
                        column: x => x.PartId1,
                        principalTable: "Parts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PartOrders_Supliers_SuplierId",
                        column: x => x.SuplierId,
                        principalTable: "Supliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Table of all orders of parts in the database");

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Id of the client who has rated the current part"),
                    PartId = table.Column<int>(type: "int", nullable: false, comment: "Id of the part who has the client rated"),
                    Rating = table.Column<int>(type: "int", nullable: false, comment: "The last rating for the part given by the client"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the creation of the order"),
                    DateFinish = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of the completion of the order"),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of last update of the order"),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of the deletion of the order"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Is the order deleted: Yes/No")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => new { x.PartId, x.ClientId });
                    table.ForeignKey(
                        name: "FK_Rates_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rates_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id");
                },
                comment: "Table of all the ratings for all the part in the database");

            migrationBuilder.CreateTable(
                name: "OrdersPartsEmployees",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false, comment: "Id of the order from the client"),
                    UniqueKeyForSerialNumber = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Separate unique products by serial number in one order"),
                    PartId = table.Column<int>(type: "int", nullable: false, comment: "Id of the part"),
                    SerialNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false, comment: "Unique serial number of the order"),
                    PartName = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Name of the part"),
                    PartQuantity = table.Column<double>(type: "float(2)", nullable: false, comment: "Quantity of the part"),
                    PartPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Price of the part"),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true, comment: "Id of the emplyee asigned to this order"),
                    DatetimeAsigned = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date and time of asigned task to the employee"),
                    StartDatetime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date and time of start of the task from the employee"),
                    EndDatetime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date and time of finish of the task from the employee"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Description of the task"),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false, comment: "Status of the task: Completed/Not completed"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the creation of the order"),
                    DateFinish = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of the completion of the order"),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of last update of the order"),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of the deletion of the order"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Is the order deleted: Yes/No")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersPartsEmployees", x => new { x.OrderId, x.PartId, x.UniqueKeyForSerialNumber });
                    table.ForeignKey(
                        name: "FK_OrdersPartsEmployees_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrdersPartsEmployees_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrdersPartsEmployees_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id");
                },
                comment: "Table conecting all the parts in an order with the employee responsible for the mounting");

            migrationBuilder.CreateTable(
                name: "OrdersPartsEmployeesInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id of information for manufacturing part.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescriptionForWorker = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Id of the order from the client"),
                    ProductionТime = table.Column<TimeSpan>(type: "time", nullable: false, comment: "Timespan for production on part."),
                    OrderId = table.Column<int>(type: "int", nullable: false, comment: "Id of the order from the client"),
                    UniqueKeyForSerialNumber = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Separate unique products by serial number in one order"),
                    PartId = table.Column<int>(type: "int", nullable: false, comment: "Id of the part")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersPartsEmployeesInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdersPartsEmployeesInfos_OrdersPartsEmployees_OrderId_PartId_UniqueKeyForSerialNumber",
                        columns: x => new { x.OrderId, x.PartId, x.UniqueKeyForSerialNumber },
                        principalTable: "OrdersPartsEmployees",
                        principalColumns: new[] { "OrderId", "PartId", "UniqueKeyForSerialNumber" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(6609), null, null, false, "Administration" },
                    { 2, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(6615), null, null, false, "Workshop" }
                });

            migrationBuilder.InsertData(
                table: "PartCategories",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "ImageUrl", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7089), null, null, "test", false, "Frame" },
                    { 2, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7101), null, null, "test", false, "Wheel" },
                    { 3, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7103), null, null, "test", false, "Acsessories" }
                });

            migrationBuilder.InsertData(
                table: "PartsInStock",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "IsDeleted", "OemPartNumber", "SuplierId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7419), null, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7420), false, "oemtest1", null },
                    { 2, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7423), null, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7424), false, "oemtest2", null },
                    { 3, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7426), null, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7427), false, "oemtest3", null },
                    { 4, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7428), null, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7429), false, "oemtest4", null },
                    { 5, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7431), null, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7432), false, "oemtest5", null },
                    { 6, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7434), null, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7434), false, "oemtest6", null },
                    { 7, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7436), null, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7437), false, "oemtest7", null },
                    { 8, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7439), null, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7440), false, "oemtest8", null },
                    { 9, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7441), null, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7442), false, "oemtest9", null },
                    { 10, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7444), null, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7445), false, "oemtest10", null },
                    { 11, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7446), null, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7447), false, "oemtest11", null },
                    { 12, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7449), null, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7450), false, "oemtest12", null },
                    { 13, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7451), null, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7452), false, "oemtest13", null }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7244), null, null, false, "Pending approval" },
                    { 2, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7251), null, null, false, "Approved order" },
                    { 3, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7253), null, null, false, "Frame management" },
                    { 4, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7257), null, null, false, "Wheel management" },
                    { 5, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7259), null, null, false, "Shift management" },
                    { 6, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7261), null, null, false, "Quality control" },
                    { 7, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7264), null, null, false, "Send order" }
                });

            migrationBuilder.InsertData(
                table: "Supliers",
                columns: new[] { "Id", "Address", "CategoryName", "ContactName", "DateCreated", "DateDeleted", "DateUpdated", "Email", "IsDeleted", "Name", "PhoneNumeber", "VATNumber" },
                values: new object[,]
                {
                    { 1, "Sofia, center", "Frame", "Pesh Peshev", new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7304), null, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7305), "text@test.bg", false, "X Ltd", "1234567890", "123456789" },
                    { 2, "Sofia, east", "Wheel", "Pesho Peshev", new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7308), null, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7309), "text2@test.bg", false, "XX Ltd", "1234567899", "123456788" },
                    { 3, "Sofia, west", "Acsessories", "Ivan Peshev", new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7312), null, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7313), "text3@test.bg", false, "XXX Ltd", "1234567897", "123456787" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7351), null, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7352), false, "Sofia" },
                    { 2, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7358), null, null, false, "Varna" },
                    { 3, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7360), null, null, false, "Burgas" }
                });

            migrationBuilder.InsertData(
                table: "VATCategories",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "IsDeleted", "VATPercent" },
                values: new object[] { 1, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7391), null, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7392), false, 20.00m });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "DateOfHire", "DateOfLeave", "DateUpdated", "DepartmentId", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "IsManeger", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Position", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "17063948-8fdc-417e-8fb7-2ae6bf572f94", 0, "4aa89585-3f89-4461-8a93-a3872bf425a3", new DateTime(2023, 12, 6, 14, 9, 53, 91, DateTimeKind.Local).AddTicks(7683), new DateTime(2023, 12, 6, 14, 9, 53, 91, DateTimeKind.Local).AddTicks(7679), null, null, 2, "todorov@b-free.com", false, "Todor", false, false, "Todorov", false, null, "TODOROV@B-FREE.COM", null, "AQAAAAIAAYagAAAAEHkMJBno7jcjUfDPQYqPG7SMbXxM+1mdyqTMampODGuo3lpBP/pv5ys1X3IsCJTUKQ==", "1234567890", false, "Wheelworker", "TODOROV@B-FREE.COM", false, "todorov@b-free.com" },
                    { "21003785-a275-4139-ae20-af6a6cf8fea8", 0, "bc4cbef9-a265-49e7-baaa-8dd3c6388ea2", new DateTime(2023, 12, 6, 14, 9, 53, 30, DateTimeKind.Local).AddTicks(3351), new DateTime(2023, 12, 6, 14, 9, 53, 30, DateTimeKind.Local).AddTicks(3343), null, null, 2, "marinov@b-free.com", false, "Marin", false, false, "Marinov", false, null, "MARINOV@B-FREE.COM", null, "AQAAAAIAAYagAAAAEL/AmIfDyAQYd5OB8GKgY8D4lWtekPGtTKB01RE66g57Pkc0reDU3/6VNyHf7oGPVQ==", "1234567890", false, "FrameWorker", "MARINOV@B-FREE.COM", false, "marinov@b-free.com" },
                    { "29f06920-d2ad-43d8-b362-e2b94d7a7502", 0, "c20bb58d-d7ec-4f79-98c8-a507d5d18586", new DateTime(2023, 12, 6, 14, 9, 53, 219, DateTimeKind.Local).AddTicks(3124), new DateTime(2023, 12, 6, 14, 9, 53, 219, DateTimeKind.Local).AddTicks(3083), null, null, 2, "atanasov@b-free.com", false, "Atanas", false, false, "Atanasov", false, null, "ATANASOV@B-FREE.COM", null, "AQAAAAIAAYagAAAAEKDlo0MSF1VTDuDoxm6CHXgvxdmiaBQqOwnJw1L8qhfhApCr/Y+c6yMk/e3to0YkPw==", "1234567890", false, "Qualitycontrol", "ATANASOV@B-FREE.COM", false, "atanasov@b-free.com" },
                    { "406e8cf1-acaa-44a8-afec-585ff64bed34", 0, "6d43d9c5-1aa5-45b8-a3ef-9af62f67280b", new DateTime(2023, 12, 6, 14, 9, 52, 968, DateTimeKind.Local).AddTicks(6470), new DateTime(2023, 12, 6, 14, 9, 52, 968, DateTimeKind.Local).AddTicks(6454), null, null, 1, "manager@b-free.com", false, "Kalin", false, true, "Kalinov", false, null, "MANAGER@B-FREE.COM", null, "AQAAAAIAAYagAAAAEJ0wc6zSBDUi7dSc8/3JtseG1IIgCJ/zxfQGtjLwjCCKlfMw6JYGONV19UDVfhXILg==", "1234567890", false, "manager", "MANAGER@B-FREE.COM", false, "manager@b-free.com" },
                    { "6af8468c-63f1-4bf2-8f88-e24b3f7a8f91", 0, "4bc7f58b-7978-4931-ab97-71102add4b8a", new DateTime(2023, 12, 6, 14, 9, 53, 153, DateTimeKind.Local).AddTicks(8582), new DateTime(2023, 12, 6, 14, 9, 53, 153, DateTimeKind.Local).AddTicks(8526), null, null, 2, "ivanov@b-free.com", false, "Ivan", false, false, "Ivanov", false, null, "IVANOV@B-FREE.COM", null, "AQAAAAIAAYagAAAAEMI6n1aVpNscOcGTVqVhhyOsaoohzM/Ny0ArUGlEutPbZ8qfZ/fMsnxCqKlexm/5UQ==", "1234567890", false, "Accessoriesworker", "IVANOV@B-FREE.COM", false, "ivanov@b-free.com" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AccessFailedCount", "Balance", "ConcurrencyStamp", "DateCreated", "DateDeleted", "DateUpdated", "DelivaryAddress", "Email", "EmailConfirmed", "FirstName", "IBAN", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TownId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "17ce735d-6713-4d0a-8fcb-e4a71ee86f6f", 0, 50.00m, "fa5f415b-5713-43ea-8c10-02eb3644f2fb", new DateTime(2023, 12, 6, 14, 9, 52, 842, DateTimeKind.Local).AddTicks(1867), null, null, "Mladost 1, bl 20", "joro@test.bg", false, "Georgi", "BG0012345678910111212", false, "Georgiev", false, null, "JORO@TEST.BG", null, "AQAAAAIAAYagAAAAEI/t2k9oYFopjVcxWjipZVd/p0Ps6rElyVBgncZV49GrEiTrc+NT5L1x7PzKO5bkvQ==", "1234567890", false, "JORO@TEST.BG", 2, false, "joro@test.bg" },
                    { "99d3ca6f-2067-4316-a5d7-934c93789521", 0, 1246.00m, "b6cafed7-6ab1-4fed-b275-8a27e253ae3d", new DateTime(2023, 12, 6, 14, 9, 52, 906, DateTimeKind.Local).AddTicks(6230), null, null, "Mladost 1, bl 20", "powerranger@test.bg", false, "Dimityr", "BG0012345678910111212", false, "Dimitrov", false, null, "POWERRANGER@TEST.BG", null, "AQAAAAIAAYagAAAAEG42a4F0P+YGP29utq0NVd/KmKDlFL9LXjscFBe3geyFqHUps6GVq7rJoWskU2xPpA==", "1234567890", false, "POWERRANGER@TEST.BG", 3, false, "powerranger@test.bg" },
                    { "ae0da70f-6e0b-4ef8-85a2-0c5cccd4b4fd", 0, 1000.00m, "e6148dc6-e55e-4fda-941e-8886a6ae154d", new DateTime(2023, 12, 6, 14, 9, 52, 773, DateTimeKind.Local).AddTicks(1087), null, null, "Mladost 1, bl 20", "client@test.bg", false, "Ivan", "BG0012345678910111212", false, "Ivanov", false, null, "CLIENT@TEST.BG", null, "AQAAAAIAAYagAAAAEH7xQr68ZVXsMeg9equGbjlVLowS6ny86Eho4nrKokuVffJJFRfyTczqOLKb9H3owg==", "1234567890", false, "CLIENT@TEST.BG", 1, false, "client@test.bg" }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "CategoryId", "DateCreated", "DateDeleted", "DateUpdated", "Description", "Discount", "Intend", "IsDeleted", "Name", "OEMNumber", "Quantity", "SalePrice", "Type", "VATCategoryId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(6956), null, null, "Best frame in the road!", 0.00m, "For road usage", false, "Frame Road", "oemtest1", 2.0, 100.00m, 1, 1 },
                    { 2, 1, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(6966), null, null, "Best frame in the montain", 0.00m, "For montain usage", false, "Frame Montain", "oemtest2", 4.0, 90.00m, 2, 1 },
                    { 3, 1, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(6970), null, null, "Best frame in the road for womens", 0.00m, "For road usage in women bikes", false, "Frame Road woman", "oemtest3", 3.0, 80.00m, 3, 1 },
                    { 4, 2, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(6974), null, null, "Best wheels ever!", 0.00m, "Best wheels for a road usage", false, "Wheel of the Year for road", "oemtest4", 50.0, 75.00m, 1, 1 },
                    { 5, 2, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(6978), null, null, "Best wheels for a montain!", 0.00m, "Best wheels for a montain usage", false, "Wheel of the Year for montain", "oemtest5", 40.0, 85.00m, 2, 1 },
                    { 6, 2, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(6982), null, null, "Best wheels for a road!", 0.00m, "Best seler for a road usage", false, "Road wheel best seler", "oemtest6", 50.0, 65.00m, 3, 1 },
                    { 7, 3, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(6986), null, null, "Worst shift - have only one!", 0.00m, "Base shift - have only one", false, "Shift", "oemtest7", 9.0, 250.00m, 1, 1 },
                    { 8, 3, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(6997), null, null, "Best shifts for a montain!", 0.00m, "Best shift for a montain usage", false, "Montain Shifts", "oemtest8", 19.0, 350.00m, 2, 1 },
                    { 9, 3, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7001), null, null, "Best shifts for a road!", 0.00m, "Best shift for a road usage", false, "Road Shifts", "oemtest9", 29.0, 400.00m, 3, 1 },
                    { 10, 3, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7015), null, null, "Better shifts for a road!", 0.00m, "Better shift for a road usage", false, "Road better Shifts", "oemtest10", 21.0, 410.00m, 3, 1 },
                    { 11, 3, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7019), null, null, "Budget shifts for a road!", 0.00m, "Budget shift for a road usage", false, "Road budget Shifts", "oemtest11", 21.0, 290.00m, 3, 1 },
                    { 12, 3, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7023), null, null, "Cheap standard shift!", 0.00m, "Cheap standard shift for a road usage", false, "Shift", "oemtest12", 9.0, 220.00m, 1, 1 },
                    { 13, 3, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7027), null, null, "Budget shifts for a montain!", 0.00m, "Budget shift for a montain usage", false, "Montain Shifts", "oemtest13", 19.0, 280.00m, 2, 1 },
                    { 14, 2, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7031), null, null, "Budget wheel ever!", 0.00m, "Budget wheel for a road usage", false, "Budget wheel for road", "oemtest14", 50.0, 65.00m, 1, 1 },
                    { 15, 2, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7034), null, null, "Budget wheel for a montain!", 0.00m, "Budget wheel for a montain usage", false, "Budget wheel for a montain", "oemtest15", 40.0, 75.00m, 2, 1 },
                    { 16, 2, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7038), null, null, "The cheapest wheel for a road!", 0.00m, "The cheapest wheel for a road usage", false, "The cheapest road wheel", "oemtest16", 50.0, 55.00m, 3, 1 },
                    { 17, 2, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7041), null, null, "The best titanium wheel for a road!", 0.00m, "The best titanium wheel for a road usage", false, "Road titanium wheel", "oemtest17", 50.0, 95.00m, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ClientId", "DateCreated", "DateDeleted", "DateUpdated", "Description", "IsDeleted", "PartId", "Title" },
                values: new object[] { 1, "ae0da70f-6e0b-4ef8-85a2-0c5cccd4b4fd", new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(6472), null, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(6485), "Test Description", false, 1, "Test Title" });

            migrationBuilder.InsertData(
                table: "Delivaries",
                columns: new[] { "Id", "DateDeleted", "DateDelivered", "DateUpdated", "IsDeleted", "Note", "PartId", "QuantityDelivered", "SuplierId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(6549), new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(6550), false, "text", 1, 2.0, 1 },
                    { 2, null, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(6553), new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(6554), false, "text2", 4, 2.0, 2 },
                    { 3, null, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(6556), new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(6557), false, "text2", 7, 1.0, 3 }
                });

            migrationBuilder.InsertData(
                table: "ImagesClients",
                columns: new[] { "Id", "ClientId", "ImageName", "ImageUrl" },
                values: new object[] { 1, "ae0da70f-6e0b-4ef8-85a2-0c5cccd4b4fd", "image", "test" });

            migrationBuilder.InsertData(
                table: "ImagesEmployees",
                columns: new[] { "Id", "EmployeeId", "ImageName", "ImageUrl", "IsDeleted" },
                values: new object[] { 1, "21003785-a275-4139-ae20-af6a6cf8fea8", "image", "test", false });

            migrationBuilder.InsertData(
                table: "ImagesParts",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "ImageName", "ImageUrl", "IsDeleted", "PartId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "image", "test", false, 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ClientId", "DateCreated", "DateDeleted", "DateFinish", "DateUpdated", "Description", "Discount", "FinalAmount", "IsDeleted", "PaidAmount", "SaleAmount", "StatusId", "UnpaidAmount", "VAT" },
                values: new object[,]
                {
                    { 1, "ae0da70f-6e0b-4ef8-85a2-0c5cccd4b4fd", new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(6781), null, null, null, "", 0m, 750.00m, false, 0m, 625.00m, 1, 750.00m, 125.00m },
                    { 2, "ae0da70f-6e0b-4ef8-85a2-0c5cccd4b4fd", new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(6786), null, null, null, "test2", 0m, 850.00m, false, 0m, 725.00m, 1, 850.00m, 125.00m },
                    { 3, "ae0da70f-6e0b-4ef8-85a2-0c5cccd4b4fd", new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(6789), null, null, null, "test3", 0m, 950.00m, false, 0m, 825.00m, 1, 750.00m, 125.00m }
                });

            migrationBuilder.InsertData(
                table: "PartOrders",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "IsDeleted", "Note", "PartId", "PartId1", "QuantityDelivered", "SuplierId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7498), null, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7499), false, "text", 1, null, 2, 1 },
                    { 2, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7502), null, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7503), false, "text2", 4, null, 2, 2 },
                    { 3, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7505), null, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(7506), false, "text2", 7, null, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "Rates",
                columns: new[] { "ClientId", "PartId", "DateCreated", "DateDeleted", "DateFinish", "DateUpdated", "IsDeleted", "Rating" },
                values: new object[,]
                {
                    { "17ce735d-6713-4d0a-8fcb-e4a71ee86f6f", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 3 },
                    { "99d3ca6f-2067-4316-a5d7-934c93789521", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 4 },
                    { "ae0da70f-6e0b-4ef8-85a2-0c5cccd4b4fd", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 5 },
                    { "99d3ca6f-2067-4316-a5d7-934c93789521", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 4 },
                    { "ae0da70f-6e0b-4ef8-85a2-0c5cccd4b4fd", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 5 },
                    { "99d3ca6f-2067-4316-a5d7-934c93789521", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 4 },
                    { "ae0da70f-6e0b-4ef8-85a2-0c5cccd4b4fd", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 6 },
                    { "99d3ca6f-2067-4316-a5d7-934c93789521", 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 3 },
                    { "ae0da70f-6e0b-4ef8-85a2-0c5cccd4b4fd", 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 4 },
                    { "99d3ca6f-2067-4316-a5d7-934c93789521", 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 6 },
                    { "ae0da70f-6e0b-4ef8-85a2-0c5cccd4b4fd", 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 3 },
                    { "99d3ca6f-2067-4316-a5d7-934c93789521", 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 6 },
                    { "ae0da70f-6e0b-4ef8-85a2-0c5cccd4b4fd", 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 6 },
                    { "99d3ca6f-2067-4316-a5d7-934c93789521", 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 5 },
                    { "ae0da70f-6e0b-4ef8-85a2-0c5cccd4b4fd", 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 6 },
                    { "ae0da70f-6e0b-4ef8-85a2-0c5cccd4b4fd", 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 5 },
                    { "99d3ca6f-2067-4316-a5d7-934c93789521", 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 5 },
                    { "ae0da70f-6e0b-4ef8-85a2-0c5cccd4b4fd", 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 5 },
                    { "99d3ca6f-2067-4316-a5d7-934c93789521", 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 5 },
                    { "ae0da70f-6e0b-4ef8-85a2-0c5cccd4b4fd", 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 5 },
                    { "99d3ca6f-2067-4316-a5d7-934c93789521", 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 3 },
                    { "ae0da70f-6e0b-4ef8-85a2-0c5cccd4b4fd", 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 5 },
                    { "99d3ca6f-2067-4316-a5d7-934c93789521", 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 4 },
                    { "ae0da70f-6e0b-4ef8-85a2-0c5cccd4b4fd", 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 5 },
                    { "99d3ca6f-2067-4316-a5d7-934c93789521", 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 5 },
                    { "ae0da70f-6e0b-4ef8-85a2-0c5cccd4b4fd", 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 4 },
                    { "99d3ca6f-2067-4316-a5d7-934c93789521", 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 5 },
                    { "ae0da70f-6e0b-4ef8-85a2-0c5cccd4b4fd", 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 3 },
                    { "99d3ca6f-2067-4316-a5d7-934c93789521", 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 4 },
                    { "ae0da70f-6e0b-4ef8-85a2-0c5cccd4b4fd", 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 4 },
                    { "99d3ca6f-2067-4316-a5d7-934c93789521", 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 5 },
                    { "ae0da70f-6e0b-4ef8-85a2-0c5cccd4b4fd", 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 3 },
                    { "99d3ca6f-2067-4316-a5d7-934c93789521", 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 2 },
                    { "ae0da70f-6e0b-4ef8-85a2-0c5cccd4b4fd", 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, 3 }
                });

            migrationBuilder.InsertData(
                table: "OrdersPartsEmployees",
                columns: new[] { "OrderId", "PartId", "UniqueKeyForSerialNumber", "DateCreated", "DateDeleted", "DateFinish", "DateUpdated", "DatetimeAsigned", "Description", "EmployeeId", "EndDatetime", "IsCompleted", "IsDeleted", "PartName", "PartPrice", "PartQuantity", "SerialNumber", "StartDatetime" },
                values: new object[,]
                {
                    { 1, 1, "7d47ca5c-ef3a-4bc0-a8af-f024464e27eb", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(6830), "test", "21003785-a275-4139-ae20-af6a6cf8fea8", null, false, false, "Frame OG", 100.00m, 1.0, "BID12345678", null },
                    { 1, 2, "7d47ca5c-ef3a-4bc0-a8af-f024464e27eb", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(6834), "test", "17063948-8fdc-417e-8fb7-2ae6bf572f94", null, false, false, "Wheel of the YearG", 75.00m, 2.0, "BID12345678", null },
                    { 1, 3, "7d47ca5c-ef3a-4bc0-a8af-f024464e27eb", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(6837), "test", "6af8468c-63f1-4bf2-8f88-e24b3f7a8f91", null, false, false, "Shift", 250.00m, 2.0, "BID12345678", null },
                    { 2, 1, "7d47ca5c-ef3a-4bc0-a8af-f024464e27eb", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2023, 12, 6, 14, 9, 53, 282, DateTimeKind.Local).AddTicks(6866), "test", "21003785-a275-4139-ae20-af6a6cf8fea8", null, false, false, "Frame OG", 100.00m, 1.0, "BID12345679", null },
                    { 2, 4, "7d47ca5c-ef3a-4bc0-a8af-f024464e27eb", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "test", "17063948-8fdc-417e-8fb7-2ae6bf572f94", null, false, false, "Wheel of the Year for road", 75.00m, 2.0, "BID12345679", null },
                    { 2, 12, "7d47ca5c-ef3a-4bc0-a8af-f024464e27eb", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "test", "6af8468c-63f1-4bf2-8f88-e24b3f7a8f91", null, false, false, "Shift", 220.00m, 2.0, "BID12345679", null },
                    { 3, 1, "7d47ca5c-ef3a-4bc0-a8af-f024464e27eb", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "test", null, null, false, false, "Frame OG", 100.00m, 1.0, "BID12345680", null },
                    { 3, 5, "7d47ca5c-ef3a-4bc0-a8af-f024464e27eb", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "test", null, null, false, false, "Wheel of the Year for montain", 85.00m, 6.0, "BID12345680", null },
                    { 3, 11, "7d47ca5c-ef3a-4bc0-a8af-f024464e27eb", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "test", null, null, false, false, "Road budget Shifts", 290.00m, 4.0, "BID12345680", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BikeModelsParts_BikeModelId",
                table: "BikeModelsParts",
                column: "BikeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_TownId",
                table: "Clients",
                column: "TownId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ClientId",
                table: "Comments",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PartId",
                table: "Comments",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_CompatiblePartPart_PartsId",
                table: "CompatiblePartPart",
                column: "PartsId");

            migrationBuilder.CreateIndex(
                name: "IX_Delivaries_PartId",
                table: "Delivaries",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_Delivaries_SuplierId",
                table: "Delivaries",
                column: "SuplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagesClients_ClientId",
                table: "ImagesClients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagesEmployees_EmployeeId",
                table: "ImagesEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagesParts_PartId",
                table: "ImagesParts",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusId",
                table: "Orders",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersPartsEmployees_EmployeeId",
                table: "OrdersPartsEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersPartsEmployees_PartId",
                table: "OrdersPartsEmployees",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersPartsEmployeesInfos_OrderId_PartId_UniqueKeyForSerialNumber",
                table: "OrdersPartsEmployeesInfos",
                columns: new[] { "OrderId", "PartId", "UniqueKeyForSerialNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_PartOrders_PartId",
                table: "PartOrders",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_PartOrders_PartId1",
                table: "PartOrders",
                column: "PartId1");

            migrationBuilder.CreateIndex(
                name: "IX_PartOrders_SuplierId",
                table: "PartOrders",
                column: "SuplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_CategoryId",
                table: "Parts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_VATCategoryId",
                table: "Parts",
                column: "VATCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PartsInStock_SuplierId",
                table: "PartsInStock",
                column: "SuplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_ClientId",
                table: "Rates",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BikeModelsParts");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "CompatiblePartPart");

            migrationBuilder.DropTable(
                name: "Delivaries");

            migrationBuilder.DropTable(
                name: "ImagesClients");

            migrationBuilder.DropTable(
                name: "ImagesEmployees");

            migrationBuilder.DropTable(
                name: "ImagesParts");

            migrationBuilder.DropTable(
                name: "OrdersPartsEmployeesInfos");

            migrationBuilder.DropTable(
                name: "PartOrders");

            migrationBuilder.DropTable(
                name: "PartsInStock");

            migrationBuilder.DropTable(
                name: "Rates");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "BikesStandartModels");

            migrationBuilder.DropTable(
                name: "CompatableParts");

            migrationBuilder.DropTable(
                name: "OrdersPartsEmployees");

            migrationBuilder.DropTable(
                name: "Supliers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "PartCategories");

            migrationBuilder.DropTable(
                name: "VATCategories");

            migrationBuilder.DropTable(
                name: "Towns");
        }
    }
}