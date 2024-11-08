using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IsDeletedFlagsAddedToProductAndFarm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ShippingWeight",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                comment: "Weight of product with container",
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true,
                oldComment: "Weight of product with container");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Boolean flag for product soft deletion");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Farms",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Boolean flag for farm soft deletion");

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

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("012cf2fc-b34e-425f-87a0-cc5989ea5c06"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("06a9fdbb-dfd9-47d5-9a4a-7117ed1f2332"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("272befbb-54fd-41d0-bfca-d72305535321"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("45c92bba-7ac0-42ae-995e-d6fc10e05067"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("581569fd-5062-4435-899b-8bfe31d2f4e8"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("63ad63d2-5884-4c3d-93f1-1aaf75c0a563"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("6ee2702d-fab7-42f4-bf10-6becc7b9dbd3"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("77b7f04e-c775-4735-a017-60c7d5b4ede9"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("7da444a3-fc8c-43e6-a223-378e5a51be4e"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("9a020bca-2f9f-4b61-af21-1adae08dd8e9"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("c437b349-7f30-44de-865a-31f24fc7c584"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("ce2e44ca-d118-4676-9623-624e7f56980e"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("d8fd1d22-ad66-4850-8a23-54d33e488964"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("dcbae87c-93a9-4699-b3e4-2e10776839dd"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("e609dc73-6845-4e72-80a4-1ad215a094d1"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0fef93a3-0cd6-4e02-9404-b34d5f0e672a"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11f7b5fc-f7f1-4782-b90b-b18b5e0fbb47"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3a679e4b-2c43-4eab-82e5-6c120c9d8e2b"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8ab9a582-e0f2-46d1-9e13-8d8b0b2ef731"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aa1c9a77-5bf8-4cf8-995f-8f3ebc653c97"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("acdbb2f1-8f25-4b3c-a67a-b4d6e0b0f332"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ad91b21a-547f-4d1b-9e3c-4e0d53f8d347"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b197ed82-64f7-4d5c-b2b4-8cf2b31bfb50"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b21d8f58-8f67-4cb8-b31f-5ebd2ff1b107"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b9cdd8a5-3039-4a7f-93a4-9b76c6e5e510"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bb0b2f76-f1d8-49a3-ae15-5d2cb36c4899"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("be88d6d4-1ae2-4a5a-9d6c-ef564c6e1c37"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c62b13b9-6bc2-403f-9e0d-2de6d8f84f88"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c6b7e2c2-3f9a-4c27-b6ef-7f70e5bfcf92"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c89c1d90-a5d7-4416-9403-e5e1e3e0e217"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ccf1c98e-5cf4-4bfe-82c7-2a1dfb748e12"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d1f7e5a6-2a8d-4c5a-80c7-b8c0b58f2d91"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d2109b26-f315-48df-baf9-c1c45746e573"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("de3442a5-6a4d-4938-babe-2f3a7a5e9b34"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e2ca22b4-f728-4c4f-888b-17463d93d542"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fa8ec7af-4cf4-4a28-8c37-5f2d3a1ab5e1"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fffb5e9d-4c1e-4e0d-8997-1a7e537a5b89"),
                column: "IsDeleted",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Farms");

            migrationBuilder.AlterColumn<double>(
                name: "ShippingWeight",
                table: "Products",
                type: "float",
                nullable: true,
                comment: "Weight of product with container",
                oldClrType: typeof(double),
                oldType: "float",
                oldComment: "Weight of product with container");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3b3db4f9-6a40-4a69-ae27-dc4a6556429b", "AQAAAAIAAYagAAAAEKSt+M5DMbsPZ1ui/wiCLVPzXLdouHm6TnvG0MPAdg7nf33WBCRupu6OXjQLmlpBWw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "12abdfe8-e44f-4970-92ff-96ba7a2afbb8", "AQAAAAIAAYagAAAAEHnW6sGPLWK6zAjqrJ0J3wEKDPsTdi4Rv1bP0qPIlC5TXnAlq7YiYkBWbSNn+qLyRA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "65ffa81f-7bc5-4f25-aef8-2573cbd23a45", "AQAAAAIAAYagAAAAEH0Dgy5yT/wztp2OHERvC1VVryHClYDgNyBIAo4BkWHpXbdWHh8jHbTdeSlRB2ZrWQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "99a33050-4c2f-4775-b458-2c1878e37804", "AQAAAAIAAYagAAAAEKV3uZ1Z6UTDh+Ds7sPdOMNFT/HdLsj3JZgJBKp+a9p0aedPLY+MFU+G5Ty2hjy8oQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "af331f4a-bac4-4bd1-9195-4681547ac4c7", "AQAAAAIAAYagAAAAEHqttEXNDkimYeSxGwN/5NUXLqr7wT3WzgXZhXwltTapYA8xanw2MAQcXlQaRH0Aug==" });
        }
    }
}
