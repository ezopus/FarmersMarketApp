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
            migrationBuilder.InsertData(
                table: "Farms",
                columns: new[] { "Id", "Address", "City", "CloseHours", "Email", "FarmerId", "IsOpen", "Name", "OpenHours", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("012cf2fc-b34e-425f-87a0-cc5989ea5c06"), "112 Orchard Drive", "Peach Valley", new TimeOnly(18, 0, 0), "info@orchardhill.com", new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"), true, "Orchard Hill", new TimeOnly(8, 0, 0), "555-6633" },
                    { new Guid("06a9fdbb-dfd9-47d5-9a4a-7117ed1f2332"), "77 Orchard Street", "Brookside", new TimeOnly(20, 0, 0), "support@meadowbrook.com", new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"), true, "Meadow Brook Orchards", new TimeOnly(8, 0, 0), "555-9988" },
                    { new Guid("272befbb-54fd-41d0-bfca-d72305535321"), "901 River Lane", "Watertown", new TimeOnly(18, 0, 0), "info@riverbendfarm.com", new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"), false, "Riverbend Farm", new TimeOnly(8, 0, 0), "555-3345" },
                    { new Guid("45c92bba-7ac0-42ae-995e-d6fc10e05067"), "740 Oak Street", "Mapleton", new TimeOnly(16, 0, 0), "hello@autumngrove.com", new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"), true, "Autumn Grove", new TimeOnly(7, 0, 0), "555-2344" },
                    { new Guid("581569fd-5062-4435-899b-8bfe31d2f4e8"), "456 Oak Avenue", "Hilltop", new TimeOnly(17, 0, 0), "info@mountainviewfarm.com", new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"), false, "Mountainview Farm", new TimeOnly(7, 0, 0), "555-5678" },
                    { new Guid("63ad63d2-5884-4c3d-93f1-1aaf75c0a563"), "845 Willow Road", "Silverlake", new TimeOnly(17, 0, 0), "hello@willowcreek.com", new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"), false, "Willow Creek Farm", new TimeOnly(7, 0, 0), "555-4433" },
                    { new Guid("6ee2702d-fab7-42f4-bf10-6becc7b9dbd3"), "200 Harvest Lane", "Fairview", new TimeOnly(18, 0, 0), "contact@harvesthill.com", new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"), true, "Harvest Hill Farm", new TimeOnly(6, 0, 0), "555-2211" },
                    { new Guid("77b7f04e-c775-4735-a017-60c7d5b4ede9"), "123 Pinewood Road", "Greenwood", new TimeOnly(19, 30, 0), "contact@evergreenacres.com", new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"), true, "Evergreen Acres", new TimeOnly(6, 30, 0), "555-5567" },
                    { new Guid("7da444a3-fc8c-43e6-a223-378e5a51be4e"), "912 Sunset Blvd", "Clearwater", new TimeOnly(16, 30, 0), "info@sunriseranch.com", new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"), true, "Sunrise Ranch", new TimeOnly(7, 30, 0), "555-9912" },
                    { new Guid("9a020bca-2f9f-4b61-af21-1adae08dd8e9"), "789 Blueberry Lane", "Lakewood", new TimeOnly(20, 0, 0), "hello@lakesideorchards.com", new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"), true, "Lakeside Orchards", new TimeOnly(9, 0, 0), "555-8765" },
                    { new Guid("c437b349-7f30-44de-865a-31f24fc7c584"), "321 Apple Street", "Springfield", new TimeOnly(19, 0, 0), "support@greenmeadowfarms.com", new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"), false, "Green Meadow Farms", new TimeOnly(6, 0, 0), "555-1122" },
                    { new Guid("ce2e44ca-d118-4676-9623-624e7f56980e"), "455 Prairie Road", "Plainsville", new TimeOnly(18, 0, 0), "contact@prairieview.com", new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"), false, "Prairie View Farm", new TimeOnly(6, 0, 0), "555-4455" },
                    { new Guid("d8fd1d22-ad66-4850-8a23-54d33e488964"), "123 Greenway Drive", "Riverside", new TimeOnly(18, 0, 0), "contact@sunnyfields.com", new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"), true, "Sunny Fields", new TimeOnly(8, 0, 0), "555-1234" },
                    { new Guid("dcbae87c-93a9-4699-b3e4-2e10776839dd"), "654 Maple Road", "Greenville", new TimeOnly(18, 30, 0), "contact@valleyfarmmarket.com", new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"), true, "Valley Farm Market", new TimeOnly(8, 30, 0), "555-3344" },
                    { new Guid("e609dc73-6845-4e72-80a4-1ad215a094d1"), "389 Valley View", "Eagle Peak", new TimeOnly(17, 30, 0), "info@blueskyfarms.com", new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"), true, "Blue Sky Farms", new TimeOnly(5, 30, 0), "555-7822" }
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
        }
    }
}
