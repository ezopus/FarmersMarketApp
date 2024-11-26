using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersMarketApp.Infrastructure.Migrations
{
	/// <inheritdoc />
	public partial class RenameColumnOrderStatusToStatus : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.UpdateData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
				columns: new[] { "ConcurrencyStamp", "PasswordHash" },
				values: new object[] { "9842be50-3612-490b-88ec-9eb8492292ef", "AQAAAAIAAYagAAAAEE65PInX14d5QrsI8DRu61KfwFTR+N8NkJejh/u7GNTOi+Xupzt2sJZ+T9Lu5lBp4g==" });

			migrationBuilder.UpdateData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
				columns: new[] { "ConcurrencyStamp", "PasswordHash" },
				values: new object[] { "c2b0b8a2-bb8b-4e67-8840-ec4bf6e859b0", "AQAAAAIAAYagAAAAEOsysVcvsRusC7/oixeoJ6gAYsRaLS3jGSnm/6mOgCmcfQKifiE244warWTpaQZapg==" });

			migrationBuilder.UpdateData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
				columns: new[] { "ConcurrencyStamp", "PasswordHash" },
				values: new object[] { "05944fec-b8c6-4f2b-a784-83a1785c9ab5", "AQAAAAIAAYagAAAAEJ9h3lEPOVPkWbOuJUi8GIbUTHUICKWcn6OIC6qFGWKdlRepwcO6mj1whW36RnWdsA==" });

			migrationBuilder.UpdateData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
				columns: new[] { "ConcurrencyStamp", "PasswordHash" },
				values: new object[] { "322b3bcb-9362-4b5b-82ae-fc52a35f0855", "AQAAAAIAAYagAAAAEIYMHAup4KAdxQgou6B/VsiHj/ybUqDy02/VOquK4YcRPo/drnXJGSBYNOzDNoFSnQ==" });

			migrationBuilder.UpdateData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
				columns: new[] { "ConcurrencyStamp", "PasswordHash" },
				values: new object[] { "ec1a1314-8560-4553-af9f-271d65ebea35", "AQAAAAIAAYagAAAAEFJfQlMqLqh0bI4IhUNQtePpCUDyASm1xS2D6Ogb/I+sPIVi+Jzor1ZbaXsI1vYLeA==" });
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.UpdateData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
				columns: new[] { "ConcurrencyStamp", "PasswordHash" },
				values: new object[] { "59bdfa45-a3a6-40a5-b691-fdaadb7ab5b6", "AQAAAAIAAYagAAAAEK7XBAC9Ie5ozInBZ2IdbjqVSWo5m4xZSs9OxQOsfCqcBZgnTynah1bG+BEQntAqYg==" });

			migrationBuilder.UpdateData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
				columns: new[] { "ConcurrencyStamp", "PasswordHash" },
				values: new object[] { "c9ebe965-cae3-4d94-8170-00e7331166b0", "AQAAAAIAAYagAAAAEMeIxP6v5AFl/NepOjLvge2VtciAbP5pAKkczn+g65aN9+jkyuT/YpP6L7VAB9HO2Q==" });

			migrationBuilder.UpdateData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
				columns: new[] { "ConcurrencyStamp", "PasswordHash" },
				values: new object[] { "95ade39a-77f3-47c9-9bd8-35f2859bfa72", "AQAAAAIAAYagAAAAEH+zaViSqRTAFCfFiWF+drTJT5jcdAlhbWt+Cv1zq2sbnMigPq/BwglN+8+ImkzRIA==" });

			migrationBuilder.UpdateData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
				columns: new[] { "ConcurrencyStamp", "PasswordHash" },
				values: new object[] { "fdfe79d6-aa89-4305-ae22-ce9994c94b25", "AQAAAAIAAYagAAAAEPnIDoA5QoncXXOlrXEP0111BVHnCWMTM/1AJeZ61qRGNoks83DUGsqOPRLsXvmEvQ==" });

			migrationBuilder.UpdateData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
				columns: new[] { "ConcurrencyStamp", "PasswordHash" },
				values: new object[] { "4cfb4ebc-0c07-498c-8a1b-08cd15e50b13", "AQAAAAIAAYagAAAAEJCodQa6IUDuv6x3191rlqRWdSOzgSkR6rODEiueft7SrtyMZtmSC0lnFyGjWljnSA==" });
		}
	}
}
