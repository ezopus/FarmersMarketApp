using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DateAddedAddedToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Date when product was added to the market.");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "25b84022-018c-496f-ac18-c8a812190031", "AQAAAAIAAYagAAAAEFjOXXiJM5hkjhiCyO52awymYcwQ3NeQhj19aseYwn7vawEOTt2o1rBGH4iXWE18eg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7c6d70e4-e6db-47ef-b224-dff36f527a2c", "AQAAAAIAAYagAAAAEEF5IpUDeJklHEwZcqDcJBXwt9Dlnq0ydpOh6lA8uay+zKkD0ts1UnFhLsbhd+6d6w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e11d2d7e-b182-49f6-8dcb-4035ef328ca5", "AQAAAAIAAYagAAAAEOGVQlguDbrklr8LRg+k1vLm/9I+8JIqk0XPewn8rQC7RMlR3SEhiOienjpxxaoTTQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "27f48843-9231-45ff-a923-1a20a3eebc56", "AQAAAAIAAYagAAAAEBe1qbms7llL1SsMsR/Qk02C0mx/ctXrraiNBYCAEq4aTxBQ/DdbqhImldbvOTqsaQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e89a27a0-abc9-4b81-8719-2f0b29fe760d", "AQAAAAIAAYagAAAAEFbQDAaG/NOSYJwnjDOl+9gDKjwfG9dOPlrerX0qwYEBnVC2wEMrDrKTOV3Eg64zrg==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0fef93a3-0cd6-4e02-9404-b34d5f0e672a"),
                column: "DateAdded",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11f7b5fc-f7f1-4782-b90b-b18b5e0fbb47"),
                column: "DateAdded",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3a679e4b-2c43-4eab-82e5-6c120c9d8e2b"),
                column: "DateAdded",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8ab9a582-e0f2-46d1-9e13-8d8b0b2ef731"),
                column: "DateAdded",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aa1c9a77-5bf8-4cf8-995f-8f3ebc653c97"),
                column: "DateAdded",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("acdbb2f1-8f25-4b3c-a67a-b4d6e0b0f332"),
                column: "DateAdded",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ad91b21a-547f-4d1b-9e3c-4e0d53f8d347"),
                column: "DateAdded",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b197ed82-64f7-4d5c-b2b4-8cf2b31bfb50"),
                column: "DateAdded",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b21d8f58-8f67-4cb8-b31f-5ebd2ff1b107"),
                column: "DateAdded",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b9cdd8a5-3039-4a7f-93a4-9b76c6e5e510"),
                column: "DateAdded",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bb0b2f76-f1d8-49a3-ae15-5d2cb36c4899"),
                column: "DateAdded",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("be88d6d4-1ae2-4a5a-9d6c-ef564c6e1c37"),
                column: "DateAdded",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c62b13b9-6bc2-403f-9e0d-2de6d8f84f88"),
                column: "DateAdded",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c6b7e2c2-3f9a-4c27-b6ef-7f70e5bfcf92"),
                column: "DateAdded",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c89c1d90-a5d7-4416-9403-e5e1e3e0e217"),
                column: "DateAdded",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ccf1c98e-5cf4-4bfe-82c7-2a1dfb748e12"),
                column: "DateAdded",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d1f7e5a6-2a8d-4c5a-80c7-b8c0b58f2d91"),
                column: "DateAdded",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d2109b26-f315-48df-baf9-c1c45746e573"),
                column: "DateAdded",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("de3442a5-6a4d-4938-babe-2f3a7a5e9b34"),
                column: "DateAdded",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e2ca22b4-f728-4c4f-888b-17463d93d542"),
                column: "DateAdded",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fa8ec7af-4cf4-4a28-8c37-5f2d3a1ab5e1"),
                column: "DateAdded",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fffb5e9d-4c1e-4e0d-8997-1a7e537a5b89"),
                column: "DateAdded",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Products");

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
        }
    }
}
