using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameBib.Migrations
{
    /// <inheritdoc />
    public partial class everygameatleastonegenreAttempt3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GameGenre",
                columns: new[] { "GameId", "GenreId" },
                values: new object[] { 23, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 23, 1 });
        }
    }
}
