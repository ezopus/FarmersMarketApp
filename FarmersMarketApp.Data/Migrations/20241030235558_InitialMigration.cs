using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FarmersMarketApp.Infrastructure.Migrations
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "First name of application user."),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Last name of application user."),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Physical address of application user."),
                    IsFarmer = table.Column<bool>(type: "bit", nullable: false, comment: "Flag to show if user is a farmer or not."),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Category identifier.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Category name.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Farms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique identifier of farm"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Farm name."),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Physical address of farm."),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "City where farm is located or close to."),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Email address of farm for enquiries."),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Phone number of farm visible to general public."),
                    OpenHours = table.Column<TimeOnly>(type: "time", nullable: true, comment: "Opening hours of farm operations."),
                    CloseHours = table.Column<TimeOnly>(type: "time", nullable: true, comment: "Closing hours of farm operations."),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false, comment: "Flag to check if farm is open for business.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "Farmers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Farmer unique identifier."),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to general application user."),
                    HasProducts = table.Column<bool>(type: "bit", nullable: false, comment: "Flag to show if farmer has any products for sale."),
                    AcceptsDeliveries = table.Column<bool>(type: "bit", nullable: false, comment: "Flag to show if farmer is currently accepting deliveries."),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Company name of farmer for billing purposes."),
                    CompanyRegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Company registration number for VAT and tax purposes."),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Company address for billing and shipping purposes.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Farmers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique payment identifier."),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Total payment amount."),
                    PaymentType = table.Column<int>(type: "int", nullable: false, comment: "Type of payment method used."),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique customer identifier."),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time on which payment is made."),
                    IsSuccessful = table.Column<bool>(type: "bit", nullable: false, comment: "Flag is payment is successful."),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique order identifier.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoriesFarmers",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Category identifier."),
                    FarmerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Farmer identifier.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesFarmers", x => new { x.CategoryId, x.FarmerId });
                    table.ForeignKey(
                        name: "FK_CategoriesFarmers_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CategoriesFarmers_Farmers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FarmerFarm",
                columns: table => new
                {
                    FarmerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique farmer identifier."),
                    FarmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique farm identifier."),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmerFarm", x => new { x.FarmId, x.FarmerId });
                    table.ForeignKey(
                        name: "FK_FarmerFarm_Farmers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FarmerFarm_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique identifier of each product."),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Product name."),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Description of product in free text format."),
                    UnitType = table.Column<int>(type: "int", nullable: false, comment: "Type of unit which product is distributed in - box, carton, bottle, etc."),
                    Size = table.Column<double>(type: "float", nullable: false, comment: "The size of one individual product in one sold unit."),
                    Quantity = table.Column<double>(type: "float", nullable: false, comment: "Amount of products in each unit."),
                    NetWeight = table.Column<double>(type: "float", nullable: false, comment: "Weight of product in kilograms"),
                    ShippingWeight = table.Column<double>(type: "float", nullable: false, comment: "Weight of product with container"),
                    Season = table.Column<int>(type: "int", nullable: true, comment: "Specific season for product if applicable"),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Production date of product."),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Expiration date of product."),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Category identifier of product."),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Price of product for one unit."),
                    HasDiscount = table.Column<bool>(type: "bit", nullable: false, comment: "Flag if product has active discount."),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true, comment: "Percentage of discount."),
                    FarmerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique identifier of farmer who produces current product."),
                    FarmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique identifier of farm where product is made."),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Unique barcode of product."),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Image url of product."),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Specific origin of product if applicable")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Farmers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique order identifier"),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique customer identifier"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time on which order is placed."),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Expected date and time on which order is going to be delivered."),
                    TotalNetWeight = table.Column<double>(type: "float", nullable: false, comment: "Total net weight of all items in order."),
                    TotalUnitItems = table.Column<int>(type: "int", nullable: false, comment: "Total number of units of products contained in order."),
                    TotalDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: true, comment: "Total discount if applicable."),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Total price of order including discounts.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Payments_Id",
                        column: x => x.Id,
                        principalTable: "Payments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductsOrders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique order identifier."),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique product identifier."),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsOrders", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductsOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductsOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Meat" },
                    { 2, "Dairy" },
                    { 3, "Grain" },
                    { 4, "Fats" },
                    { 5, "Fruits" },
                    { 6, "Vegetables" },
                    { 7, "Sweets" },
                    { 8, "Fish" },
                    { 9, "Eggs" },
                    { 10, "Drinks" }
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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesFarmers_FarmerId",
                table: "CategoriesFarmers",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmerFarm_FarmerId",
                table: "FarmerFarm",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_UserId",
                table: "Farmers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CustomerId",
                table: "Payments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FarmerId",
                table: "Products",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FarmId",
                table: "Products",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsOrders_ProductId",
                table: "ProductsOrders",
                column: "ProductId");
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
                name: "CategoriesFarmers");

            migrationBuilder.DropTable(
                name: "FarmerFarm");

            migrationBuilder.DropTable(
                name: "ProductsOrders");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Farmers");

            migrationBuilder.DropTable(
                name: "Farms");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
