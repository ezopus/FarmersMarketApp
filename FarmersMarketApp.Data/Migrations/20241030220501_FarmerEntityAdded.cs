using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FarmerEntityAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Farms_FarmId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesFarmers_AspNetUsers_FarmerId",
                table: "CategoriesFarmers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_FarmerId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FarmId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AcceptsDeliveries",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CompanyAddress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CompanyRegistrationNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FarmId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HasProducts",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "Products",
                type: "float",
                nullable: false,
                comment: "Amount of products in each unit.",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Amount of products in each unit.");

            migrationBuilder.AddColumn<double>(
                name: "Size",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                comment: "The size of one individual product in one sold unit.");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Farms",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Phone number of farm visible to general public.",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Phone number of farm visible to general public.");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "OpenHours",
                table: "Farms",
                type: "time",
                nullable: true,
                comment: "Opening hours of farm operations.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Opening hours of farm operations.");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "CloseHours",
                table: "Farms",
                type: "time",
                nullable: true,
                comment: "Closing hours of farm operations.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Closing hours of farm operations.");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Physical address of application user.",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Physical address of application user.");

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
                    table.ForeignKey(
                        name: "FK_Farmers_Farms_Id",
                        column: x => x.Id,
                        principalTable: "Farms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_UserId",
                table: "Farmers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesFarmers_Farmers_FarmerId",
                table: "CategoriesFarmers",
                column: "FarmerId",
                principalTable: "Farmers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Farmers_FarmerId",
                table: "Products",
                column: "FarmerId",
                principalTable: "Farmers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesFarmers_Farmers_FarmerId",
                table: "CategoriesFarmers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Farmers_FarmerId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Farmers");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Products",
                type: "int",
                nullable: false,
                comment: "Amount of products in each unit.",
                oldClrType: typeof(double),
                oldType: "float",
                oldComment: "Amount of products in each unit.");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Farms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Phone number of farm visible to general public.",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Phone number of farm visible to general public.");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpenHours",
                table: "Farms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Opening hours of farm operations.",
                oldClrType: typeof(TimeOnly),
                oldType: "time",
                oldNullable: true,
                oldComment: "Opening hours of farm operations.");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CloseHours",
                table: "Farms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Closing hours of farm operations.",
                oldClrType: typeof(TimeOnly),
                oldType: "time",
                oldNullable: true,
                oldComment: "Closing hours of farm operations.");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "Physical address of application user.",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "Physical address of application user.");

            migrationBuilder.AddColumn<bool>(
                name: "AcceptsDeliveries",
                table: "AspNetUsers",
                type: "bit",
                nullable: true,
                comment: "Flag to show if farmer is currently accepting deliveries.");

            migrationBuilder.AddColumn<string>(
                name: "CompanyAddress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Company address for billing and shipping purposes.");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Company name of farmer for billing purposes.");

            migrationBuilder.AddColumn<string>(
                name: "CompanyRegistrationNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Company registration number for VAT and tax purposes.");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "FarmId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasProducts",
                table: "AspNetUsers",
                type: "bit",
                nullable: true,
                comment: "Flag to show if farmer has any products for sale.");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FarmId",
                table: "AspNetUsers",
                column: "FarmId",
                unique: true,
                filter: "[FarmId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Farms_FarmId",
                table: "AspNetUsers",
                column: "FarmId",
                principalTable: "Farms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesFarmers_AspNetUsers_FarmerId",
                table: "CategoriesFarmers",
                column: "FarmerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_FarmerId",
                table: "Products",
                column: "FarmerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
