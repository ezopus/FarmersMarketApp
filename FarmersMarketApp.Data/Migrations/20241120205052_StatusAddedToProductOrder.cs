using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class StatusAddedToProductOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ProductsOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Status for each individual product in order");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "59bdfa45-a3a6-40a5-b691-fdaadb7ab5b6", "AQAAAAIAAYagAAAAEK7XBAC9Ie5ozInBZ2IdbjqVSWo5m4xZSs9OxQOsfCqcBZgnTynah1bG+BEQntAqYg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c9ebe965-cae3-4d94-8170-00e7331166b0", "AQAAAAIAAYagAAAAEMeIxP6v5AFl/NepOjLvge2VtciAbP5pAKkczn+g65aN9+jkyuT/YpP6L7VAB9HO2Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "95ade39a-77f3-47c9-9bd8-35f2859bfa72", "AQAAAAIAAYagAAAAEH+zaViSqRTAFCfFiWF+drTJT5jcdAlhbWt+Cv1zq2sbnMigPq/BwglN+8+ImkzRIA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fdfe79d6-aa89-4305-ae22-ce9994c94b25", "AQAAAAIAAYagAAAAEPnIDoA5QoncXXOlrXEP0111BVHnCWMTM/1AJeZ61qRGNoks83DUGsqOPRLsXvmEvQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4cfb4ebc-0c07-498c-8a1b-08cd15e50b13", "AQAAAAIAAYagAAAAEJCodQa6IUDuv6x3191rlqRWdSOzgSkR6rODEiueft7SrtyMZtmSC0lnFyGjWljnSA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ProductsOrders");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "25b84022-018c-496f-ac18-c8a812190031", "AQAAAAIAAYagAAAAEFjOXXiJM5hkjhiCyO52awymYcwQ3NeQhj19aseYwn7vawEOTt2o1rBGH4iXWE18eg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7c6d70e4-e6db-47ef-b224-dff36f527a2c", "AQAAAAIAAYagAAAAEEF5IpUDeJklHEwZcqDcJBXwt9Dlnq0ydpOh6lA8uay+zKkD0ts1UnFhLsbhd+6d6w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e11d2d7e-b182-49f6-8dcb-4035ef328ca5", "AQAAAAIAAYagAAAAEOGVQlguDbrklr8LRg+k1vLm/9I+8JIqk0XPewn8rQC7RMlR3SEhiOienjpxxaoTTQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "27f48843-9231-45ff-a923-1a20a3eebc56", "AQAAAAIAAYagAAAAEBe1qbms7llL1SsMsR/Qk02C0mx/ctXrraiNBYCAEq4aTxBQ/DdbqhImldbvOTqsaQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e89a27a0-abc9-4b81-8719-2f0b29fe760d", "AQAAAAIAAYagAAAAEFbQDAaG/NOSYJwnjDOl+9gDKjwfG9dOPlrerX0qwYEBnVC2wEMrDrKTOV3Eg64zrg==" });
        }
    }
}
