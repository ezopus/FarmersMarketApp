using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductOrderUpdatedAndColumnCommentsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalDiscount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalNetWeight",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalUnitItems",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "ProductQuantity",
                table: "ProductsOrders",
                type: "int",
                nullable: false,
                comment: "Product quantity in order",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "ProductPriceAtTimeOfOrder",
                table: "ProductsOrders",
                type: "decimal(18,2)",
                nullable: false,
                comment: "Product price at time of purchasing for history purposes.",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ProductsOrders",
                type: "bit",
                nullable: true,
                comment: "Boolean check if product is part of an order which is deleted.",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ProductDiscountAtTimeOfOrder",
                table: "ProductsOrders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                comment: "Product discount at time of purchasing for statistical purposes.");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3d666f8e-38cd-4f94-97e3-c7fd9aa5bd45", "AQAAAAIAAYagAAAAEMxUUtrdrNkZ48lQbtwchi7ges/oEiygfxqHUJTKXcvzvzEvomX7RvDmB1parMwp3g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "82a0b13b-7dc0-4da8-93bc-0760a86a6ff7", "AQAAAAIAAYagAAAAEOxa5OPF26fGxCzCuoVpzdqKc59Bv+SfpgAa1lFM6jIywXrr1stRp078gqBxoy2GIA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d115ffb4-03a8-417b-a953-a5d6b1bb58be", "AQAAAAIAAYagAAAAEHUuwGld7D5+Eq5Wh9jK12ORfOjQGf66Ts78Jy0swiynl5MAhbnxOl/xEkPJMHDVpA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "56ce5abc-bd75-4dc5-b101-e204b52b9b04", "AQAAAAIAAYagAAAAEHpWbFjdd13o/Py5b7Tmap84KuEKsCzN3TIJlTWN3wYQriLy1//G+u45LjtBSF4IUg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1a7671c7-5f9b-4a1c-a6c2-acdc7224f9cd", "AQAAAAIAAYagAAAAEG+q2n7NAls+CIEibKiNu4J6LZTI8RKtaq9ucMakGK6kLPv14GZ4fFuOmR1rDzZ+Ig==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductDiscountAtTimeOfOrder",
                table: "ProductsOrders");

            migrationBuilder.AlterColumn<int>(
                name: "ProductQuantity",
                table: "ProductsOrders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Product quantity in order");

            migrationBuilder.AlterColumn<decimal>(
                name: "ProductPriceAtTimeOfOrder",
                table: "ProductsOrders",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComment: "Product price at time of purchasing for history purposes.");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ProductsOrders",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldComment: "Boolean check if product is part of an order which is deleted.");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalDiscount",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: true,
                comment: "Total discount if applicable.");

            migrationBuilder.AddColumn<double>(
                name: "TotalNetWeight",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                comment: "Total net weight of all items in order.");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                comment: "Total price of order including discounts.");

            migrationBuilder.AddColumn<int>(
                name: "TotalUnitItems",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Total number of units of products contained in order.");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8893c846-6c3c-4aab-a7f4-587844fbb520", "AQAAAAIAAYagAAAAEPq0Y5xEnJ9/wXAP/S24YMJiAsc2t2ftgjT9ETZRsnWjLDVPtoQ06WsCz/ht4XBYlA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "257e64bd-2223-4fbc-9e7c-27a555c488b7", "AQAAAAIAAYagAAAAECWbkLktXpitxIKHtgxxO0MCUHaQ4ciB4RS4x9YNZBrouvJY7H3Yjvj3MbufMeQMSQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a14b45a1-92f9-4be1-96af-91b10ec9a443", "AQAAAAIAAYagAAAAEHXP+U0Tunx5NdA4fmQu+XkJVdrQz99Nu4pz6dpH/w4pjFSBNWaCC6UYT8qpjTPUHA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "16542e82-da60-4b83-9bbb-3612a86a7da5", "AQAAAAIAAYagAAAAEKTvTbNzI+08MARZm8QFicwIxVe9L48aTdNbgWBvXTT92xJOFZfoGwQChINUGZ5EXA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "01d6cc11-14bc-4822-9436-66c2ba3c3bd4", "AQAAAAIAAYagAAAAEGBWCFY81HUV1onLkAyZ/As6RHkgUrLA+OZ4XCOOWowGQG30JEc/R2WEF+3b594nOw==" });
        }
    }
}
