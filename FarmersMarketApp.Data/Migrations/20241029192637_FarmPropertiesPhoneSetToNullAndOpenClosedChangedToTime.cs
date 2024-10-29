using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FarmPropertiesPhoneSetToNullAndOpenClosedChangedToTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Farms",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Phone number of farm visible to general public.",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Phone number of farm visible to general public.");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "OpenHours",
                table: "Farms",
                type: "time",
                nullable: true,
                comment: "Opening hours of farm operations.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Opening hours of farm operations.");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "CloseHours",
                table: "Farms",
                type: "time",
                nullable: true,
                comment: "Closing hours of farm operations.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Closing hours of farm operations.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Farms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Phone number of farm visible to general public.",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Phone number of farm visible to general public.");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpenHours",
                table: "Farms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Opening hours of farm operations.",
                oldClrType: typeof(TimeOnly),
                oldType: "time",
                oldNullable: true,
                oldComment: "Opening hours of farm operations.");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CloseHours",
                table: "Farms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Closing hours of farm operations.",
                oldClrType: typeof(TimeOnly),
                oldType: "time",
                oldNullable: true,
                oldComment: "Closing hours of farm operations.");
        }
    }
}
