using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameBib.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rating = table.Column<float>(type: "float", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GameGenre",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGenre", x => new { x.GameId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_GameGenre_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGenre_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "Description", "Name", "Rating", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, "Journey above the clouds.", "Sky Quest", 4.5f, new DateTime(2021, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Explore a mystical forest.", "Mystic Forest", 4.3f, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Space exploration game.", "Galactic Adventure", 4.7f, new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Deep dive into dungeons.", "Dungeon Crawl", 4f, new DateTime(2020, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Epic fantasy MMORPG.", "World of Warcraft", 4.8f, new DateTime(2004, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Fantasy RPG with dragons.", "The Elder Scrolls V: Skyrim", 4.9f, new DateTime(2011, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Open-world adventure.", "Zelda: Breath of the Wild", 4.9f, new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Ancient mysteries await.", "Mystic Ruins", 4.2f, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Underwater exploration.", "Ocean Explorer", 4f, new DateTime(2018, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Build and manage a city.", "City Builder", 4.3f, new DateTime(2019, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "Strategic space battles.", "Space Commander", 4.1f, new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "Manage your farm.", "Farm Life", 4.4f, new DateTime(2020, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "Challenging puzzle game.", "Puzzle Quest", 4.2f, new DateTime(2021, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "Survive in the desert.", "Desert Survival", 3.8f, new DateTime(2018, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "Defend the castle.", "Castle Defender", 4f, new DateTime(2019, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, "Adventure in the jungle.", "Jungle Hunt", 3.9f, new DateTime(2017, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "Protect the galaxy.", "Galaxy Rangers", 4.5f, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, "Futuristic city RPG.", "Cyber City", 4.1f, new DateTime(2019, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, "Conquer the peaks.", "Mountain Climber", 3.8f, new DateTime(2021, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, "Sail the seas as a pirate.", "Pirate Seas", 4.2f, new DateTime(2021, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, "Explore a haunted mansion.", "Haunted Mansion", 3.7f, new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, "Survive on a deserted island.", "Island Escape", 4.3f, new DateTime(2018, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, "Intense PvP battles.", "Battle Arena", 4.2f, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, "Journey through space.", "Space Odyssey", 4.6f, new DateTime(2017, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, "Strategy game set in medieval times.", "Medieval Conquest", 4f, new DateTime(2019, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, "Lead a robot rebellion.", "Robot Revolution", 4.1f, new DateTime(2020, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, "Adventure with dragons.", "Dragon Kingdom", 4.7f, new DateTime(2018, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, "Embark on a viking adventure.", "Viking Quest", 4.5f, new DateTime(2017, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, "Defend Earth from aliens.", "Alien Invasion", 3.9f, new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, "Command your empire to victory.", "War of Empires", 4.6f, new DateTime(2020, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Adventure" },
                    { 2, "RPG" },
                    { 3, "Action" },
                    { 4, "Strategy" },
                    { 5, "Puzzle" },
                    { 6, "Simulation" },
                    { 7, "MMORPG" },
                    { 8, "Fantasy" }
                });

            migrationBuilder.InsertData(
                table: "GameGenre",
                columns: new[] { "GameId", "GenreId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 3 },
                    { 3, 1 },
                    { 3, 4 },
                    { 4, 2 },
                    { 4, 3 },
                    { 5, 7 },
                    { 5, 8 },
                    { 6, 2 },
                    { 6, 8 },
                    { 7, 1 },
                    { 7, 8 },
                    { 8, 1 },
                    { 9, 1 },
                    { 9, 6 },
                    { 10, 4 },
                    { 10, 6 },
                    { 11, 4 },
                    { 12, 6 },
                    { 13, 5 },
                    { 14, 1 },
                    { 14, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameGenre_GenreId",
                table: "GameGenre",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameGenre");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
