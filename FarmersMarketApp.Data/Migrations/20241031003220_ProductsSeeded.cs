using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductsSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "53d84107-811c-43bf-a9c3-18cffc7d169b", "AQAAAAIAAYagAAAAEADRvz6O2ond3StttwLCf2cKTTnEho+jTUoz5EfHqEgNmrdIxf1JPVk/q+bOedmX0A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "adf80459-6f33-4bc1-9843-73b67e8382de", "AQAAAAIAAYagAAAAEHxZLQrEhRyMJ9rGmH4geNW9WTujxnx8K2/1mmix58xd6aSvox1J3Q7TPPIcaPWmnA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c3cc6ee3-803d-4e4a-8575-739cd4dd0664", "AQAAAAIAAYagAAAAELoCREfRfn9vwb6R2aAeqXIhsXyTKgZnmBSnAI401WOTWzo7aOrkGkkbZxvqbDcPrg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "499a4b0e-a111-4253-8ae0-3bb8dfcdbc5f", "AQAAAAIAAYagAAAAEMs4MmJv2WRtTwle7umSfMc/j0zpg8g2nzu2cdatHAuSe8ujHuFTXVwrWiGAjSdn6g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2c1cf0f7-d838-41d7-b8e3-4381bdc65165", "AQAAAAIAAYagAAAAEH/wviRZa6iZkP3psTB6CMNyAHOTt7+15yoapXbTjwR3wScCDmy/cR/BuXV6UrzoLQ==" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "CategoryId", "Description", "DiscountPercentage", "ExpirationDate", "FarmId", "FarmerId", "HasDiscount", "ImageUrl", "Name", "NetWeight", "Origin", "Price", "ProductionDate", "Quantity", "Season", "ShippingWeight", "Size", "UnitType" },
                values: new object[,]
                {
                    { new Guid("0fef93a3-0cd6-4e02-9404-b34d5f0e672a"), "012345678914", 3, "Handmade sourdough bread, freshly baked.", 10.0m, new DateTime(2023, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7da444a3-fc8c-43e6-a223-378e5a51be4e"), new Guid("65c75a94-f3be-4a7a-913e-d6c868876265"), true, "https://example.com/images/sourdough_bread.jpg", "Sourdough Bread", 7.5, "Local", 4.99m, new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 1, 7.5999999999999996, 1.0, 1 },
                    { new Guid("11f7b5fc-f7f1-4782-b90b-b18b5e0fbb47"), "012345678910", 5, "Crisp, sweet apples, perfect for snacking.", 0.0m, new DateTime(2023, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("06a9fdbb-dfd9-47d5-9a4a-7117ed1f2332"), new Guid("1474d237-fe36-4586-ac67-b3ddcf03baac"), false, "https://example.com/images/apples.jpg", "Apples", 8.0, "Washington", 2.49m, new DateTime(2023, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.0, 3, 8.3000000000000007, 1.0, 3 },
                    { new Guid("3a679e4b-2c43-4eab-82e5-6c120c9d8e2b"), "012345678905", 9, "Organic, free-range chicken eggs.", 0.0m, new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7da444a3-fc8c-43e6-a223-378e5a51be4e"), new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"), false, "https://example.com/images/eggs.jpg", "Free-range Eggs", 1.8, "Farm Fresh", 2.99m, new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 3, 2.0, 12.0, 6 },
                    { new Guid("8ab9a582-e0f2-46d1-9e13-8d8b0b2ef731"), "012345678913", 2, "Rich and creamy organic butter, perfect for baking.", 0.0m, new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7da444a3-fc8c-43e6-a223-378e5a51be4e"), new Guid("65c75a94-f3be-4a7a-913e-d6c868876265"), false, "https://example.com/images/organic_butter.jpg", "Organic Butter", 2.3999999999999999, "Local", 3.79m, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 12.0, 2, 2.5, 200.0, 2 },
                    { new Guid("aa1c9a77-5bf8-4cf8-995f-8f3ebc653c97"), "012345678912", 6, "Organic spinach leaves, rich in iron.", 0.0m, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("012cf2fc-b34e-425f-87a0-cc5989ea5c06"), new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"), false, "https://example.com/images/spinach.jpg", "Spinach", 2.0, "Oregon", 1.99m, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 20.0, 4, 2.2000000000000002, 1.0, 5 },
                    { new Guid("acdbb2f1-8f25-4b3c-a67a-b4d6e0b0f332"), "012345678901", 5, "Freshly picked strawberries, sweet and juicy.", 0.0m, new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e609dc73-6845-4e72-80a4-1ad215a094d1"), new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"), false, "https://example.com/images/strawberries.jpg", "Strawberries", 1.2, "California", 4.99m, new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 12.0, 2, 1.3, 1.0, 5 },
                    { new Guid("ad91b21a-547f-4d1b-9e3c-4e0d53f8d347"), "012345678903", 7, "Pure honey collected from wildflowers.", 5.0m, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("dcbae87c-93a9-4699-b3e4-2e10776839dd"), new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"), true, "https://example.com/images/honey.jpg", "Honey", 12.0, "Wildflower Fields", 9.99m, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24.0, 3, 13.0, 0.5, 7 },
                    { new Guid("b197ed82-64f7-4d5c-b2b4-8cf2b31bfb50"), "012345678902", 3, "Premium quality wheat flour for baking.", 0.0m, new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9a020bca-2f9f-4b61-af21-1adae08dd8e9"), new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"), false, "https://example.com/images/wheat_flour.jpg", "Wheat Flour", 10.0, "USA", 1.99m, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.0, 3, 10.5, 2.0, 3 },
                    { new Guid("b21d8f58-8f67-4cb8-b31f-5ebd2ff1b107"), "012345678907", 10, "Freshly squeezed orange juice with no preservatives.", 0.0m, new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("77b7f04e-c775-4735-a017-60c7d5b4ede9"), new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"), false, "https://example.com/images/orange_juice.jpg", "Orange Juice", 6.0, "Florida", 3.99m, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.0, 4, 6.2000000000000002, 1.0, 7 },
                    { new Guid("b9cdd8a5-3039-4a7f-93a4-9b76c6e5e510"), "012345678909", 4, "Smooth almond butter with no added sugar.", 10.0m, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6ee2702d-fab7-42f4-bf10-6becc7b9dbd3"), new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"), true, "https://example.com/images/almond_butter.jpg", "Almond Butter", 10.0, "California", 12.99m, new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 20.0, 4, 10.4, 0.5, 7 },
                    { new Guid("bb0b2f76-f1d8-49a3-ae15-5d2cb36c4899"), "012345678914", 10, "Homemade orange marmalade, perfect for breakfast.", 7.5m, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("272befbb-54fd-41d0-bfca-d72305535321"), new Guid("1474d237-fe36-4586-ac67-b3ddcf03baac"), true, "https://example.com/images/orange_marmalade.jpg", "Orange Marmalade", 3.75, "Florida", 5.49m, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 4, 3.7999999999999998, 0.25, 7 },
                    { new Guid("be88d6d4-1ae2-4a5a-9d6c-ef564c6e1c37"), "012345678904", 4, "Cold-pressed extra virgin olive oil.", 0.0m, new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c437b349-7f30-44de-865a-31f24fc7c584"), new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"), false, "https://example.com/images/olive_oil.jpg", "Extra Virgin Olive Oil", 15.0, "Italy", 14.49m, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 20.0, 3, 16.5, 0.75, 7 },
                    { new Guid("c62b13b9-6bc2-403f-9e0d-2de6d8f84f88"), "012345678910", 5, "Crisp and sweet organic apples.", 0.0m, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("06a9fdbb-dfd9-47d5-9a4a-7117ed1f2332"), new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"), false, "https://example.com/images/organic_apples.jpg", "Organic Apples", 12.0, "Washington", 2.49m, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12.0, 3, 12.4, 1.0, 3 },
                    { new Guid("c6b7e2c2-3f9a-4c27-b6ef-7f70e5bfcf92"), "012345678908", 2, "Smooth and creamy almond milk, unsweetened.", 0.0m, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("45c92bba-7ac0-42ae-995e-d6fc10e05067"), new Guid("1474d237-fe36-4586-ac67-b3ddcf03baac"), false, "https://example.com/images/almond_milk.jpg", "Almond Milk", 10.0, "California", 4.29m, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.0, 1, 10.5, 1.0, 4 },
                    { new Guid("c89c1d90-a5d7-4416-9403-e5e1e3e0e217"), "012345678912", 2, "Thick and creamy Greek yogurt, plain.", 15.0m, new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("06a9fdbb-dfd9-47d5-9a4a-7117ed1f2332"), new Guid("65c75a94-f3be-4a7a-913e-d6c868876265"), true, "https://example.com/images/greek_yogurt.jpg", "Greek Yogurt", 10.0, "Greece", 5.49m, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20.0, 2, 10.199999999999999, 500.0, 2 },
                    { new Guid("ccf1c98e-5cf4-4bfe-82c7-2a1dfb748e12"), "012345678913", 2, "Creamy Greek yogurt made from fresh milk.", 0.0m, new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("45c92bba-7ac0-42ae-995e-d6fc10e05067"), new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"), false, "https://example.com/images/greek_yogurt.jpg", "Greek Yogurt", 5.0, "Greece", 4.99m, new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.0, 1, 5.2000000000000002, 0.5, 3 },
                    { new Guid("d1f7e5a6-2a8d-4c5a-80c7-b8c0b58f2d91"), "012345678908", 2, "Aged cheddar cheese with a sharp flavor.", 0.0m, new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce2e44ca-d118-4676-9623-624e7f56980e"), new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"), false, "https://example.com/images/cheddar_cheese.jpg", "Cheddar Cheese", 15.0, "Wisconsin", 7.99m, new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 4, 15.300000000000001, 1.0, 3 },
                    { new Guid("d2109b26-f315-48df-baf9-c1c45746e573"), "012345678909", 8, "Fresh Atlantic salmon fillet, ready to cook.", 5.0m, new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("45c92bba-7ac0-42ae-995e-d6fc10e05067"), new Guid("1474d237-fe36-4586-ac67-b3ddcf03baac"), true, "https://example.com/images/salmon_fillet.jpg", "Salmon Fillet", 7.5, "Atlantic Ocean", 12.99m, new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 3, 7.7999999999999998, 0.5, 3 },
                    { new Guid("de3442a5-6a4d-4938-babe-2f3a7a5e9b34"), "012345678911", 8, "Freshly caught salmon fillet, rich in omega-3.", 5.0m, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("581569fd-5062-4435-899b-8bfe31d2f4e8"), new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"), true, "https://example.com/images/salmon_fillet.jpg", "Salmon Fillet", 8.0, "Alaska", 15.99m, new DateTime(2023, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.0, 1, 8.3000000000000007, 1.0, 3 },
                    { new Guid("e2ca22b4-f728-4c4f-888b-17463d93d542"), "012345678906", 6, "Fresh, crunchy organic carrots.", 15.0m, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d8fd1d22-ad66-4850-8a23-54d33e488964"), new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"), true, "https://example.com/images/carrots.jpg", "Organic Carrots", 10.0, "Local", 1.49m, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.0, 4, 10.199999999999999, 1.0, 3 },
                    { new Guid("fa8ec7af-4cf4-4a28-8c37-5f2d3a1ab5e1"), "012345678911", 7, "Pure maple syrup, harvested from local maple trees.", 0.0m, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("06a9fdbb-dfd9-47d5-9a4a-7117ed1f2332"), new Guid("1474d237-fe36-4586-ac67-b3ddcf03baac"), false, "https://example.com/images/maple_syrup.jpg", "Maple Syrup", 9.0, "Vermont", 15.99m, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 18.0, 1, 9.3000000000000007, 0.5, 7 },
                    { new Guid("fffb5e9d-4c1e-4e0d-8997-1a7e537a5b89"), "012345678900", 2, "Fresh organic milk from grass-fed cows.", 10.0m, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("63ad63d2-5884-4c3d-93f1-1aaf75c0a563"), new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"), true, "https://example.com/images/organic_milk.jpg", "Organic Milk", 10.0, "Local", 3.49m, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.0, 1, 10.5, 1.0, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0fef93a3-0cd6-4e02-9404-b34d5f0e672a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11f7b5fc-f7f1-4782-b90b-b18b5e0fbb47"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3a679e4b-2c43-4eab-82e5-6c120c9d8e2b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8ab9a582-e0f2-46d1-9e13-8d8b0b2ef731"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aa1c9a77-5bf8-4cf8-995f-8f3ebc653c97"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("acdbb2f1-8f25-4b3c-a67a-b4d6e0b0f332"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ad91b21a-547f-4d1b-9e3c-4e0d53f8d347"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b197ed82-64f7-4d5c-b2b4-8cf2b31bfb50"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b21d8f58-8f67-4cb8-b31f-5ebd2ff1b107"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b9cdd8a5-3039-4a7f-93a4-9b76c6e5e510"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bb0b2f76-f1d8-49a3-ae15-5d2cb36c4899"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("be88d6d4-1ae2-4a5a-9d6c-ef564c6e1c37"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c62b13b9-6bc2-403f-9e0d-2de6d8f84f88"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c6b7e2c2-3f9a-4c27-b6ef-7f70e5bfcf92"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c89c1d90-a5d7-4416-9403-e5e1e3e0e217"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ccf1c98e-5cf4-4bfe-82c7-2a1dfb748e12"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d1f7e5a6-2a8d-4c5a-80c7-b8c0b58f2d91"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d2109b26-f315-48df-baf9-c1c45746e573"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("de3442a5-6a4d-4938-babe-2f3a7a5e9b34"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e2ca22b4-f728-4c4f-888b-17463d93d542"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fa8ec7af-4cf4-4a28-8c37-5f2d3a1ab5e1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fffb5e9d-4c1e-4e0d-8997-1a7e537a5b89"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9d787051-fee2-42b5-bad6-8d00a2528dcd", "AQAAAAIAAYagAAAAEKMmkJn6MdZ7R7YUQF6TzKXKbsQn3cR1QanY3yOiQELKoM7egscGt7xZ7s3H8cqe8w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ae81b6ce-982b-41fd-95c8-0bd6d9a830ab", "AQAAAAIAAYagAAAAEDMI0ozjdMStNnsYqhZnbw6hu4FnyFQyAegy0RvI0QulBSeGkiFD5Gh6IzIIsUsgXg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c53545cc-ecde-484a-aeb7-29ddc3ce43d6", "AQAAAAIAAYagAAAAEPVsxzbJUD1wxLZRUKHwSu5ZQHvYkIUS8//PYaazlLtJzpt0/ZzyYuFDzt3hA2WE+g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9e393fed-c2df-4de9-a78e-7269959d5fa3", "AQAAAAIAAYagAAAAELPbDgUAAXI1+tp18YBN69hETU920MqtME3oL20zkGCAA3H5Ery9kyVWpEpdu5ReHw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dd3d52cb-dbc8-4961-b64f-da972a3449c2", "AQAAAAIAAYagAAAAEIeIUi4UoaA0bhQicadCU44ArqdZ4NxTwkCYG7cNGJr8e3HTJrdZLdOxYHzs6tGUkQ==" });
        }
    }
}
