using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmersMarketApp.Infrastructure.Migrations
{
	/// <inheritdoc />
	public partial class ProductQuantityAddedToIndividualProductOrder : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<int>(
				name: "ProductQuantity",
				table: "ProductsOrders",
				type: "int",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AlterColumn<int>(
				name: "Status",
				table: "Orders",
				type: "int",
				nullable: false,
				defaultValue: 0,
				comment: "Status of the current order.",
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true,
				oldComment: "Status of the current order.");

			migrationBuilder.UpdateData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
				columns: new[] { "ConcurrencyStamp", "PasswordHash" },
				values: new object[] { "de66d87f-4946-4a93-a79e-e9b821bbc9bf", "AQAAAAIAAYagAAAAEOMQR1Jp9frEimiV4P0IbzWkZJeHwKgIrfdTcIzUG6FR9E4O84inF3EaKoZROeZpBA==" });

			migrationBuilder.UpdateData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
				columns: new[] { "ConcurrencyStamp", "PasswordHash" },
				values: new object[] { "505817c0-bc00-4c72-b06a-f2957a63524d", "AQAAAAIAAYagAAAAEA92M1E+yqxXTGbKIT4vn8ddE6hx1Ljal0pQIL6vmnEjKxudcgw+uziFdwEbrk7hXw==" });

			migrationBuilder.UpdateData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
				columns: new[] { "ConcurrencyStamp", "PasswordHash" },
				values: new object[] { "758e8918-2497-4bce-870d-fb2abad756cf", "AQAAAAIAAYagAAAAEHbR69cYbJ3i2XKszge/DO9rEvAqBa66GM9m+cCB+kdY43bYR2A4y0JDyWLAyAX4AA==" });

			migrationBuilder.UpdateData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
				columns: new[] { "ConcurrencyStamp", "PasswordHash" },
				values: new object[] { "9df6f28e-d4ed-4f7a-a5bc-5470f15c3f99", "AQAAAAIAAYagAAAAEEVwqCdRujdWSTXKGauLDVg0ebumaPy3PrZwXVvICKZ/ajaTRYlWnei3LbdHR84d7Q==" });

			migrationBuilder.UpdateData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
				columns: new[] { "ConcurrencyStamp", "PasswordHash" },
				values: new object[] { "4be98aeb-c0cc-47c8-90aa-24cd395162fe", "AQAAAAIAAYagAAAAEIoRCo2nEZnvcAzw3ORRqykqqzziGYE1C2Aj8Wrw7BotYCM91QylLQE9uuhSwOTxMQ==" });
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "ProductQuantity",
				table: "ProductsOrders");

			migrationBuilder.AlterColumn<int>(
				name: "Status",
				table: "Orders",
				type: "int",
				nullable: true,
				comment: "Status of the current order.",
				oldClrType: typeof(int),
				oldType: "int",
				oldComment: "Status of the current order.");

			migrationBuilder.UpdateData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("1a03a969-75c2-43fe-9cfd-4bf3c7f71ac2"),
				columns: new[] { "ConcurrencyStamp", "PasswordHash" },
				values: new object[] { "da3a6d33-76a8-45bf-95a5-6206c1ee4f7b", "AQAAAAIAAYagAAAAEAQLmTmqr/XsYADdMw6UYDA1qpVZFOss4gQWMUz1CB91JbXURZT7KbLln8TFS2hrKA==" });

			migrationBuilder.UpdateData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("5510c3c2-99fd-4522-48cd-08dcf84e43e5"),
				columns: new[] { "ConcurrencyStamp", "PasswordHash" },
				values: new object[] { "0123cfa2-aff5-4fae-9b9a-f427bbd30035", "AQAAAAIAAYagAAAAEA13niqLyyxfB/PWlPjkdG6qtMLc/mIYbKOQjxkDr2Vjt4nUCyX5uqV0eL32R+Skyw==" });

			migrationBuilder.UpdateData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("80800dfa-3962-4c0a-b0aa-d46c75ee83f6"),
				columns: new[] { "ConcurrencyStamp", "PasswordHash" },
				values: new object[] { "611738fc-6e37-4163-b2cf-9ed5ff20a1ff", "AQAAAAIAAYagAAAAED1r4J+Lf1fyHmwUDNP5NveyppsSGoSp9JUU7yvYf488fVG1NObD5XsV9YB3s3P8CA==" });

			migrationBuilder.UpdateData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("df1516df-4501-475e-c02a-08dcf857a1b7"),
				columns: new[] { "ConcurrencyStamp", "PasswordHash" },
				values: new object[] { "56caa93c-7544-42fe-ae4f-e6eeaf5a8cb3", "AQAAAAIAAYagAAAAEFJPorSD+G1cIatsJKIaH80/stcoZDjB2z6Sogv5az+AOYy1HHakrKGZhu4boacvIw==" });

			migrationBuilder.UpdateData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: new Guid("e2eca858-9a52-4496-c029-08dcf857a1b7"),
				columns: new[] { "ConcurrencyStamp", "PasswordHash" },
				values: new object[] { "0a621b63-3614-4696-a8a4-d59d71135646", "AQAAAAIAAYagAAAAEERpZ3SE/9dyMdcLAHHZKlkzXz2AYmgpnbt5OTl7HpIN4vC32fB+xhHrlz74GhEWYg==" });
		}
	}
}
