using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedPaymentIdNullableToOrderEntityAndRemovedOrderIdFromPaymentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Payments_Id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Payments");

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true,
                comment: "Unique payment Id gets inserted when order is processed successfully or remains empty if not.");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "da3a6d33-76a8-45bf-95a5-6206c1ee4f7b", "AQAAAAIAAYagAAAAEAQLmTmqr/XsYADdMw6UYDA1qpVZFOss4gQWMUz1CB91JbXURZT7KbLln8TFS2hrKA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0123cfa2-aff5-4fae-9b9a-f427bbd30035", "AQAAAAIAAYagAAAAEA13niqLyyxfB/PWlPjkdG6qtMLc/mIYbKOQjxkDr2Vjt4nUCyX5uqV0eL32R+Skyw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "611738fc-6e37-4163-b2cf-9ed5ff20a1ff", "AQAAAAIAAYagAAAAED1r4J+Lf1fyHmwUDNP5NveyppsSGoSp9JUU7yvYf488fVG1NObD5XsV9YB3s3P8CA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "56caa93c-7544-42fe-ae4f-e6eeaf5a8cb3", "AQAAAAIAAYagAAAAEFJPorSD+G1cIatsJKIaH80/stcoZDjB2z6Sogv5az+AOYy1HHakrKGZhu4boacvIw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0a621b63-3614-4696-a8a4-d59d71135646", "AQAAAAIAAYagAAAAEERpZ3SE/9dyMdcLAHHZKlkzXz2AYmgpnbt5OTl7HpIN4vC32fB+xhHrlz74GhEWYg==" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentId",
                table: "Orders",
                column: "PaymentId",
                unique: true,
                filter: "[PaymentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Payments_PaymentId",
                table: "Orders",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Payments_PaymentId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PaymentId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Orders");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Payments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Unique order identifier.");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4f05178b-8348-428e-a48f-fa4aea90f75e", "AQAAAAIAAYagAAAAEDqLVyFFzcAxDPynLPtHtCTJiwiev5KrtQ9/ZSPRRG8f6hhp6Rc6cZDkofSM4+NllQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "01ca4878-6888-43ef-a1d2-cc223228839d", "AQAAAAIAAYagAAAAELPFsuAPVkIpPV/+BcezDIWW/K0tQroHSuJ7pInP3nApMgh3tXF/b4xslPrJBjl5BQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "668385dc-f3ac-44a0-ae2f-fe86ea1547ab", "AQAAAAIAAYagAAAAEFRcdlw9yyqZ4eTf/CF1n6XYQvwnSxcz2QfydaKsB1hXO1Od/Us54/Vhlf2A6vZNLA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "815a9fd8-d6c9-4518-b840-025f49df6f82", "AQAAAAIAAYagAAAAEEiGKdJNZPC1OeQmeOt+MqrlJohyqun5cp28zfBcYaSp7Bl57ZJXzIcUHUjRUyMQQw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "331d378f-05d3-4ec0-b525-4106cdb29d55", "AQAAAAIAAYagAAAAEJeIzPk1VymJFdfVfNe03CNUtyYd2BraklVZA6h34spb+R4xSGGyBNADHOx3LqQSsg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Payments_Id",
                table: "Orders",
                column: "Id",
                principalTable: "Payments",
                principalColumn: "Id");
        }
    }
}
