using Microsoft.EntityFrameworkCore.Migrations;

namespace LoiOpdracht.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coach",
                columns: table => new
                {
                    CoachId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true),
                    Voornaam = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coach", x => x.CoachId);
                });

            migrationBuilder.CreateTable(
                name: "Speler",
                columns: table => new
                {
                    SpelerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true),
                    Straatnaam = table.Column<string>(nullable: false),
                    Woonplaats = table.Column<string>(nullable: false),
                    Aktief = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speler", x => x.SpelerId);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true),
                    TeamNaam = table.Column<string>(nullable: true),
                    SoortSport = table.Column<string>(maxLength: 30, nullable: true),
                    CoachId = table.Column<int>(nullable: true),
                    SpelerId = table.Column<int>(nullable: true),
                    Speler2Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Team_Coach_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coach",
                        principalColumn: "CoachId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Team_Speler_Speler2Id",
                        column: x => x.Speler2Id,
                        principalTable: "Speler",
                        principalColumn: "SpelerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Team_Speler_SpelerId",
                        column: x => x.SpelerId,
                        principalTable: "Speler",
                        principalColumn: "SpelerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Coach",
                columns: new[] { "CoachId", "Active", "Naam", "Voornaam" },
                values: new object[,]
                {
                    { 1, true, "Coach1", "S1" },
                    { 2, true, "Coach2", "S2" },
                    { 3, true, "Coach3", "S3" },
                    { 4, true, "Coach4", "S4" }
                });

            migrationBuilder.InsertData(
                table: "Speler",
                columns: new[] { "SpelerId", "Aktief", "Naam", "Straatnaam", "Woonplaats" },
                values: new object[,]
                {
                    { 1, true, "Speler1", "S1", "W1" },
                    { 2, true, "Speler2", "S2", "W2" },
                    { 3, true, "Speler3", "S3", "W3" },
                    { 4, true, "Speler4", "S4", "W4" },
                    { 5, true, "Speler5", "S5", "W5" },
                    { 6, true, "Speler6", "S6", "W6" },
                    { 7, true, "Speler7", "S7", "W7" }
                });

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "TeamId", "CoachId", "Naam", "SoortSport", "Speler2Id", "SpelerId", "TeamNaam" },
                values: new object[,]
                {
                    { 1, 2, "t1", "Tennis", 2, 1, "Team1" },
                    { 2, 2, "t2", "Schaken", 3, 2, "Team2" },
                    { 3, 2, "t3", "Vissen", 4, 3, "Team3" },
                    { 4, 2, "t4", "Hardlopen", 5, 4, "Team4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Team_CoachId",
                table: "Team",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_Speler2Id",
                table: "Team",
                column: "Speler2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Team_SpelerId",
                table: "Team",
                column: "SpelerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Coach");

            migrationBuilder.DropTable(
                name: "Speler");
        }
    }
}
