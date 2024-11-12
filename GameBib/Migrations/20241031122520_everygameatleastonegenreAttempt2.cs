using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameBib.Migrations
{
    /// <inheritdoc />
    public partial class everygameatleastonegenreAttempt2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GameGenre",
                columns: new[] { "GameId", "GenreId" },
                values: new object[,]
                {
                    { 18, 4 },
                    { 19, 5 },
                    { 20, 8 },
                    { 21, 1 },
                    { 22, 6 },
                    { 24, 7 },
                    { 25, 7 },
                    { 26, 3 },
                    { 27, 2 },
                    { 28, 8 },
                    { 29, 3 },
                    { 30, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 18, 4 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 19, 5 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 20, 8 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 21, 1 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 22, 6 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 24, 7 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 25, 7 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 26, 3 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 27, 2 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 28, 8 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 29, 3 });

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 30, 4 });
        }
    }
}
