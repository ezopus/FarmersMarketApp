using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FarmersSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "56b24c58-a765-49f3-9efc-a0ca0886c6a9", "AQAAAAIAAYagAAAAEA7zAv9EOCqXDg25xuobx1db3ktgJaZbSztRMubavgsbMspwf1NCqMlAeauecIW24g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "69836e63-f68e-488f-a1ce-235fc9de3eca", "AQAAAAIAAYagAAAAEEV3XgjuAJwfYgsDrGxN7cT/CS/jSDJR5z0mUY2KMTR2/UG2natk313g1J3NEozNtQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a6b20b95-cd6b-4643-aed9-1b0ecd1bcd37", "AQAAAAIAAYagAAAAEEGWcI7lC5OGRTAUDHBGkgB9dyt1b1dtC2dLVJOl4r624LWlWIwDuuAuoU7mtDqpDw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3e9a8682-7853-4ea8-a0de-f82e3269ee72", "AQAAAAIAAYagAAAAEN6GGurT0Efmea72OvuTQVgjQGR+dpS366W0/BmSVJ7BEunjjQ3CHea48NI2B4pS4g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c8eac554-fde8-4174-baa9-3f9a02b285f3", "AQAAAAIAAYagAAAAEOr3kPKUguEySh3HxYVK4MZ9j8gfM3vwejJ3NKkNgc8l54aq+fT0wd2y016y6O/pNg==" });

            migrationBuilder.InsertData(
                table: "Farmers",
                columns: new[] { "Id", "AcceptsDeliveries", "CompanyAddress", "CompanyName", "CompanyRegistrationNumber", "HasProducts", "UserId" },
                values: new object[,]
                {
                    { new Guid("1474d237-fe36-4586-ac67-b3ddcf03baac"), true, "321 Privet Drive", "Milky Way", "315252331", true, new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5") },
                    { new Guid("65c75a94-f3be-4a7a-913e-d6c868876265"), true, "1 Ocean Avenue", "FilletOFish", "335788211", true, new Guid("df1516df-4501-475e-c02a-08dcf857a1b7") },
                    { new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"), true, "44 Chicken Road", "Los Pollos Hermanos", "123772341", true, new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: new Guid("1474d237-fe36-4586-ac67-b3ddcf03baac"));

            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: new Guid("65c75a94-f3be-4a7a-913e-d6c868876265"));

            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "aff4a892-38d0-4cef-853d-db7171304029", "AQAAAAIAAYagAAAAEKBqz6Y40W5uD57acXSLmGlxAgw8FkosIbaEZTGBNnYLs+FTAy0ey4bNcHVCUF2t3w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fe7668f7-e3eb-494d-837f-f7dcd6f4ba04", "AQAAAAIAAYagAAAAENoxW4qnWHlNBwtW5t3LW6ReO1dhhxgUhogr942hj+EoGj0LUIV99lswARGSKwBS8g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "74ed8fd4-4b9b-43ff-a634-7800c52223f0", "AQAAAAIAAYagAAAAEATrMVco8f4PJN9RHvVMRyoM6M2/mYD7Z9EUkZ/mNJxg7W7AsFmkvpOivpoM5UdZcw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8c7df156-9e67-4aad-bdc9-ff7472e578a1", "AQAAAAIAAYagAAAAECHWMKHVft7dmC5/m95TLnCaq2SAV4IrZW5qh+P6UAZRxeDZqvSxraeHXIicJh9jEA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fe2739a1-977f-4062-a1fe-3ad6c1b2293c", "AQAAAAIAAYagAAAAEDHhBqm7U7bxVUgtCdiKmdLi3odw69s5/p79LPtpltzB7LbNLD20Dsr5vCxAFrYOug==" });
        }
    }
}
