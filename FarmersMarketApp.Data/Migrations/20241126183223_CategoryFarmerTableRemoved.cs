using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CategoryFarmerTableRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriesFarmers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "071b83b0-dc58-40a4-9736-b2fb0092c027", "AQAAAAIAAYagAAAAEKkss7yB2WxrA87FkiebUOZ1Yri0kX34CqeYpcrzTpqSKsavZU4/HbKeglIFeEgFCw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1afc2ade-5909-4216-8d7c-edf28956cb9a", "AQAAAAIAAYagAAAAEKwCg0KxwLdRPAa3Z82KHTQ1C8k3LuoqgEAWazcGLwUxKPni4npkGtJyPfkHM3I/3Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a72dccec-f589-4aa3-9296-7a89a3b1c62c", "AQAAAAIAAYagAAAAEFReNAa7uocpxwJ5SSkIk3Ok3jyHNl1i/QYlN9A+Od1GZa4Ocdp08bS9AnRpBY3dOQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "70dbf486-9c63-4013-9917-ac2bc2b2fef9", "AQAAAAIAAYagAAAAEFX5LZFtmg6c1upH0LtEip2vmp3A00eLj5rg73MkIBGveyo12UILD2B/wwJO9OT/mg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1f5b37e2-e96e-47ad-808c-d75e2cf7de3e", "AQAAAAIAAYagAAAAEKDPcBSFrXQXNKeoo0omcrc+mgvNtHp8Ixb8pjMhJf0/ANRA8h6YQKxFVWEIF1pvZg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriesFarmers",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Category identifier."),
                    FarmerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Farmer identifier.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesFarmers", x => new { x.CategoryId, x.FarmerId });
                    table.ForeignKey(
                        name: "FK_CategoriesFarmers_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CategoriesFarmers_Farmers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmers",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d24357d4-e8c3-4c3e-8a89-0c687ae99ff2", "AQAAAAIAAYagAAAAEKqzeEv7XaLfyWzuwOi3OxAJLX6a8hc/Au6bpVQZRVYPBI3hs1wA5ktwwPqSxjFb3A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5f9660c1-6183-4872-a6e0-971f50ad5e1c", "AQAAAAIAAYagAAAAEPKstEdpX1Z3tnpLGVdygN6YQwMcXQdLiRcbfDQxs96W3nWZ9SEY98jmS4uJF+5e/g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6e84235b-4aff-4c9c-9e62-2e6fc9b28784", "AQAAAAIAAYagAAAAENSof42Ga0uyucWLIANvzigojlczFXTJRaAXE3C0VuXWE8oWQQP+q1ZoTxDu3bdgpA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6e39da44-63a4-4367-a5da-317f0acd60b7", "AQAAAAIAAYagAAAAEF/Kh4k08tSSJrfo62TEXuTvyvdU/yrvc8ELzkiy3B9YX29N6Gt2FP/MYNkEtbFNyQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "37429f19-9e3f-4e96-9ee0-ce42ae3f8e0a", "AQAAAAIAAYagAAAAEI6uS3P5Mv4vru3TpBO+bZoCRwnH9L+mF5QWYlc5mLakMB7AsM35UpnilaJMPL7tnw==" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesFarmers_FarmerId",
                table: "CategoriesFarmers",
                column: "FarmerId");
        }
    }
}
