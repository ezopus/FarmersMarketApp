using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedOrderStatusToOrderEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderStatus",
                table: "Orders",
                type: "int",
                nullable: true,
                comment: "Status of the current order.");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1b0d95f8-4248-45d8-acd9-5a4ec5b0bed2", "AQAAAAIAAYagAAAAEHEWF7VBRWC1HjIMu3DRLQtF4y+PyQ1ETJz5SxDEg+pIyOyBC8QJncDCgX5v0Bep5w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4b13ef7f-32e7-41de-83a4-f2e471422663", "AQAAAAIAAYagAAAAEMrdisOZWIXetbCO4ppdHPyijGn/2RyIaMNeTFM7knaI9FR9A7TDvrmwy6YSx+0YYQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3765e651-f324-4009-942a-637574f5bc97", "AQAAAAIAAYagAAAAECWp6VPd3/00WGCZdNs09x5e4AB+ytQ26XyCFjJSYX8vwve9m/qh0/Ka3ahvxZ0fAw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "51d0367f-8cf4-443e-bdcf-a445ad2eb615", "AQAAAAIAAYagAAAAEKYMd3jeswKJpwHTYGUcUpbJRyIaWYXMuX0Mmpbq0FMZg8Fpp/0Row91O6TjpjTHfA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4d9089b6-f094-4b5d-bd86-bf98ede82099", "AQAAAAIAAYagAAAAEO95s5ld+JKSkOMDKrFcUlm576anIEguMZsTzqsS+SMJMuMU5Tenl1w2ffYjY0e0FA==" });
        }
    }
}
