using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FarmerDateApprovedMadeNullableImagesAddedToFarmerAndFarmSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateApproved",
                table: "Farmers",
                type: "datetime2",
                nullable: true,
                comment: "Date and time when administrator has approved farmer.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date and time when administrator has approved farmer.");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5df89e12-bfa2-4859-afa4-635f56f481ee", "AQAAAAIAAYagAAAAEDA9327GAIgJDZeaJ27utmc3a3uF0gXcjMXmvjQxlDg7IXgsV2Ymj6kUB1+8HEkRtw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c1ecda55-f671-464f-b19b-4e2d1aead6af", "AQAAAAIAAYagAAAAEDyf6Ah9g3RnhaHY2PsQohibqmcg1riXfbWOytcXrGPhkHL05YENFceeMSooAqf2Wg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d128ea46-307f-469d-add4-c29ebc4c3a58", "AQAAAAIAAYagAAAAEJsrLEyZVVsbqrXfCTsgLDQxQbvBnEAgqsI1Oj7nHS8RzFd3Yq8+LalraByR6SqbZw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "71e80d22-f940-4d8a-8827-9f242163e3bd", "AQAAAAIAAYagAAAAEPRXS3vrWoFr3veUspGKk5XRB0XzQHOFB8dQ8QGEKLRkHNs9b9ssWb5CdnWx3WBpZg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b2996698-1da5-427f-9188-bccb9866e911", "AQAAAAIAAYagAAAAELzSjTrAStwaZc5rNbHkXaxlIfeBmr5mc5WCtv80T8pQ0WERQRs4Jw+njf5jare2Rg==" });

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: new Guid("1474d237-fe36-4586-ac67-b3ddcf03baac"),
                columns: new[] { "DateApproved", "ImageUrl" },
                values: new object[] { new DateTime(2024, 11, 2, 13, 11, 0, 0, DateTimeKind.Unspecified), "/img/dwight.jpg" });

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: new Guid("65c75a94-f3be-4a7a-913e-d6c868876265"),
                columns: new[] { "DateApproved", "ImageUrl" },
                values: new object[] { new DateTime(2024, 10, 18, 15, 44, 0, 0, DateTimeKind.Unspecified), "/img/michael.jpg" });

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"),
                columns: new[] { "DateApproved", "ImageUrl" },
                values: new object[] { new DateTime(2024, 10, 10, 19, 27, 0, 0, DateTimeKind.Unspecified), "/img/kevin.png" });

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("012cf2fc-b34e-425f-87a0-cc5989ea5c06"),
                column: "ImageUrl",
                value: "/img/farm15.jpg");

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("06a9fdbb-dfd9-47d5-9a4a-7117ed1f2332"),
                column: "ImageUrl",
                value: "/img/farm9.jpg");

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("272befbb-54fd-41d0-bfca-d72305535321"),
                column: "ImageUrl",
                value: "/img/farm12.jpg");

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("45c92bba-7ac0-42ae-995e-d6fc10e05067"),
                column: "ImageUrl",
                value: "/img/farm13.jpg");

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("581569fd-5062-4435-899b-8bfe31d2f4e8"),
                column: "ImageUrl",
                value: "/img/farm2.jpg");

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("63ad63d2-5884-4c3d-93f1-1aaf75c0a563"),
                column: "ImageUrl",
                value: "/img/farm8.jpg");

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("6ee2702d-fab7-42f4-bf10-6becc7b9dbd3"),
                column: "ImageUrl",
                value: "/img/farm7.jpg");

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("77b7f04e-c775-4735-a017-60c7d5b4ede9"),
                column: "ImageUrl",
                value: "/img/farm11.jpg");

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("7da444a3-fc8c-43e6-a223-378e5a51be4e"),
                column: "ImageUrl",
                value: "/img/farm6.jpg");

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("9a020bca-2f9f-4b61-af21-1adae08dd8e9"),
                column: "ImageUrl",
                value: "/img/farm3.jpg");

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("c437b349-7f30-44de-865a-31f24fc7c584"),
                column: "ImageUrl",
                value: "/img/farm4.jpg");

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("ce2e44ca-d118-4676-9623-624e7f56980e"),
                column: "ImageUrl",
                value: "/img/farm14.jpg");

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("d8fd1d22-ad66-4850-8a23-54d33e488964"),
                column: "ImageUrl",
                value: "/img/farm1.jpg");

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("dcbae87c-93a9-4699-b3e4-2e10776839dd"),
                column: "ImageUrl",
                value: "/img/farm5.jpg");

            migrationBuilder.UpdateData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("e609dc73-6845-4e72-80a4-1ad215a094d1"),
                column: "ImageUrl",
                value: "/img/farm10.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateApproved",
                table: "Farmers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Date and time when administrator has approved farmer.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "Date and time when administrator has approved farmer.");

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
                table: "Farmers",
                keyColumn: "Id",
                keyValue: new Guid("1474d237-fe36-4586-ac67-b3ddcf03baac"),
                columns: new[] { "DateApproved", "ImageUrl" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: new Guid("65c75a94-f3be-4a7a-913e-d6c868876265"),
                columns: new[] { "DateApproved", "ImageUrl" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"),
                columns: new[] { "DateApproved", "ImageUrl" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

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
        }
    }
}
