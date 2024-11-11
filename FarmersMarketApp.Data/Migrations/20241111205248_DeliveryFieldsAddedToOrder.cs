using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeliveryFieldsAddedToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddress",
                table: "Orders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Address for delivery of order.");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCity",
                table: "Orders",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true,
                comment: "City for delivery of order.");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryFirstName",
                table: "Orders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "First name of person for delivery of order.");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryLastName",
                table: "Orders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Last name of person for delivery of order.");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryPhoneNumber",
                table: "Orders",
                type: "nvarchar(17)",
                maxLength: 17,
                nullable: true,
                comment: "Phone number to contact for delivery of order.");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryAddress",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryCity",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryFirstName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryLastName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryPhoneNumber",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3d666f8e-38cd-4f94-97e3-c7fd9aa5bd45", "AQAAAAIAAYagAAAAEMxUUtrdrNkZ48lQbtwchi7ges/oEiygfxqHUJTKXcvzvzEvomX7RvDmB1parMwp3g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "82a0b13b-7dc0-4da8-93bc-0760a86a6ff7", "AQAAAAIAAYagAAAAEOxa5OPF26fGxCzCuoVpzdqKc59Bv+SfpgAa1lFM6jIywXrr1stRp078gqBxoy2GIA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d115ffb4-03a8-417b-a953-a5d6b1bb58be", "AQAAAAIAAYagAAAAEHUuwGld7D5+Eq5Wh9jK12ORfOjQGf66Ts78Jy0swiynl5MAhbnxOl/xEkPJMHDVpA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "56ce5abc-bd75-4dc5-b101-e204b52b9b04", "AQAAAAIAAYagAAAAEHpWbFjdd13o/Py5b7Tmap84KuEKsCzN3TIJlTWN3wYQriLy1//G+u45LjtBSF4IUg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1a7671c7-5f9b-4a1c-a6c2-acdc7224f9cd", "AQAAAAIAAYagAAAAEG+q2n7NAls+CIEibKiNu4J6LZTI8RKtaq9ucMakGK6kLPv14GZ4fFuOmR1rDzZ+Ig==" });
        }
    }
}
