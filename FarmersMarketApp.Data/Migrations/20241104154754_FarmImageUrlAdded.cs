using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FarmImageUrlAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Farms",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Image url of farm picture.");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6aa8d9e4-236b-460b-9530-ce4528b39219", "AQAAAAIAAYagAAAAECmthKOTVhtU6Mt33arFTGMQNof81jayRRek/Hy4I8WZIR3JGyYM1NjyBGje0kDMHA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "16b2ef2d-f990-4a7b-9d49-22954d49306b", "AQAAAAIAAYagAAAAEGdgZNP07nSrzLLHjNwR+ncoaWPepi5PrcgDjP/sJER5J8RQYXbtqSK20bMcqHBCgg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a36bfb04-baa4-4126-a68f-3e446d915446", "AQAAAAIAAYagAAAAEGFQ1v/2HMqtlMRQV+xioPzRGssjw+Msu4Q7NIbVuMALH31tliSyRobzOZ+9W5CyZQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "53689e20-55e2-48a7-acea-d3d3f0545ba2", "AQAAAAIAAYagAAAAENUidhATg1qQI0Jf2VW9HDWabBohEdXLhU9TlcYK9wS3kYtxbBQa7Vk4+RAQhAkUoA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eb8c80d2-0c75-49fd-9035-572a19479f1d", "AQAAAAIAAYagAAAAEEd4zZQhaCcVerV7gvYLngR7MO+s71NZVf/VtLUOy1fMQJ41VQg9OOU94dRAn8glpw==" });

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("012cf2fc-b34e-425f-87a0-cc5989ea5c06"),
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("06a9fdbb-dfd9-47d5-9a4a-7117ed1f2332"),
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("272befbb-54fd-41d0-bfca-d72305535321"),
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("45c92bba-7ac0-42ae-995e-d6fc10e05067"),
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("581569fd-5062-4435-899b-8bfe31d2f4e8"),
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("63ad63d2-5884-4c3d-93f1-1aaf75c0a563"),
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("6ee2702d-fab7-42f4-bf10-6becc7b9dbd3"),
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("77b7f04e-c775-4735-a017-60c7d5b4ede9"),
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("7da444a3-fc8c-43e6-a223-378e5a51be4e"),
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("9a020bca-2f9f-4b61-af21-1adae08dd8e9"),
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("c437b349-7f30-44de-865a-31f24fc7c584"),
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("ce2e44ca-d118-4676-9623-624e7f56980e"),
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("d8fd1d22-ad66-4850-8a23-54d33e488964"),
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("dcbae87c-93a9-4699-b3e4-2e10776839dd"),
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("e609dc73-6845-4e72-80a4-1ad215a094d1"),
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0fef93a3-0cd6-4e02-9404-b34d5f0e672a"),
                column: "ImageUrl",
                value: "/img/sourdough_bread.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11f7b5fc-f7f1-4782-b90b-b18b5e0fbb47"),
                column: "ImageUrl",
                value: "/img/apples.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3a679e4b-2c43-4eab-82e5-6c120c9d8e2b"),
                column: "ImageUrl",
                value: "/img/eggs.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8ab9a582-e0f2-46d1-9e13-8d8b0b2ef731"),
                column: "ImageUrl",
                value: "/img/organic_butter.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aa1c9a77-5bf8-4cf8-995f-8f3ebc653c97"),
                column: "ImageUrl",
                value: "/img/spinach.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("acdbb2f1-8f25-4b3c-a67a-b4d6e0b0f332"),
                column: "ImageUrl",
                value: "/img/strawberries.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ad91b21a-547f-4d1b-9e3c-4e0d53f8d347"),
                column: "ImageUrl",
                value: "/img/honey.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b197ed82-64f7-4d5c-b2b4-8cf2b31bfb50"),
                column: "ImageUrl",
                value: "/img/wheat_flour.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b21d8f58-8f67-4cb8-b31f-5ebd2ff1b107"),
                column: "ImageUrl",
                value: "/img/orange_juice.webp");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b9cdd8a5-3039-4a7f-93a4-9b76c6e5e510"),
                column: "ImageUrl",
                value: "/img/almond_butter.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bb0b2f76-f1d8-49a3-ae15-5d2cb36c4899"),
                column: "ImageUrl",
                value: "/img/marmalade.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("be88d6d4-1ae2-4a5a-9d6c-ef564c6e1c37"),
                column: "ImageUrl",
                value: "/img/organic_olive_oil.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c62b13b9-6bc2-403f-9e0d-2de6d8f84f88"),
                column: "ImageUrl",
                value: "/img/apples.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c6b7e2c2-3f9a-4c27-b6ef-7f70e5bfcf92"),
                column: "ImageUrl",
                value: "/img/almond_milk.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c89c1d90-a5d7-4416-9403-e5e1e3e0e217"),
                column: "ImageUrl",
                value: "/img/greek_yogurt.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ccf1c98e-5cf4-4bfe-82c7-2a1dfb748e12"),
                column: "ImageUrl",
                value: "/img/yogurt.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d1f7e5a6-2a8d-4c5a-80c7-b8c0b58f2d91"),
                column: "ImageUrl",
                value: "/img/cheddar_cheese.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d2109b26-f315-48df-baf9-c1c45746e573"),
                column: "ImageUrl",
                value: "/img/salmon_fillet.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("de3442a5-6a4d-4938-babe-2f3a7a5e9b34"),
                column: "ImageUrl",
                value: "/img/salmon.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e2ca22b4-f728-4c4f-888b-17463d93d542"),
                column: "ImageUrl",
                value: "/img/carrots.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fa8ec7af-4cf4-4a28-8c37-5f2d3a1ab5e1"),
                column: "ImageUrl",
                value: "/img/maple_syrup.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fffb5e9d-4c1e-4e0d-8997-1a7e537a5b89"),
                column: "ImageUrl",
                value: "/img/milk.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Farms");

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

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0fef93a3-0cd6-4e02-9404-b34d5f0e672a"),
                column: "ImageUrl",
                value: "https://example.com/images/sourdough_bread.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11f7b5fc-f7f1-4782-b90b-b18b5e0fbb47"),
                column: "ImageUrl",
                value: "https://example.com/images/apples.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3a679e4b-2c43-4eab-82e5-6c120c9d8e2b"),
                column: "ImageUrl",
                value: "https://example.com/images/eggs.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8ab9a582-e0f2-46d1-9e13-8d8b0b2ef731"),
                column: "ImageUrl",
                value: "https://example.com/images/organic_butter.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aa1c9a77-5bf8-4cf8-995f-8f3ebc653c97"),
                column: "ImageUrl",
                value: "https://example.com/images/spinach.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("acdbb2f1-8f25-4b3c-a67a-b4d6e0b0f332"),
                column: "ImageUrl",
                value: "https://example.com/images/strawberries.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ad91b21a-547f-4d1b-9e3c-4e0d53f8d347"),
                column: "ImageUrl",
                value: "https://example.com/images/honey.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b197ed82-64f7-4d5c-b2b4-8cf2b31bfb50"),
                column: "ImageUrl",
                value: "https://example.com/images/wheat_flour.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b21d8f58-8f67-4cb8-b31f-5ebd2ff1b107"),
                column: "ImageUrl",
                value: "https://example.com/images/orange_juice.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b9cdd8a5-3039-4a7f-93a4-9b76c6e5e510"),
                column: "ImageUrl",
                value: "https://example.com/images/almond_butter.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bb0b2f76-f1d8-49a3-ae15-5d2cb36c4899"),
                column: "ImageUrl",
                value: "https://example.com/images/orange_marmalade.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("be88d6d4-1ae2-4a5a-9d6c-ef564c6e1c37"),
                column: "ImageUrl",
                value: "https://example.com/images/olive_oil.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c62b13b9-6bc2-403f-9e0d-2de6d8f84f88"),
                column: "ImageUrl",
                value: "https://example.com/images/organic_apples.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c6b7e2c2-3f9a-4c27-b6ef-7f70e5bfcf92"),
                column: "ImageUrl",
                value: "https://example.com/images/almond_milk.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c89c1d90-a5d7-4416-9403-e5e1e3e0e217"),
                column: "ImageUrl",
                value: "https://example.com/images/greek_yogurt.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ccf1c98e-5cf4-4bfe-82c7-2a1dfb748e12"),
                column: "ImageUrl",
                value: "https://example.com/images/greek_yogurt.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d1f7e5a6-2a8d-4c5a-80c7-b8c0b58f2d91"),
                column: "ImageUrl",
                value: "https://example.com/images/cheddar_cheese.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d2109b26-f315-48df-baf9-c1c45746e573"),
                column: "ImageUrl",
                value: "https://example.com/images/salmon_fillet.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("de3442a5-6a4d-4938-babe-2f3a7a5e9b34"),
                column: "ImageUrl",
                value: "https://example.com/images/salmon_fillet.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e2ca22b4-f728-4c4f-888b-17463d93d542"),
                column: "ImageUrl",
                value: "https://example.com/images/carrots.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fa8ec7af-4cf4-4a28-8c37-5f2d3a1ab5e1"),
                column: "ImageUrl",
                value: "https://example.com/images/maple_syrup.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fffb5e9d-4c1e-4e0d-8997-1a7e537a5b89"),
                column: "ImageUrl",
                value: "https://example.com/images/organic_milk.jpg");
        }
    }
}
