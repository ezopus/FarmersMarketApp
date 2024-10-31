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
                    { new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"), 0, null, "aff4a892-38d0-4cef-853d-db7171304029", "jim@office.com", true, "Jim", false, "Halpert", false, null, "JIM@OFFICE.COM", "JIM@OFFICE.COM", "AQAAAAIAAYagAAAAEKBqz6Y40W5uD57acXSLmGlxAgw8FkosIbaEZTGBNnYLs+FTAy0ey4bNcHVCUF2t3w==", null, false, "08f6ec97-4269-466d-b207-47e30c651036", false, "jim@office.com" },
                    { new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"), 0, null, "fe7668f7-e3eb-494d-837f-f7dcd6f4ba04", "dwight@office.com", true, "Dwight", false, "Schrute", false, null, "DWIGHT@OFFICE.COM", "DWIGHT@OFFICE.COM", "AQAAAAIAAYagAAAAENoxW4qnWHlNBwtW5t3LW6ReO1dhhxgUhogr942hj+EoGj0LUIV99lswARGSKwBS8g==", null, false, "618a1cc6-6284-4702-871c-1e58fe74f3f8", false, "dwight@office.com" },
                    { new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"), 0, null, "74ed8fd4-4b9b-43ff-a634-7800c52223f0", "creed@office.com", true, "Creed", false, "Bratton", false, null, "CREED@OFFICE.COM", "CREED@OFFICE.COM", "AQAAAAIAAYagAAAAEATrMVco8f4PJN9RHvVMRyoM6M2/mYD7Z9EUkZ/mNJxg7W7AsFmkvpOivpoM5UdZcw==", null, false, "a361e509-ad28-459e-b4c6-449937b3e998", false, "creed@office.com" },
                    { new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"), 0, null, "8c7df156-9e67-4aad-bdc9-ff7472e578a1", "michael@office.com", true, "Michael", false, "Scott", false, null, "MICHAEL@OFFICE.COM", "MICHAEL@OFFICE.COM", "AQAAAAIAAYagAAAAECHWMKHVft7dmC5/m95TLnCaq2SAV4IrZW5qh+P6UAZRxeDZqvSxraeHXIicJh9jEA==", null, false, "288b8da7-b517-4f95-af28-3916b878adc1", false, "michael@office.com" },
                    { new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"), 0, null, "fe2739a1-977f-4062-a1fe-3ad6c1b2293c", "kevin@office.com", true, "Kevin", false, "Bacon", false, null, "KEVIN@OFFICE.COM", "KEVIN@OFFICE.COM", "AQAAAAIAAYagAAAAEDHhBqm7U7bxVUgtCdiKmdLi3odw69s5/p79LPtpltzB7LbNLD20Dsr5vCxAFrYOug==", null, false, "fd625ce4-2475-4d80-a609-df9d3ddf4598", false, "kevin@office.com" }
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
