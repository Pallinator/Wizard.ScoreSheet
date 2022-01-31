using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wizard.ScoreSheet.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentScore = table.Column<int>(type: "int", nullable: false),
                    PlayerTurn = table.Column<bool>(type: "bit", nullable: false),
                    CurrentBid = table.Column<int>(type: "int", nullable: false),
                    Dealer = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Round",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bid = table.Column<int>(type: "int", nullable: false),
                    Tricks = table.Column<int>(type: "int", nullable: false),
                    RoundNumber = table.Column<int>(type: "int", nullable: false),
                    PlayerModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Round", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Round_PlayerModel_PlayerModelId",
                        column: x => x.PlayerModelId,
                        principalTable: "PlayerModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Round_PlayerModelId",
                table: "Round",
                column: "PlayerModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Round");

            migrationBuilder.DropTable(
                name: "PlayerModel");
        }
    }
}
