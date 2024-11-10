using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedProductPriceAtTimeOfOrderToProductOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ProductPriceAtTimeOfOrder",
                table: "ProductsOrders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductPriceAtTimeOfOrder",
                table: "ProductsOrders");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "de66d87f-4946-4a93-a79e-e9b821bbc9bf", "AQAAAAIAAYagAAAAEOMQR1Jp9frEimiV4P0IbzWkZJeHwKgIrfdTcIzUG6FR9E4O84inF3EaKoZROeZpBA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "505817c0-bc00-4c72-b06a-f2957a63524d", "AQAAAAIAAYagAAAAEA92M1E+yqxXTGbKIT4vn8ddE6hx1Ljal0pQIL6vmnEjKxudcgw+uziFdwEbrk7hXw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "758e8918-2497-4bce-870d-fb2abad756cf", "AQAAAAIAAYagAAAAEHbR69cYbJ3i2XKszge/DO9rEvAqBa66GM9m+cCB+kdY43bYR2A4y0JDyWLAyAX4AA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9df6f28e-d4ed-4f7a-a5bc-5470f15c3f99", "AQAAAAIAAYagAAAAEEVwqCdRujdWSTXKGauLDVg0ebumaPy3PrZwXVvICKZ/ajaTRYlWnei3LbdHR84d7Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4be98aeb-c0cc-47c8-90aa-24cd395162fe", "AQAAAAIAAYagAAAAEIoRCo2nEZnvcAzw3ORRqykqqzziGYE1C2Aj8Wrw7BotYCM91QylLQE9uuhSwOTxMQ==" });
        }
    }
}
