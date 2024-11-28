using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedFarmerIdFromProductOrderEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FarmerId",
                table: "ProductsOrders");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "28772372-03f2-44cc-bf67-6411d95afe43", "AQAAAAIAAYagAAAAEBLArt30p9F2R/U4iTAZ7Sqxbp7KnIi4SlyIscFXhho/bgquiW8OTwXLJiICttPaHg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3ed03bb1-8f45-4f82-a2da-2afc17fece1d", "AQAAAAIAAYagAAAAENznXrJ+i2+2NGpNIYq+xv933V3vkIWM5rjcabyM//Bs1GgcClPs4ZkbkkYYZkPVFg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fe5f0886-3602-414b-9669-b291ca57ccc5", "AQAAAAIAAYagAAAAELpKJuNKsUzvr01Nw4tZiyR26x4T3UVdjleOKmqlcKi1X8diI4ooSBw6gMgeg8r0XQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a07b2cce-5ef6-446e-8e01-49ce42db1bc8", "AQAAAAIAAYagAAAAEA3WKbti9OX0R/DzkaN5iPYjJC0TAxRNrFz2v2B8y39oKVjN/DLw5A2dp9XqSoqNiA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7be750a8-0cc7-4bd3-afc6-bf0cc21aaaa2", "AQAAAAIAAYagAAAAECr89ziF0xSZmibP2gyQgOvRt7wkhtqmEASknjlxCEui4KG6QXX60VkoUSkGqE+zEA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FarmerId",
                table: "ProductsOrders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Unique farmer id for person handling the order.");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2073639b-c7f3-45cc-8ca7-ca1b5fda3765", "AQAAAAIAAYagAAAAEI++8z4b/E7DTFt/tslWkCqo1nURVdoGsOmJUCtoO1UYDyS0+lpru+zpkE9IWuMGAQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c0e20ef7-7edb-4af5-af6c-137f8b990f36", "AQAAAAIAAYagAAAAEHtsTq3JOQxT5ttn5BL4KA8SnVOr63pSp8z3iKPjvXg5xvr1Rv7lMVNRveqSDUm78Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "87cd7aa7-4c57-4259-a30d-758e79809bc8", "AQAAAAIAAYagAAAAEIYQHHrmq11nsRw/BInOwT8LB7kiLoQ71Oz7DRdTmmctiMraW6hzWJylEQR264yx7w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "361e3cf5-aa3f-4767-ac80-d380c31b8245", "AQAAAAIAAYagAAAAEFZzd22/p6vsvAZoClWpKczF4RX6tbSj6JVEJQITWBgnkgWQ12WqFEFTF1Qf0UT8KQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f38b0e32-c939-4568-8869-e4d7c40708b8", "AQAAAAIAAYagAAAAEPeU99HrQRBstv/u2/qTWgLylym9PLfsJwrQRJqXUqh9jdXbMrL4r6/elSYI5zbOig==" });
        }
    }
}
