using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductSizeAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
