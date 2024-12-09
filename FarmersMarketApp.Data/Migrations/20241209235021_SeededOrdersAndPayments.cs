using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeededOrdersAndPayments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "acc7b5b4-737d-41ac-ae88-4c1b266e356b", "AQAAAAIAAYagAAAAEJP4f9TJdh1WUCjgGng+p/4G2PXDQIFcR7sFoHtxQZZai4TwsIwo7Q5WjTo9pWHhtw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "02911b07-6e82-4512-b642-e16e0519ea70", "AQAAAAIAAYagAAAAEA3dNCX2osW89sfzeMBFGX5zZV4rZPbNSvveOMWpQjlqRAfyV6eMHakDu0d8LMY+Pw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "58a584ff-e858-4852-bafa-faca98bf87aa", "AQAAAAIAAYagAAAAELQXOP+3v7PRUt3iH/a0geUc45ko/5EkTJxNWvXRm0EE51R4aFV8bRtXleis9al5sA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6f0b86a1-bf9a-4804-88e6-3a927fdbcd5b", "AQAAAAIAAYagAAAAEBVE5hI3//jDX5VRcSXLSEw73BnAZkm+PR2IHRn+9XCq/GUFrA9a9O4895N3T405gg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e696e59f-4794-4abe-b6da-16b98f076abc", "AQAAAAIAAYagAAAAEBG9U9xU1HOp+dXg9KsngM5ALf4LnJOQUubICDogCsXgdoYn9GQWJLDQxhFJ1+OVQA==" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreateDate", "CustomerId", "DeliveryAddress", "DeliveryCity", "DeliveryDate", "DeliveryFirstName", "DeliveryLastName", "DeliveryPhoneNumber", "PaymentId", "Status" },
                values: new object[,]
                {
                    { new Guid("3c879b4e-a194-4f8f-ab9c-8a09820d949b"), new DateTime(2024, 12, 10, 0, 35, 1, 0, DateTimeKind.Unspecified), new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"), "Ocean Way 1", "Scranton", null, "Jim", "Halpert", "+359888123456", new Guid("a8bbf635-eb78-41c8-8f28-fa6123e4d0a9"), 2 },
                    { new Guid("4656a62c-231a-4539-a8c4-413ad4f9e7cd"), null, new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"), null, null, null, null, null, null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "CustomerId", "IsSuccessful", "OrderId", "PaymentAmount", "PaymentDate", "PaymentType" },
                values: new object[] { new Guid("a8bbf635-eb78-41c8-8f28-fa6123e4d0a9"), new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"), true, new Guid("3c879b4e-a194-4f8f-ab9c-8a09820d949b"), 16.91m, new DateTime(2024, 12, 10, 0, 35, 1, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "ProductsOrders",
                columns: new[] { "OrderId", "ProductId", "FarmId", "IsDeleted", "ProductDiscountAtTimeOfOrder", "ProductPriceAtTimeOfOrder", "ProductQuantity", "Status" },
                values: new object[,]
                {
                    { new Guid("3c879b4e-a194-4f8f-ab9c-8a09820d949b"), new Guid("8169cb41-3198-4cf4-b734-16849661983e"), new Guid("d8fd1d22-ad66-4850-8a23-54d33e488964"), null, 0.0m, 6.66m, 1, 3 },
                    { new Guid("3c879b4e-a194-4f8f-ab9c-8a09820d949b"), new Guid("ccf1c98e-5cf4-4bfe-82c7-2a1dfb748e12"), new Guid("45c92bba-7ac0-42ae-995e-d6fc10e05067"), null, 0.0m, 4.99m, 1, 2 },
                    { new Guid("3c879b4e-a194-4f8f-ab9c-8a09820d949b"), new Guid("e2ca22b4-f728-4c4f-888b-17463d93d542"), new Guid("d8fd1d22-ad66-4850-8a23-54d33e488964"), null, 15.0m, 2.12m, 2, 3 },
                    { new Guid("3c879b4e-a194-4f8f-ab9c-8a09820d949b"), new Guid("fffb5e9d-4c1e-4e0d-8997-1a7e537a5b89"), new Guid("63ad63d2-5884-4c3d-93f1-1aaf75c0a563"), null, 10.0m, 3.14m, 1, 2 },
                    { new Guid("4656a62c-231a-4539-a8c4-413ad4f9e7cd"), new Guid("c62b13b9-6bc2-403f-9e0d-2de6d8f84f88"), new Guid("06a9fdbb-dfd9-47d5-9a4a-7117ed1f2332"), null, 0.0m, 2.49m, 1, 1 },
                    { new Guid("4656a62c-231a-4539-a8c4-413ad4f9e7cd"), new Guid("ccf1c98e-5cf4-4bfe-82c7-2a1dfb748e12"), new Guid("45c92bba-7ac0-42ae-995e-d6fc10e05067"), null, 0.0m, 4.99m, 1, 1 },
                    { new Guid("4656a62c-231a-4539-a8c4-413ad4f9e7cd"), new Guid("de3442a5-6a4d-4938-babe-2f3a7a5e9b34"), new Guid("581569fd-5062-4435-899b-8bfe31d2f4e8"), null, 5.0m, 14.24m, 1, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("a8bbf635-eb78-41c8-8f28-fa6123e4d0a9"));

            migrationBuilder.DeleteData(
                table: "ProductsOrders",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { new Guid("3c879b4e-a194-4f8f-ab9c-8a09820d949b"), new Guid("8169cb41-3198-4cf4-b734-16849661983e") });

            migrationBuilder.DeleteData(
                table: "ProductsOrders",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { new Guid("3c879b4e-a194-4f8f-ab9c-8a09820d949b"), new Guid("ccf1c98e-5cf4-4bfe-82c7-2a1dfb748e12") });

            migrationBuilder.DeleteData(
                table: "ProductsOrders",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { new Guid("3c879b4e-a194-4f8f-ab9c-8a09820d949b"), new Guid("e2ca22b4-f728-4c4f-888b-17463d93d542") });

            migrationBuilder.DeleteData(
                table: "ProductsOrders",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { new Guid("3c879b4e-a194-4f8f-ab9c-8a09820d949b"), new Guid("fffb5e9d-4c1e-4e0d-8997-1a7e537a5b89") });

            migrationBuilder.DeleteData(
                table: "ProductsOrders",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { new Guid("4656a62c-231a-4539-a8c4-413ad4f9e7cd"), new Guid("c62b13b9-6bc2-403f-9e0d-2de6d8f84f88") });

            migrationBuilder.DeleteData(
                table: "ProductsOrders",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { new Guid("4656a62c-231a-4539-a8c4-413ad4f9e7cd"), new Guid("ccf1c98e-5cf4-4bfe-82c7-2a1dfb748e12") });

            migrationBuilder.DeleteData(
                table: "ProductsOrders",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { new Guid("4656a62c-231a-4539-a8c4-413ad4f9e7cd"), new Guid("de3442a5-6a4d-4938-babe-2f3a7a5e9b34") });

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("3c879b4e-a194-4f8f-ab9c-8a09820d949b"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("4656a62c-231a-4539-a8c4-413ad4f9e7cd"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4fc438b6-5967-4bb2-9191-4ea7d2902ae9", "AQAAAAIAAYagAAAAEPL+RkZc4w/NJTdfHDiz2192F+tftqsHdZgNwpahc/vQFXru483aeNp+2qfpBy+aqQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "63e4b22c-eb4b-48a5-be7a-6e2480790ec6", "AQAAAAIAAYagAAAAEKCGzkio2DZiWZJm4oaVYdl6WQ6GmCT0nJbXhC4UiSZAX4jjVIo+HHaWowMI+5/l8w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d677d5aa-5f50-49dc-8187-9729450559c7", "AQAAAAIAAYagAAAAEMVA3DhX8Mv73+2X60X2xEDyxdIOl5YZIJPKHZnZNofB10tEBK0zWd9QqTqMPnu18Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "22b83305-cf06-400b-a780-b83973e8c858", "AQAAAAIAAYagAAAAEHcaaHv8GiUnssAs4pvCy/D71p+t52lzCLv/Gu97O8BUnmDYZ0SKEdl/rZucfOFhww==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3e518194-34cc-420c-aa62-b74f57258d03", "AQAAAAIAAYagAAAAEDT1VzWRLjtxqvviSk+696dTOtIeuwScdHi+LokG+mGtpZy3gXvDHaxmEdsdd6ReHw==" });
        }
    }
}
