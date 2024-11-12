using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameBib.Migrations
{
    /// <inheritdoc />
    public partial class everygameatleastonegenre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 10, 6 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 14, 3 });

            migrationBuilder.UpdateData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 28,
                column: "Description",
                value: "Embark on a Viking adventure.");

            migrationBuilder.InsertData(
                table: "GameGenre",
                columns: new[] { "GameId", "GenreId" },
                values: new object[,]
                {
                    { 15, 3 },
                    { 16, 1 },
                    { 17, 1 },
                    { 17, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 15, 3 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 16, 1 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 17, 1 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 17, 4 });

            migrationBuilder.UpdateData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 28,
                column: "Description",
                value: "Embark on a viking adventure.");

            migrationBuilder.InsertData(
                table: "GameGenre",
                columns: new[] { "GameId", "GenreId" },
                values: new object[,]
                {
                    { 7, 8 },
                    { 9, 1 },
                    { 10, 6 },
                    { 14, 3 }
                });
        }
    }
}
