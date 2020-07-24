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
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(nullable: true),
                    Voornaam = table.Column<string>(nullable: false),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
