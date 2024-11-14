using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedToFarmer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsSuccessful",
                table: "Payments",
                type: "bit",
                nullable: false,
                comment: "Flag if payment is successful.",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Flag is payment is successful.");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Farmers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Boolean flag if farmer decides to deactivate his account.");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "64e64acc-7995-4ff5-8115-2a840e103c23", "AQAAAAIAAYagAAAAEMEnL9rmlaB9fW2oE2CyNn4E39TN85mIFLEyZQR8Tlpx6Gqtb4xDCqFiiPP7Csaw1Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a19734ee-f5f1-44d3-9f72-721587faa208", "AQAAAAIAAYagAAAAEJiazVnXiORnFLRYygKVW+dNFjQ+Us8t/c4whcZ/ro6awesGhTqCMeOPrNcsB644jg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "efe391b9-466b-460d-8afe-41a36db92786", "AQAAAAIAAYagAAAAECqKDz6b/JarqkE49ojKUi3FIO/MZ7EEcp6AFQdo7kPnsbGvPQ8PMyVQ+tSZIMmSdg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8f31905f-b325-45ba-948f-1b071fd18549", "AQAAAAIAAYagAAAAEPcy/zjrV+Y9RoN/O1vbK7/LnAcERaqBpjqKnoB8ioRkNHpxKJ1CTQ8FCE3RKIeSMQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b4d15505-1606-4634-80bb-12bb801bbade", "AQAAAAIAAYagAAAAEH0KFE9REtdzh8fTCXXxBKIQLYFwKN8IYttu73YZunq1JmsaR5BX2FHHnjyGqLlPPQ==" });

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: new Guid("1474d237-fe36-4586-ac67-b3ddcf03baac"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: new Guid("65c75a94-f3be-4a7a-913e-d6c868876265"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"),
                column: "IsDeleted",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Farmers");

            migrationBuilder.AlterColumn<bool>(
                name: "IsSuccessful",
                table: "Payments",
                type: "bit",
                nullable: false,
                comment: "Flag is payment is successful.",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Flag if payment is successful.");

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
    }
}
