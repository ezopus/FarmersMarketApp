using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FarmerIdInProductOrderMadeNotNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "FarmerId",
                table: "ProductsOrders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Unique farmer id for person handling the order.",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "Unique farmer id for person handling the order.");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d6e42c66-a018-42f6-bf33-b30eb3f41459", "AQAAAAIAAYagAAAAEGNi7YANUq/d3zHKzu72XR4+Wxi/yfkI8HgODH1enzPxCUoX4nEj//FIzDAG/+g2MQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b8172767-3967-4112-96f9-57e80ce81757", "AQAAAAIAAYagAAAAEHqgQki0wmcp6X31hKV9QCtz9Kq2MaX1zvjbV2Suhm1gbLshCoHStLW2A84q1UJ1IA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "35b513f3-cdb8-4a85-9554-f822d8fb916a", "AQAAAAIAAYagAAAAEEfINaRGE4T0iQdo3JLy8RcF1dTRUWi9wlrX0/5tT3DTdBeq0Ty9y/pdnh9nZ1Gykg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5fbb3026-4ddf-4003-878f-bb5ef326c703", "AQAAAAIAAYagAAAAENGeWb5bHXtLkO8LZO5dQN0bsAdyKWRbTNML3kforLv3BrMCcEToMSg3Fe0dKVxDuA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3faa57f4-5856-4776-a1ed-a42a9fee7b55", "AQAAAAIAAYagAAAAENW/gB05IEu0oUeqJb0fn8A1j7QOdtR5EWDhmCkcpo92tkXZQKzDopHye6gwUIWTWw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "FarmerId",
                table: "ProductsOrders",
                type: "uniqueidentifier",
                nullable: true,
                comment: "Unique farmer id for person handling the order.",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Unique farmer id for person handling the order.");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f6dc5067-cdd8-4300-959f-789dacbb9ac4", "AQAAAAIAAYagAAAAEGpfMsdmQmmdAjoIv4djayTGGGRfE57IdWAo4l0gqKL82XQiQVQokaQ9eliQ5QCNAg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1709efda-4d2f-4e45-b9e1-55117f56f0fd", "AQAAAAIAAYagAAAAEKDLcFqnadnUy8PMnOdvRa3mLkyQwKD48+L0fJqcunDgtrCAFTg40HGR7bUWhbj6Bg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dce6f38c-c454-4702-927e-b438c7ae2e89", "AQAAAAIAAYagAAAAEIz16bR3p5GN2XH8Pys6Os01TeNKqGN94f5Yiu7bB3bafO7nMBxlQsleI+WO56Basg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "154bd9c4-5206-48e7-8003-3301158d6293", "AQAAAAIAAYagAAAAEMVGBm+xhRLMS+CWn62mAstpm6ctCTWcgGDW/H+vo+jM659rHB1R7Bsb2YWIfog90A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1eae7f02-5d3f-4af9-95ef-53abccb209e5", "AQAAAAIAAYagAAAAEAoji3J1xMhJgl34fcsQDjOyghI4UPA7Vg0iZ0N6KTYDPBTzX5S/cGHdFG3ITLQr5Q==" });
        }
    }
}
