using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedFarmerIdFromProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Farmers_FarmerId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_FarmerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FarmerId",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e679247f-2c9f-49df-ab96-e026976a280a", "AQAAAAIAAYagAAAAEDPYJ1eh5bDHGc9o+s2tyH6H06gMmQKRVAL/LfOknmhtWcd5G3r5XM/wxbThHUYYng==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ba6fedb4-949b-441b-8851-97a4af6bd3f2", "AQAAAAIAAYagAAAAEMrILnnhgeffGL8jh6XOfezIiT3IJ196VWTGPtEpk8YS8fhlw01hSQfeFWtVEZI3XA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b669264e-4426-4d2d-8aa8-48bbb593b6df", "AQAAAAIAAYagAAAAEB7ObR1oB1hh1uQKw0TbBjKsDmfzT/91BjDVMwdOU648A0IMJRgMOm6CNI86nqAFbg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "82c63377-299c-4538-9a7d-699c6f4e3581", "AQAAAAIAAYagAAAAEPLBeSMoX23ixj3nFePcbvHuCkXvGko3HMhxVikLISztTwLO42Oe0zpTK3E2WvyAGA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "00de8274-92d9-49a5-b89c-eb100a5dc9cf", "AQAAAAIAAYagAAAAEIzt1hbgF3FOjEZGhFieJK+sSJwPSyAnVZJtBiGlPih1SP2AjHfnXqyARFPvMcSSqg==" });

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"),
                column: "ImageUrl",
                value: "/img/kevin.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FarmerId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Unique identifier of farmer who produces current product.");

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
                keyValue: new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"),
                column: "ImageUrl",
                value: "/img/kevin.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0fef93a3-0cd6-4e02-9404-b34d5f0e672a"),
                column: "FarmerId",
                value: new Guid("65c75a94-f3be-4a7a-913e-d6c868876265"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11f7b5fc-f7f1-4782-b90b-b18b5e0fbb47"),
                column: "FarmerId",
                value: new Guid("1474d237-fe36-4586-ac67-b3ddcf03baac"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3a679e4b-2c43-4eab-82e5-6c120c9d8e2b"),
                column: "FarmerId",
                value: new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8ab9a582-e0f2-46d1-9e13-8d8b0b2ef731"),
                column: "FarmerId",
                value: new Guid("65c75a94-f3be-4a7a-913e-d6c868876265"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aa1c9a77-5bf8-4cf8-995f-8f3ebc653c97"),
                column: "FarmerId",
                value: new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("acdbb2f1-8f25-4b3c-a67a-b4d6e0b0f332"),
                column: "FarmerId",
                value: new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ad91b21a-547f-4d1b-9e3c-4e0d53f8d347"),
                column: "FarmerId",
                value: new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b197ed82-64f7-4d5c-b2b4-8cf2b31bfb50"),
                column: "FarmerId",
                value: new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b21d8f58-8f67-4cb8-b31f-5ebd2ff1b107"),
                column: "FarmerId",
                value: new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b9cdd8a5-3039-4a7f-93a4-9b76c6e5e510"),
                column: "FarmerId",
                value: new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bb0b2f76-f1d8-49a3-ae15-5d2cb36c4899"),
                column: "FarmerId",
                value: new Guid("1474d237-fe36-4586-ac67-b3ddcf03baac"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("be88d6d4-1ae2-4a5a-9d6c-ef564c6e1c37"),
                column: "FarmerId",
                value: new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c62b13b9-6bc2-403f-9e0d-2de6d8f84f88"),
                column: "FarmerId",
                value: new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c6b7e2c2-3f9a-4c27-b6ef-7f70e5bfcf92"),
                column: "FarmerId",
                value: new Guid("1474d237-fe36-4586-ac67-b3ddcf03baac"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c89c1d90-a5d7-4416-9403-e5e1e3e0e217"),
                column: "FarmerId",
                value: new Guid("65c75a94-f3be-4a7a-913e-d6c868876265"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ccf1c98e-5cf4-4bfe-82c7-2a1dfb748e12"),
                column: "FarmerId",
                value: new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d1f7e5a6-2a8d-4c5a-80c7-b8c0b58f2d91"),
                column: "FarmerId",
                value: new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d2109b26-f315-48df-baf9-c1c45746e573"),
                column: "FarmerId",
                value: new Guid("1474d237-fe36-4586-ac67-b3ddcf03baac"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("de3442a5-6a4d-4938-babe-2f3a7a5e9b34"),
                column: "FarmerId",
                value: new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e2ca22b4-f728-4c4f-888b-17463d93d542"),
                column: "FarmerId",
                value: new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fa8ec7af-4cf4-4a28-8c37-5f2d3a1ab5e1"),
                column: "FarmerId",
                value: new Guid("1474d237-fe36-4586-ac67-b3ddcf03baac"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fffb5e9d-4c1e-4e0d-8997-1a7e537a5b89"),
                column: "FarmerId",
                value: new Guid("cd093e1c-e486-4a7f-b92f-94c22f15f7c1"));

            migrationBuilder.CreateIndex(
                name: "IX_Products_FarmerId",
                table: "Products",
                column: "FarmerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Farmers_FarmerId",
                table: "Products",
                column: "FarmerId",
                principalTable: "Farmers",
                principalColumn: "Id");
        }
    }
}
