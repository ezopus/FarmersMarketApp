using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FarmsSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Farms",
                columns: new[] { "Id", "Address", "City", "CloseHours", "Email", "IsOpen", "Name", "OpenHours", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("012cf2fc-b34e-425f-87a0-cc5989ea5c06"), "112 Orchard Drive", "Peach Valley", new TimeOnly(18, 0, 0), "info@orchardhill.com", true, "Orchard Hill", new TimeOnly(8, 0, 0), "555-6633" },
                    { new Guid("06a9fdbb-dfd9-47d5-9a4a-7117ed1f2332"), "77 Orchard Street", "Brookside", new TimeOnly(20, 0, 0), "support@meadowbrook.com", true, "Meadow Brook Orchards", new TimeOnly(8, 0, 0), "555-9988" },
                    { new Guid("272befbb-54fd-41d0-bfca-d72305535321"), "901 River Lane", "Watertown", new TimeOnly(18, 0, 0), "info@riverbendfarm.com", false, "Riverbend Farm", new TimeOnly(8, 0, 0), "555-3345" },
                    { new Guid("45c92bba-7ac0-42ae-995e-d6fc10e05067"), "740 Oak Street", "Mapleton", new TimeOnly(16, 0, 0), "hello@autumngrove.com", true, "Autumn Grove", new TimeOnly(7, 0, 0), "555-2344" },
                    { new Guid("581569fd-5062-4435-899b-8bfe31d2f4e8"), "456 Oak Avenue", "Hilltop", new TimeOnly(17, 0, 0), "info@mountainviewfarm.com", false, "Mountainview Farm", new TimeOnly(7, 0, 0), "555-5678" },
                    { new Guid("63ad63d2-5884-4c3d-93f1-1aaf75c0a563"), "845 Willow Road", "Silverlake", new TimeOnly(17, 0, 0), "hello@willowcreek.com", false, "Willow Creek Farm", new TimeOnly(7, 0, 0), "555-4433" },
                    { new Guid("6ee2702d-fab7-42f4-bf10-6becc7b9dbd3"), "200 Harvest Lane", "Fairview", new TimeOnly(18, 0, 0), "contact@harvesthill.com", true, "Harvest Hill Farm", new TimeOnly(6, 0, 0), "555-2211" },
                    { new Guid("77b7f04e-c775-4735-a017-60c7d5b4ede9"), "123 Pinewood Road", "Greenwood", new TimeOnly(19, 30, 0), "contact@evergreenacres.com", true, "Evergreen Acres", new TimeOnly(6, 30, 0), "555-5567" },
                    { new Guid("7da444a3-fc8c-43e6-a223-378e5a51be4e"), "912 Sunset Blvd", "Clearwater", new TimeOnly(16, 30, 0), "info@sunriseranch.com", true, "Sunrise Ranch", new TimeOnly(7, 30, 0), "555-9912" },
                    { new Guid("9a020bca-2f9f-4b61-af21-1adae08dd8e9"), "789 Blueberry Lane", "Lakewood", new TimeOnly(20, 0, 0), "hello@lakesideorchards.com", true, "Lakeside Orchards", new TimeOnly(9, 0, 0), "555-8765" },
                    { new Guid("c437b349-7f30-44de-865a-31f24fc7c584"), "321 Apple Street", "Springfield", new TimeOnly(19, 0, 0), "support@greenmeadowfarms.com", false, "Green Meadow Farms", new TimeOnly(6, 0, 0), "555-1122" },
                    { new Guid("ce2e44ca-d118-4676-9623-624e7f56980e"), "455 Prairie Road", "Plainsville", new TimeOnly(18, 0, 0), "contact@prairieview.com", false, "Prairie View Farm", new TimeOnly(6, 0, 0), "555-4455" },
                    { new Guid("d8fd1d22-ad66-4850-8a23-54d33e488964"), "123 Greenway Drive", "Riverside", new TimeOnly(18, 0, 0), "contact@sunnyfields.com", true, "Sunny Fields", new TimeOnly(8, 0, 0), "555-1234" },
                    { new Guid("dcbae87c-93a9-4699-b3e4-2e10776839dd"), "654 Maple Road", "Greenville", new TimeOnly(18, 30, 0), "contact@valleyfarmmarket.com", true, "Valley Farm Market", new TimeOnly(8, 30, 0), "555-3344" },
                    { new Guid("e609dc73-6845-4e72-80a4-1ad215a094d1"), "389 Valley View", "Eagle Peak", new TimeOnly(17, 30, 0), "info@blueskyfarms.com", true, "Blue Sky Farms", new TimeOnly(5, 30, 0), "555-7822" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("012cf2fc-b34e-425f-87a0-cc5989ea5c06"));

            migrationBuilder.DeleteData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("06a9fdbb-dfd9-47d5-9a4a-7117ed1f2332"));

            migrationBuilder.DeleteData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("272befbb-54fd-41d0-bfca-d72305535321"));

            migrationBuilder.DeleteData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("45c92bba-7ac0-42ae-995e-d6fc10e05067"));

            migrationBuilder.DeleteData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("581569fd-5062-4435-899b-8bfe31d2f4e8"));

            migrationBuilder.DeleteData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("63ad63d2-5884-4c3d-93f1-1aaf75c0a563"));

            migrationBuilder.DeleteData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("6ee2702d-fab7-42f4-bf10-6becc7b9dbd3"));

            migrationBuilder.DeleteData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("77b7f04e-c775-4735-a017-60c7d5b4ede9"));

            migrationBuilder.DeleteData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("7da444a3-fc8c-43e6-a223-378e5a51be4e"));

            migrationBuilder.DeleteData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("9a020bca-2f9f-4b61-af21-1adae08dd8e9"));

            migrationBuilder.DeleteData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("c437b349-7f30-44de-865a-31f24fc7c584"));

            migrationBuilder.DeleteData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("ce2e44ca-d118-4676-9623-624e7f56980e"));

            migrationBuilder.DeleteData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("d8fd1d22-ad66-4850-8a23-54d33e488964"));

            migrationBuilder.DeleteData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("dcbae87c-93a9-4699-b3e4-2e10776839dd"));

            migrationBuilder.DeleteData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: new Guid("e609dc73-6845-4e72-80a4-1ad215a094d1"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "56b24c58-a765-49f3-9efc-a0ca0886c6a9", "AQAAAAIAAYagAAAAEA7zAv9EOCqXDg25xuobx1db3ktgJaZbSztRMubavgsbMspwf1NCqMlAeauecIW24g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "69836e63-f68e-488f-a1ce-235fc9de3eca", "AQAAAAIAAYagAAAAEEV3XgjuAJwfYgsDrGxN7cT/CS/jSDJR5z0mUY2KMTR2/UG2natk313g1J3NEozNtQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a6b20b95-cd6b-4643-aed9-1b0ecd1bcd37", "AQAAAAIAAYagAAAAEEGWcI7lC5OGRTAUDHBGkgB9dyt1b1dtC2dLVJOl4r624LWlWIwDuuAuoU7mtDqpDw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3e9a8682-7853-4ea8-a0de-f82e3269ee72", "AQAAAAIAAYagAAAAEN6GGurT0Efmea72OvuTQVgjQGR+dpS366W0/BmSVJ7BEunjjQ3CHea48NI2B4pS4g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c8eac554-fde8-4174-baa9-3f9a02b285f3", "AQAAAAIAAYagAAAAEOr3kPKUguEySh3HxYVK4MZ9j8gfM3vwejJ3NKkNgc8l54aq+fT0wd2y016y6O/pNg==" });
        }
    }
}
