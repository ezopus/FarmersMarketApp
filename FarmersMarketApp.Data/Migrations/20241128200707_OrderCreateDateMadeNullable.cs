using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OrderCreateDateMadeNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                comment: "Date and time on which order is placed.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date and time on which order is placed.");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Date and time on which order is placed.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "Date and time on which order is placed.");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e679247f-2c9f-49df-ab96-e026976a280a", "AQAAAAIAAYagAAAAEDPYJ1eh5bDHGc9o+s2tyH6H06gMmQKRVAL/LfOknmhtWcd5G3r5XM/wxbThHUYYng==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ba6fedb4-949b-441b-8851-97a4af6bd3f2", "AQAAAAIAAYagAAAAEMrILnnhgeffGL8jh6XOfezIiT3IJ196VWTGPtEpk8YS8fhlw01hSQfeFWtVEZI3XA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b669264e-4426-4d2d-8aa8-48bbb593b6df", "AQAAAAIAAYagAAAAEB7ObR1oB1hh1uQKw0TbBjKsDmfzT/91BjDVMwdOU648A0IMJRgMOm6CNI86nqAFbg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "82c63377-299c-4538-9a7d-699c6f4e3581", "AQAAAAIAAYagAAAAEPLBeSMoX23ixj3nFePcbvHuCkXvGko3HMhxVikLISztTwLO42Oe0zpTK3E2WvyAGA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "00de8274-92d9-49a5-b89c-eb100a5dc9cf", "AQAAAAIAAYagAAAAEIzt1hbgF3FOjEZGhFieJK+sSJwPSyAnVZJtBiGlPih1SP2AjHfnXqyARFPvMcSSqg==" });
        }
    }
}
