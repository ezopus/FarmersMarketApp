using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedPaymentOrderOneToOneRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Payments_PaymentId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PaymentId",
                table: "Orders");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Payments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Unique order identifier for the payment record.");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4fc438b6-5967-4bb2-9191-4ea7d2902ae9", "AQAAAAIAAYagAAAAEPL+RkZc4w/NJTdfHDiz2192F+tftqsHdZgNwpahc/vQFXru483aeNp+2qfpBy+aqQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "63e4b22c-eb4b-48a5-be7a-6e2480790ec6", "AQAAAAIAAYagAAAAEKCGzkio2DZiWZJm4oaVYdl6WQ6GmCT0nJbXhC4UiSZAX4jjVIo+HHaWowMI+5/l8w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d677d5aa-5f50-49dc-8187-9729450559c7", "AQAAAAIAAYagAAAAEMVA3DhX8Mv73+2X60X2xEDyxdIOl5YZIJPKHZnZNofB10tEBK0zWd9QqTqMPnu18Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "22b83305-cf06-400b-a780-b83973e8c858", "AQAAAAIAAYagAAAAEHcaaHv8GiUnssAs4pvCy/D71p+t52lzCLv/Gu97O8BUnmDYZ0SKEdl/rZucfOFhww==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3e518194-34cc-420c-aa62-b74f57258d03", "AQAAAAIAAYagAAAAEDT1VzWRLjtxqvviSk+696dTOtIeuwScdHi+LokG+mGtpZy3gXvDHaxmEdsdd6ReHw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Orders_OrderId",
                table: "Payments",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Orders_OrderId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_OrderId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Payments");

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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentId",
                table: "Orders",
                column: "PaymentId",
                unique: true,
                filter: "[PaymentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Payments_PaymentId",
                table: "Orders",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id");
        }
    }
}
