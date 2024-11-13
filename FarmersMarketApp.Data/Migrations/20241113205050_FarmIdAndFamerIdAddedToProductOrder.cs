using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FarmIdAndFamerIdAddedToProductOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FarmId",
                table: "ProductsOrders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Unique farm identifier where product is being made.");

            migrationBuilder.AddColumn<Guid>(
                name: "FarmerId",
                table: "ProductsOrders",
                type: "uniqueidentifier",
                nullable: true,
                comment: "Unique farmer id for person handling the order.");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryCity",
                table: "Orders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                comment: "City for delivery of order.",
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80,
                oldNullable: true,
                oldComment: "City for delivery of order.");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FarmId",
                table: "ProductsOrders");

            migrationBuilder.DropColumn(
                name: "FarmerId",
                table: "ProductsOrders");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryCity",
                table: "Orders",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true,
                comment: "City for delivery of order.",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true,
                oldComment: "City for delivery of order.");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "be49070f-5ce6-4880-a762-b6f35f79db65", "AQAAAAIAAYagAAAAEJwSF0PP2DAtpK6AxAm8yzHXz8iaxNal4xZ67AH45bOLM7S4gzV0sC9L9I4slLCUPw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0c73d82d-f36d-46d4-af93-582d50f98ee9", "AQAAAAIAAYagAAAAEN2nwZgpWZ848lZPPNy14wXHobtORYn34MxRUS9c57IwaFinSh1dASEyOnkTN4TaiQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8a3e55d0-ecb7-4f85-ae23-2eb72a5bf0f5", "AQAAAAIAAYagAAAAEA2N9FygeDkdTLvPGubAfMcZuxJ9Twke2SV594UX8wRraOwP3Jl+qsko8h1RMHyvaQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7b4e7091-7f6c-4d95-8c95-a6851b6f254b", "AQAAAAIAAYagAAAAELyeb+INGsZERfnAbcbZMXOcq5jFP3evTxRAxoU64/myfGffiHJ3zFPdG3sxvrEH1g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c659b06c-8618-4b8b-9188-a6f35aeb14b9", "AQAAAAIAAYagAAAAEOCo/oHmOICSKpjEdqUy65UIFNsmUHBak7434cWs1blVcW7xv4N6dNfEo4X6SNRH/w==" });
        }
    }
}
