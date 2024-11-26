using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsApprovedAndDateApprovedToFarmerModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateApproved",
                table: "Farmers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Date and time when administrator has approved farmer.");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Farmers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Boolean flag to show if farmer has passed approval by administrator.");

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

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: new Guid("1474d237-fe36-4586-ac67-b3ddcf03baac"),
                columns: new[] { "DateApproved", "IsApproved" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true });

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: new Guid("65c75a94-f3be-4a7a-913e-d6c868876265"),
                columns: new[] { "DateApproved", "IsApproved" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true });

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"),
                columns: new[] { "DateApproved", "IsApproved" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateApproved",
                table: "Farmers");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Farmers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9842be50-3612-490b-88ec-9eb8492292ef", "AQAAAAIAAYagAAAAEE65PInX14d5QrsI8DRu61KfwFTR+N8NkJejh/u7GNTOi+Xupzt2sJZ+T9Lu5lBp4g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c2b0b8a2-bb8b-4e67-8840-ec4bf6e859b0", "AQAAAAIAAYagAAAAEOsysVcvsRusC7/oixeoJ6gAYsRaLS3jGSnm/6mOgCmcfQKifiE244warWTpaQZapg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "05944fec-b8c6-4f2b-a784-83a1785c9ab5", "AQAAAAIAAYagAAAAEJ9h3lEPOVPkWbOuJUi8GIbUTHUICKWcn6OIC6qFGWKdlRepwcO6mj1whW36RnWdsA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "322b3bcb-9362-4b5b-82ae-fc52a35f0855", "AQAAAAIAAYagAAAAEIYMHAup4KAdxQgou6B/VsiHj/ybUqDy02/VOquK4YcRPo/drnXJGSBYNOzDNoFSnQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ec1a1314-8560-4553-af9f-271d65ebea35", "AQAAAAIAAYagAAAAEFJfQlMqLqh0bI4IhUNQtePpCUDyASm1xS2D6Ogb/I+sPIVi+Jzor1ZbaXsI1vYLeA==" });
        }
    }
}
