using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedImageUrlToAppUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "ImageUrl", "PasswordHash" },
                values: new object[] { "94bfa456-beaa-4094-accd-fb2df0f58b25", "", "AQAAAAIAAYagAAAAEOinBwjNzJwHgzDp23n4HqgJ3WXdwICoDDJ6fboQHsHPU0fSZA9tDy/3EpXvBFmJqw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "ImageUrl", "PasswordHash" },
                values: new object[] { "53ac32cc-6b43-4991-916f-6980d08a5a0b", "/img/dwight.jpg", "AQAAAAIAAYagAAAAEAA9u+HJkOPUeO2OiGiYLZQJmntD8Rni0DFBV6GdeZ5UP0rqSgiAf8hEtokMREaOIA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "ImageUrl", "PasswordHash" },
                values: new object[] { "cde1a723-b4de-4082-bd7c-78e49d0c36f6", "", "AQAAAAIAAYagAAAAEFFJySPmwNLHeUm9uErKZ3M4Hil+oMI4D2MctsSsSRNo0m7WwRmN+vz74GqIwvlpQQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "ImageUrl", "PasswordHash" },
                values: new object[] { "85ea263e-c52e-441f-af52-40a89d88a620", "/img/michael.jpg", "AQAAAAIAAYagAAAAEP+pfuoNXU4uPLDPSR55s3IJ+FPcpV77GgKvY4QYk4FsdYWl1GD6AkKH6KXNs2UCdg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "ImageUrl", "PasswordHash" },
                values: new object[] { "dda293c4-b71e-4a8c-a326-19850e144ca2", "/img/kevin.jpg", "AQAAAAIAAYagAAAAEMhNR5QpY+k5z9oCM9VLICR1EjjHen60z4QIzfIX/+rw8AuKQOidSpGew1LoLGMeAQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8c925d57-4ca4-46bf-81f6-a2a500b95174", "AQAAAAIAAYagAAAAEPJEhm/1AMKVR0sSMMyNTweO63ht/f2rRG+yLIlCOQNQ4d3TJMkIVKUyDgOWNybGOA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3e48d037-475e-4b83-baf7-6a71f3e20a7c", "AQAAAAIAAYagAAAAEAkuS1PS58mhYu0HOBRHwi8a2Iwvx48woTubvTDyMRvf45oaioqyMaqe0CP53rmXuA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f81fa799-ae0b-43a4-b28d-b7f0f21283ca", "AQAAAAIAAYagAAAAELHdvjys+2CRXxcxKkxX6PFaajF/m9hJw0Xc8t9QRQXZbp4YqBJr86k/dvpejNE1aA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fa9f1d35-425f-426c-b512-032c727ae17d", "AQAAAAIAAYagAAAAEN3FQHOSEzvk35GY/Gq8J/ntFoZtBX093PP6SY1CfX9JAzEBkfedmnrTmZYaMhD6DA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a2e98a74-abe1-4122-9fe1-34fbf9bf91e3", "AQAAAAIAAYagAAAAEImeXRl1Qq+0Ao2zfBVXGTGdveJoB5Gn+qFYI0hVKC6ICqhCZKxxSFzIZaavxQmD8Q==" });
        }
    }
}
