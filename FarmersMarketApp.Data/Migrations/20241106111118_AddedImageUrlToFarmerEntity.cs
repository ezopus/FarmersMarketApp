using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedImageUrlToFarmerEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Farmers",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Image URL of farmer.");

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

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: new Guid("1474d237-fe36-4586-ac67-b3ddcf03baac"),
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: new Guid("65c75a94-f3be-4a7a-913e-d6c868876265"),
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"),
                column: "ImageUrl",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Farmers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7ed0d5e7-bda9-4d49-9488-771beef78cad", "AQAAAAIAAYagAAAAEA8hD6Rq0gMqI8iIke71trMyPHDUsW3CsxKzoDnq2K/58mh2FAnDZEuySSjXyPp9Lw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9c05d0b0-3581-440f-8d2f-b8c5f4f5de84", "AQAAAAIAAYagAAAAEExF8gOCucOyiE3T5s/mUIaBBTIXTlJ5MpThqIG0nE0IQW2cQ5u3my42NCqMisJp8w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e4700758-c6ad-4e04-a723-f32293cb02eb", "AQAAAAIAAYagAAAAEEgAmRsCg2CuvzK6oy8b+LDfoM5WedKY+BGh+e/bNxrKx54c5Os5QZI2zdkRHi2qDg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a68e1f6a-3f6d-425a-80d9-3083eec8c97f", "AQAAAAIAAYagAAAAEMK+bnPGAdvGFr/I15XVk1AhZgAuDAjpIOjBCmgbN4gyMPHblyHrkxB90ExKtjWFQw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "19510039-7516-4d69-ab22-d1ab939fe653", "AQAAAAIAAYagAAAAEKcqgESL1xq73CguR76bcgunQJdVT6jeUeTEBlHXJz1eA12Q5b5Lzs0zXdZRNQefug==" });
        }
    }
}
