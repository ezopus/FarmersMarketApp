using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedSizeAndShippingWeightFromProductRemovedAcceptsDeliveriesFromFarmer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShippingWeight",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AcceptsDeliveries",
                table: "Farmers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c9212210-e923-4c2c-aa19-f462b1b4ab6a", "AQAAAAIAAYagAAAAEPMvHjaf1IUz+aU41k9FUpPi4UxFN0bN/EEYdtIzw3u1RnU8TIVisVWAvQdopTrT8Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6f1a89a7-5fd1-4e24-9658-7d6f1bc1936c", "AQAAAAIAAYagAAAAECI6+rkOn3TAnnZVge4vRIo8cJkJcKVNQ92/8I6rqDBUhWBhHyzZoH1uwvfo4ATKRw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e6ad6dc3-2207-4475-a6ef-a01d552c53fa", "AQAAAAIAAYagAAAAELdPwneCxz83lXBgPNv8a3tX5FgnxCa/B1e5D1czB6M2R3OPWHf3LOWz39OrZAuekQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9f9279d3-2385-4e94-aa2e-7eb4c25838db", "AQAAAAIAAYagAAAAEFwDwMLO+C1fy8FGjv0JBT/3jr29DCLtnzFYQ4m/ySY770KOgVjJNn/JFnEmfrS5Rg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b6e20221-a4b9-4a30-9c63-c5cf08aca328", "AQAAAAIAAYagAAAAEHqn4E7IYMsucM/mLbsE2G3ock4FLVm2Dv8afhD9uxKCNpclH6XRUOrqv+qc2wr4Ug==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0fef93a3-0cd6-4e02-9404-b34d5f0e672a"),
                column: "DateAdded",
                value: new DateTime(2024, 3, 2, 12, 11, 34, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11f7b5fc-f7f1-4782-b90b-b18b5e0fbb47"),
                column: "DateAdded",
                value: new DateTime(2024, 1, 1, 19, 41, 32, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3a679e4b-2c43-4eab-82e5-6c120c9d8e2b"),
                column: "DateAdded",
                value: new DateTime(2024, 11, 11, 11, 11, 11, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8ab9a582-e0f2-46d1-9e13-8d8b0b2ef731"),
                column: "DateAdded",
                value: new DateTime(2024, 12, 22, 21, 52, 4, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aa1c9a77-5bf8-4cf8-995f-8f3ebc653c97"),
                column: "DateAdded",
                value: new DateTime(2024, 4, 4, 4, 4, 4, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("acdbb2f1-8f25-4b3c-a67a-b4d6e0b0f332"),
                column: "DateAdded",
                value: new DateTime(2024, 11, 17, 16, 42, 24, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ad91b21a-547f-4d1b-9e3c-4e0d53f8d347"),
                column: "DateAdded",
                value: new DateTime(2024, 11, 30, 23, 12, 44, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b197ed82-64f7-4d5c-b2b4-8cf2b31bfb50"),
                column: "DateAdded",
                value: new DateTime(2024, 2, 12, 12, 32, 14, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b21d8f58-8f67-4cb8-b31f-5ebd2ff1b107"),
                column: "DateAdded",
                value: new DateTime(2024, 9, 10, 11, 12, 13, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b9cdd8a5-3039-4a7f-93a4-9b76c6e5e510"),
                column: "DateAdded",
                value: new DateTime(2024, 7, 7, 7, 7, 7, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bb0b2f76-f1d8-49a3-ae15-5d2cb36c4899"),
                column: "DateAdded",
                value: new DateTime(2024, 2, 2, 2, 2, 2, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("be88d6d4-1ae2-4a5a-9d6c-ef564c6e1c37"),
                column: "DateAdded",
                value: new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c62b13b9-6bc2-403f-9e0d-2de6d8f84f88"),
                column: "DateAdded",
                value: new DateTime(2024, 6, 6, 6, 6, 6, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c6b7e2c2-3f9a-4c27-b6ef-7f70e5bfcf92"),
                column: "DateAdded",
                value: new DateTime(2024, 9, 9, 9, 9, 9, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c89c1d90-a5d7-4416-9403-e5e1e3e0e217"),
                column: "DateAdded",
                value: new DateTime(2024, 6, 2, 3, 12, 44, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ccf1c98e-5cf4-4bfe-82c7-2a1dfb748e12"),
                column: "DateAdded",
                value: new DateTime(2024, 3, 3, 3, 3, 3, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d1f7e5a6-2a8d-4c5a-80c7-b8c0b58f2d91"),
                column: "DateAdded",
                value: new DateTime(2024, 8, 8, 8, 8, 8, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d2109b26-f315-48df-baf9-c1c45746e573"),
                column: "DateAdded",
                value: new DateTime(2024, 8, 8, 21, 21, 21, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("de3442a5-6a4d-4938-babe-2f3a7a5e9b34"),
                column: "DateAdded",
                value: new DateTime(2024, 5, 5, 5, 5, 5, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e2ca22b4-f728-4c4f-888b-17463d93d542"),
                column: "DateAdded",
                value: new DateTime(2024, 10, 10, 10, 10, 10, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fa8ec7af-4cf4-4a28-8c37-5f2d3a1ab5e1"),
                column: "DateAdded",
                value: new DateTime(2024, 12, 10, 16, 31, 54, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fffb5e9d-4c1e-4e0d-8997-1a7e537a5b89"),
                column: "DateAdded",
                value: new DateTime(2024, 10, 11, 23, 12, 34, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ShippingWeight",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                comment: "Weight of product with container");

            migrationBuilder.AddColumn<double>(
                name: "Size",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                comment: "The size of one individual product in one sold unit.");

            migrationBuilder.AddColumn<bool>(
                name: "AcceptsDeliveries",
                table: "Farmers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Flag to show if farmer is currently accepting deliveries.");

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

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: new Guid("1474d237-fe36-4586-ac67-b3ddcf03baac"),
                column: "AcceptsDeliveries",
                value: true);

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: new Guid("65c75a94-f3be-4a7a-913e-d6c868876265"),
                column: "AcceptsDeliveries",
                value: true);

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"),
                column: "AcceptsDeliveries",
                value: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0fef93a3-0cd6-4e02-9404-b34d5f0e672a"),
                columns: new[] { "DateAdded", "ShippingWeight", "Size" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.5999999999999996, 1.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11f7b5fc-f7f1-4782-b90b-b18b5e0fbb47"),
                columns: new[] { "DateAdded", "ShippingWeight", "Size" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.3000000000000007, 1.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3a679e4b-2c43-4eab-82e5-6c120c9d8e2b"),
                columns: new[] { "DateAdded", "ShippingWeight", "Size" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.0, 12.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8ab9a582-e0f2-46d1-9e13-8d8b0b2ef731"),
                columns: new[] { "DateAdded", "ShippingWeight", "Size" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.5, 200.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aa1c9a77-5bf8-4cf8-995f-8f3ebc653c97"),
                columns: new[] { "DateAdded", "ShippingWeight", "Size" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.2000000000000002, 1.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("acdbb2f1-8f25-4b3c-a67a-b4d6e0b0f332"),
                columns: new[] { "DateAdded", "ShippingWeight", "Size" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.3, 1.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ad91b21a-547f-4d1b-9e3c-4e0d53f8d347"),
                columns: new[] { "DateAdded", "ShippingWeight", "Size" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13.0, 0.5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b197ed82-64f7-4d5c-b2b4-8cf2b31bfb50"),
                columns: new[] { "DateAdded", "ShippingWeight", "Size" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.5, 2.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b21d8f58-8f67-4cb8-b31f-5ebd2ff1b107"),
                columns: new[] { "DateAdded", "ShippingWeight", "Size" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.2000000000000002, 1.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b9cdd8a5-3039-4a7f-93a4-9b76c6e5e510"),
                columns: new[] { "DateAdded", "ShippingWeight", "Size" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.4, 0.5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bb0b2f76-f1d8-49a3-ae15-5d2cb36c4899"),
                columns: new[] { "DateAdded", "ShippingWeight", "Size" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.7999999999999998, 0.25 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("be88d6d4-1ae2-4a5a-9d6c-ef564c6e1c37"),
                columns: new[] { "DateAdded", "ShippingWeight", "Size" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16.5, 0.75 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c62b13b9-6bc2-403f-9e0d-2de6d8f84f88"),
                columns: new[] { "DateAdded", "ShippingWeight", "Size" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12.4, 1.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c6b7e2c2-3f9a-4c27-b6ef-7f70e5bfcf92"),
                columns: new[] { "DateAdded", "ShippingWeight", "Size" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.5, 1.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c89c1d90-a5d7-4416-9403-e5e1e3e0e217"),
                columns: new[] { "DateAdded", "ShippingWeight", "Size" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.199999999999999, 500.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ccf1c98e-5cf4-4bfe-82c7-2a1dfb748e12"),
                columns: new[] { "DateAdded", "ShippingWeight", "Size" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.2000000000000002, 0.5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d1f7e5a6-2a8d-4c5a-80c7-b8c0b58f2d91"),
                columns: new[] { "DateAdded", "ShippingWeight", "Size" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.300000000000001, 1.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d2109b26-f315-48df-baf9-c1c45746e573"),
                columns: new[] { "DateAdded", "ShippingWeight", "Size" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.7999999999999998, 0.5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("de3442a5-6a4d-4938-babe-2f3a7a5e9b34"),
                columns: new[] { "DateAdded", "ShippingWeight", "Size" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.3000000000000007, 1.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e2ca22b4-f728-4c4f-888b-17463d93d542"),
                columns: new[] { "DateAdded", "ShippingWeight", "Size" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.199999999999999, 1.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fa8ec7af-4cf4-4a28-8c37-5f2d3a1ab5e1"),
                columns: new[] { "DateAdded", "ShippingWeight", "Size" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9.3000000000000007, 0.5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fffb5e9d-4c1e-4e0d-8997-1a7e537a5b89"),
                columns: new[] { "DateAdded", "ShippingWeight", "Size" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.5, 1.0 });
        }
    }
}
