using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductShippingWeightMadeNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ShippingWeight",
                table: "Products",
                type: "float",
                nullable: true,
                comment: "Weight of product with container",
                oldClrType: typeof(double),
                oldType: "float",
                oldComment: "Weight of product with container");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3b3db4f9-6a40-4a69-ae27-dc4a6556429b", "AQAAAAIAAYagAAAAEKSt+M5DMbsPZ1ui/wiCLVPzXLdouHm6TnvG0MPAdg7nf33WBCRupu6OXjQLmlpBWw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "12abdfe8-e44f-4970-92ff-96ba7a2afbb8", "AQAAAAIAAYagAAAAEHnW6sGPLWK6zAjqrJ0J3wEKDPsTdi4Rv1bP0qPIlC5TXnAlq7YiYkBWbSNn+qLyRA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "65ffa81f-7bc5-4f25-aef8-2573cbd23a45", "AQAAAAIAAYagAAAAEH0Dgy5yT/wztp2OHERvC1VVryHClYDgNyBIAo4BkWHpXbdWHh8jHbTdeSlRB2ZrWQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "99a33050-4c2f-4775-b458-2c1878e37804", "AQAAAAIAAYagAAAAEKV3uZ1Z6UTDh+Ds7sPdOMNFT/HdLsj3JZgJBKp+a9p0aedPLY+MFU+G5Ty2hjy8oQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "af331f4a-bac4-4bd1-9195-4681547ac4c7", "AQAAAAIAAYagAAAAEHqttEXNDkimYeSxGwN/5NUXLqr7wT3WzgXZhXwltTapYA8xanw2MAQcXlQaRH0Aug==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ShippingWeight",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                comment: "Weight of product with container",
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true,
                oldComment: "Weight of product with container");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fff05740-fcc6-413e-a82c-da12403cb8dc", "AQAAAAIAAYagAAAAEAVFkqBedmHoJEmlwV2CuXUu88JVcRlZ9e3+z73bQe6PdQPv5x9KlA/oln1UolUbfg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b27b4ee2-8445-4784-8ab0-988a167b338f", "AQAAAAIAAYagAAAAEJvM/kn41VYRFODOXc0NBf5+7eWvZnd/UNGkWuRKNAdWXG44j2oNpVU3lnakcMd/WQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b18a238b-d41e-4fa7-a99e-505f8d89baf3", "AQAAAAIAAYagAAAAEEdEPq9jioYFmarYGyFMS6GK/0hIQ9spGV7FhdzC5UK/ozJGHSA7b2++Tnoxkl0bJQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "af41d00a-a36a-4128-88ea-9f376daa97f1", "AQAAAAIAAYagAAAAEGBGweFjrQR3EdngGPAZvkCjJPwGRDwkX7Lc2VAWr/Wv6q4ecc8Ta0O8xKyNzxLssA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "809629a0-5fa5-4ad9-9897-c59eee4f0ed9", "AQAAAAIAAYagAAAAEIAV1SfRQkUmNGwyj/WUOq93sGJHfkSrMGCXU/PZkhFJyvrNMwU3TjqLZTXtE0c1Mw==" });
        }
    }
}
