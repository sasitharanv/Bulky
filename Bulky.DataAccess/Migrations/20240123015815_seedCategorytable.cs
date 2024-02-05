using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BulkyWeb.DataAccess.Migrations
{
	/// <inheritdoc />
	public partial class seedCategorytable : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.InsertData(
				table: "Categories",
				columns: new[] { "Id", "DisplayOrder", "Name" },
				values: new object[,]
				{
					{ 1, 1, "Sasi" },
					{ 2, 1, "Sasi" },
					{ 3, 5, "abi" },
					{ 5, 6, "Sasi" },
					{ 7, 8, "Sasi" }
				});
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "Categories",
				keyColumn: "Id",
				keyValue: 1);

			migrationBuilder.DeleteData(
				table: "Categories",
				keyColumn: "Id",
				keyValue: 2);

			migrationBuilder.DeleteData(
				table: "Categories",
				keyColumn: "Id",
				keyValue: 3);

			migrationBuilder.DeleteData(
				table: "Categories",
				keyColumn: "Id",
				keyValue: 5);

			migrationBuilder.DeleteData(
				table: "Categories",
				keyColumn: "Id",
				keyValue: 7);
		}
	}
}
