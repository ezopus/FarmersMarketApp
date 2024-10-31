using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FarmerFarmsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "FarmerFarm",
                columns: new[] { "FarmId", "FarmerId", "IsDeleted" },
                values: new object[,]
                {
                    { new Guid("012cf2fc-b34e-425f-87a0-cc5989ea5c06"), new Guid("65c75a94-f3be-4a7a-913e-d6c868876265"), false },
                    { new Guid("06a9fdbb-dfd9-47d5-9a4a-7117ed1f2332"), new Guid("1474d237-fe36-4586-ac67-b3ddcf03baac"), false },
                    { new Guid("272befbb-54fd-41d0-bfca-d72305535321"), new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"), false },
                    { new Guid("45c92bba-7ac0-42ae-995e-d6fc10e05067"), new Guid("1474d237-fe36-4586-ac67-b3ddcf03baac"), false },
                    { new Guid("581569fd-5062-4435-899b-8bfe31d2f4e8"), new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"), false },
                    { new Guid("63ad63d2-5884-4c3d-93f1-1aaf75c0a563"), new Guid("65c75a94-f3be-4a7a-913e-d6c868876265"), false },
                    { new Guid("6ee2702d-fab7-42f4-bf10-6becc7b9dbd3"), new Guid("1474d237-fe36-4586-ac67-b3ddcf03baac"), false },
                    { new Guid("77b7f04e-c775-4735-a017-60c7d5b4ede9"), new Guid("65c75a94-f3be-4a7a-913e-d6c868876265"), false },
                    { new Guid("7da444a3-fc8c-43e6-a223-378e5a51be4e"), new Guid("65c75a94-f3be-4a7a-913e-d6c868876265"), false },
                    { new Guid("9a020bca-2f9f-4b61-af21-1adae08dd8e9"), new Guid("65c75a94-f3be-4a7a-913e-d6c868876265"), false },
                    { new Guid("c437b349-7f30-44de-865a-31f24fc7c584"), new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"), false },
                    { new Guid("ce2e44ca-d118-4676-9623-624e7f56980e"), new Guid("1474d237-fe36-4586-ac67-b3ddcf03baac"), false },
                    { new Guid("d8fd1d22-ad66-4850-8a23-54d33e488964"), new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"), false },
                    { new Guid("dcbae87c-93a9-4699-b3e4-2e10776839dd"), new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"), false },
                    { new Guid("e609dc73-6845-4e72-80a4-1ad215a094d1"), new Guid("1474d237-fe36-4586-ac67-b3ddcf03baac"), false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FarmerFarm",
                keyColumns: new[] { "FarmId", "FarmerId" },
                keyValues: new object[] { new Guid("012cf2fc-b34e-425f-87a0-cc5989ea5c06"), new Guid("65c75a94-f3be-4a7a-913e-d6c868876265") });

            migrationBuilder.DeleteData(
                table: "FarmerFarm",
                keyColumns: new[] { "FarmId", "FarmerId" },
                keyValues: new object[] { new Guid("06a9fdbb-dfd9-47d5-9a4a-7117ed1f2332"), new Guid("1474d237-fe36-4586-ac67-b3ddcf03baac") });

            migrationBuilder.DeleteData(
                table: "FarmerFarm",
                keyColumns: new[] { "FarmId", "FarmerId" },
                keyValues: new object[] { new Guid("272befbb-54fd-41d0-bfca-d72305535321"), new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1") });

            migrationBuilder.DeleteData(
                table: "FarmerFarm",
                keyColumns: new[] { "FarmId", "FarmerId" },
                keyValues: new object[] { new Guid("45c92bba-7ac0-42ae-995e-d6fc10e05067"), new Guid("1474d237-fe36-4586-ac67-b3ddcf03baac") });

            migrationBuilder.DeleteData(
                table: "FarmerFarm",
                keyColumns: new[] { "FarmId", "FarmerId" },
                keyValues: new object[] { new Guid("581569fd-5062-4435-899b-8bfe31d2f4e8"), new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1") });

            migrationBuilder.DeleteData(
                table: "FarmerFarm",
                keyColumns: new[] { "FarmId", "FarmerId" },
                keyValues: new object[] { new Guid("63ad63d2-5884-4c3d-93f1-1aaf75c0a563"), new Guid("65c75a94-f3be-4a7a-913e-d6c868876265") });

            migrationBuilder.DeleteData(
                table: "FarmerFarm",
                keyColumns: new[] { "FarmId", "FarmerId" },
                keyValues: new object[] { new Guid("6ee2702d-fab7-42f4-bf10-6becc7b9dbd3"), new Guid("1474d237-fe36-4586-ac67-b3ddcf03baac") });

            migrationBuilder.DeleteData(
                table: "FarmerFarm",
                keyColumns: new[] { "FarmId", "FarmerId" },
                keyValues: new object[] { new Guid("77b7f04e-c775-4735-a017-60c7d5b4ede9"), new Guid("65c75a94-f3be-4a7a-913e-d6c868876265") });

            migrationBuilder.DeleteData(
                table: "FarmerFarm",
                keyColumns: new[] { "FarmId", "FarmerId" },
                keyValues: new object[] { new Guid("7da444a3-fc8c-43e6-a223-378e5a51be4e"), new Guid("65c75a94-f3be-4a7a-913e-d6c868876265") });

            migrationBuilder.DeleteData(
                table: "FarmerFarm",
                keyColumns: new[] { "FarmId", "FarmerId" },
                keyValues: new object[] { new Guid("9a020bca-2f9f-4b61-af21-1adae08dd8e9"), new Guid("65c75a94-f3be-4a7a-913e-d6c868876265") });

            migrationBuilder.DeleteData(
                table: "FarmerFarm",
                keyColumns: new[] { "FarmId", "FarmerId" },
                keyValues: new object[] { new Guid("c437b349-7f30-44de-865a-31f24fc7c584"), new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1") });

            migrationBuilder.DeleteData(
                table: "FarmerFarm",
                keyColumns: new[] { "FarmId", "FarmerId" },
                keyValues: new object[] { new Guid("ce2e44ca-d118-4676-9623-624e7f56980e"), new Guid("1474d237-fe36-4586-ac67-b3ddcf03baac") });

            migrationBuilder.DeleteData(
                table: "FarmerFarm",
                keyColumns: new[] { "FarmId", "FarmerId" },
                keyValues: new object[] { new Guid("d8fd1d22-ad66-4850-8a23-54d33e488964"), new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1") });

            migrationBuilder.DeleteData(
                table: "FarmerFarm",
                keyColumns: new[] { "FarmId", "FarmerId" },
                keyValues: new object[] { new Guid("dcbae87c-93a9-4699-b3e4-2e10776839dd"), new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1") });

            migrationBuilder.DeleteData(
                table: "FarmerFarm",
                keyColumns: new[] { "FarmId", "FarmerId" },
                keyValues: new object[] { new Guid("e609dc73-6845-4e72-80a4-1ad215a094d1"), new Guid("1474d237-fe36-4586-ac67-b3ddcf03baac") });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f51a867d-6bb0-4e04-b90d-38e23bfbcc5b", "AQAAAAIAAYagAAAAELDL6w1gNLsggj6IeaktZwCGtYGzNBN1uv+HUTTuaNFrbX5sQVxJLTe5W+NHCVJWiA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2acd8374-11a9-4c31-9de3-add4b7496e91", "AQAAAAIAAYagAAAAELmp/u/9++NXiBZAES7YD+rH9nRhEyWaPMwmRTSqrP/Nusl44QTRboswSCdgNf0PXA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1f0ce1ce-088a-48da-92ae-bde0f30abd14", "AQAAAAIAAYagAAAAEBUx11MrTpmd1hnI9YIjj+iCQniAQnlvnWlHn4+rxA9IgwGSvnCHiTSvESXo4nw1sg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1c1c2055-6a65-4351-b20e-fcf944ddf70b", "AQAAAAIAAYagAAAAEMjLGaMOkd2w85nlJ4U2rEGrNbea9ZrJTBcQ1g+Yr14RsuqRTRI4II8KBEHdNpdB9A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eb1154a2-72d4-41f7-9a6c-82b3a73c9093", "AQAAAAIAAYagAAAAEAgCpUcALwCuuu4IKU16P70vIgG09wpl420NN4416eztWo7KTdXl/AyhGqbjpaIYyQ==" });
        }
    }
}
