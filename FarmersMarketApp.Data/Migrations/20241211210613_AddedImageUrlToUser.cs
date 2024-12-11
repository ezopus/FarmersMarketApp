using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedImageUrlToUser : Migration
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
                values: new object[] { "95be9122-ddd4-49ed-afb4-cbe6904102ef", "", "AQAAAAIAAYagAAAAEJJ2j6Xr1YvDsWmYwVi/++YQTuqVZxDN2hagluqOAZVDzkY6dtSOxwfTmHs3Ow6gqw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "ImageUrl", "PasswordHash" },
                values: new object[] { "ad9a7399-20fa-4866-9053-ea2a0cde0c36", "", "AQAAAAIAAYagAAAAEAgqhbcSVglRWx70sLYzVLmtOv0/7ln/kTh2EsA7n2+XqM7sgOHuaiddlTa7H72jvw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "ImageUrl", "PasswordHash" },
                values: new object[] { "d0b5a57e-1181-4c5d-a386-5d5801a1edcb", "", "AQAAAAIAAYagAAAAEKP0tKIkMHGNy3uRsk5j0u1w/s+uCuYKseDaTPzGayb/s5c2x9+fdlTFQytCJESEeA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "ImageUrl", "PasswordHash" },
                values: new object[] { "2a8d9b6c-065d-432a-869e-d19978da5af6", "", "AQAAAAIAAYagAAAAEJd0xEPVo0kxlRhBllEaVeQf0o22LQRJcgpVc1v3R90bu0ERtxKbxVWPy34+l3gArw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "ImageUrl", "PasswordHash" },
                values: new object[] { "0a2908c0-7c1c-4cf8-a2d7-a7b1606ae442", "", "AQAAAAIAAYagAAAAEBpns5+mFlEVqZph4vwOaj2pTdrEQrlsC4LdTALjCcC3FRSfowl6s/jGUmvSxLoa3Q==" });
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
