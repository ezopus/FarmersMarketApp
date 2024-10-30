using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UsersSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsFarmer", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"), 0, null, "99e8d0e1-2a4b-4d14-ae59-bd854a037c5d", "jim@office.com", true, "Jim", false, "Halpert", false, null, "JIM@OFFICE.COM", "JIM@OFFICE.COM", "AQAAAAIAAYagAAAAELVLmYPoyvzeuoZQrxTU0TsBu9d/KRlRv/JcISJGKsP+ZaBZs473kTxhXp1CK1zcWQ==", null, false, "08f6ec97-4269-466d-b207-47e30c651036", false, "jim@office.com" },
                    { new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"), 0, null, "4c9b92be-f570-4fb7-8dc6-269313e06f7c", "dwight@office.com", true, "Dwight", false, "Schrute", false, null, "DWIGHT@OFFICE.COM", "DWIGHT@OFFICE.COM", "AQAAAAIAAYagAAAAEOjIV5+eqb8W/v4FRwurKjzcctmxuyEkiBk2NKUdQOmjkb63AXL0UwP+kljI2nW6Sw==", null, false, "618a1cc6-6284-4702-871c-1e58fe74f3f8", false, "dwight@office.com" },
                    { new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"), 0, null, "f963a08d-dc77-415b-88cd-e7a86de2b3c0", "creed@office.com", true, "Creed", false, "Bratton", false, null, "CREED@OFFICE.COM", "CREED@OFFICE.COM", "AQAAAAIAAYagAAAAEL4iv5BxxUkx1rG9rocD2nNDe+oiENeZdPFrzKLYnDR4y5b+2GsAx26vE95xvbYO/g==", null, false, "a361e509-ad28-459e-b4c6-449937b3e998", false, "creed@office.com" },
                    { new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"), 0, null, "f434ca82-a5bf-497f-bc78-e358d2c1d626", "michael@office.com", true, "Michael", false, "Scott", false, null, "MICHAEL@OFFICE.COM", "MICHAEL@OFFICE.COM", "AQAAAAIAAYagAAAAEEkw+cEMt4vLjrJQnw77z1400ZZu9ZenyuSpv4oZki2rLCFNJK67dKcICcy+WmvQWQ==", null, false, "288b8da7-b517-4f95-af28-3916b878adc1", false, "michael@office.com" },
                    { new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"), 0, null, "14d3da74-58b2-4ed1-a4bf-ffd6ce7afe3a", "kevin@office.com", true, "Kevin", false, "Bacon", false, null, "KEVIN@OFFICE.COM", "KEVIN@OFFICE.COM", "AQAAAAIAAYagAAAAEASbJyFeuWHQiFe5zScVGjDBimxapmMK9ruMfJl60S+mNYgTAC79Dj+e59Ft4SwLxA==", null, false, "fd625ce4-2475-4d80-a609-df9d3ddf4598", false, "kevin@office.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"));
        }
    }
}
