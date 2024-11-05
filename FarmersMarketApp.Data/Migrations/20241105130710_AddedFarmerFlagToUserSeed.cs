using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedFarmerFlagToUserSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "IsFarmer", "PasswordHash" },
                values: new object[] { "9c05d0b0-3581-440f-8d2f-b8c5f4f5de84", true, "AQAAAAIAAYagAAAAEExF8gOCucOyiE3T5s/mUIaBBTIXTlJ5MpThqIG0nE0IQW2cQ5u3my42NCqMisJp8w==" });

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
                columns: new[] { "ConcurrencyStamp", "IsFarmer", "PasswordHash" },
                values: new object[] { "a68e1f6a-3f6d-425a-80d9-3083eec8c97f", true, "AQAAAAIAAYagAAAAEMK+bnPGAdvGFr/I15XVk1AhZgAuDAjpIOjBCmgbN4gyMPHblyHrkxB90ExKtjWFQw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "IsFarmer", "PasswordHash" },
                values: new object[] { "19510039-7516-4d69-ab22-d1ab939fe653", true, "AQAAAAIAAYagAAAAEKcqgESL1xq73CguR76bcgunQJdVT6jeUeTEBlHXJz1eA12Q5b5Lzs0zXdZRNQefug==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6aa8d9e4-236b-460b-9530-ce4528b39219", "AQAAAAIAAYagAAAAECmthKOTVhtU6Mt33arFTGMQNof81jayRRek/Hy4I8WZIR3JGyYM1NjyBGje0kDMHA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "IsFarmer", "PasswordHash" },
                values: new object[] { "16b2ef2d-f990-4a7b-9d49-22954d49306b", false, "AQAAAAIAAYagAAAAEGdgZNP07nSrzLLHjNwR+ncoaWPepi5PrcgDjP/sJER5J8RQYXbtqSK20bMcqHBCgg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a36bfb04-baa4-4126-a68f-3e446d915446", "AQAAAAIAAYagAAAAEGFQ1v/2HMqtlMRQV+xioPzRGssjw+Msu4Q7NIbVuMALH31tliSyRobzOZ+9W5CyZQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "IsFarmer", "PasswordHash" },
                values: new object[] { "53689e20-55e2-48a7-acea-d3d3f0545ba2", false, "AQAAAAIAAYagAAAAENUidhATg1qQI0Jf2VW9HDWabBohEdXLhU9TlcYK9wS3kYtxbBQa7Vk4+RAQhAkUoA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "IsFarmer", "PasswordHash" },
                values: new object[] { "eb8c80d2-0c75-49fd-9035-572a19479f1d", false, "AQAAAAIAAYagAAAAEEd4zZQhaCcVerV7gvYLngR7MO+s71NZVf/VtLUOy1fMQJ41VQg9OOU94dRAn8glpw==" });
        }
    }
}
