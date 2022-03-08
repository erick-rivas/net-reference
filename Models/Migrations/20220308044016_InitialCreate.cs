using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_reference.Models.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerPositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    MarketValue = table.Column<int>(type: "int", nullable: false),
                    RivalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Teams_RivalId",
                        column: x => x.RivalId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    PlayerPositionId = table.Column<int>(type: "int", nullable: false),
                    NameNId = table.Column<string>(type: "nvarchar(max)", nullable: true, computedColumnSql: "cast([Id] as varchar(5)) + ' ' + [Name]"),
                    NameNTeamId = table.Column<string>(type: "nvarchar(max)", nullable: true, computedColumnSql: "cast([TeamId] as varchar(5)) + ' ' + [Name]"),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_PlayerPositions_PlayerPositionId",
                        column: x => x.PlayerPositionId,
                        principalTable: "PlayerPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PlayerPositions",
                columns: new[] { "Id", "Details", "Name" },
                values: new object[] { 1, "", "Left Wing" });

            migrationBuilder.InsertData(
                table: "PlayerPositions",
                columns: new[] { "Id", "Details", "Name" },
                values: new object[] { 2, "", "Striker" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Description", "MarketValue", "Name", "RivalId" },
                values: new object[] { 1, "El mejor equipo del mundo", 100000, "Real Madrid", null });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Discriminator", "IsActive", "Name", "PlayerPositionId", "TeamId" },
                values: new object[] { 1, "Player", true, "Vinicius JR", 1, 1 });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Description", "MarketValue", "Name", "RivalId" },
                values: new object[] { 2, "Podría ser mejor", 100, "Barcelona", 1 });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Discriminator", "IsActive", "Name", "PlayerPositionId", "TeamId" },
                values: new object[] { 2, "Player", true, "Pedri", 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayerPositionId",
                table: "Players",
                column: "PlayerPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_RivalId",
                table: "Teams",
                column: "RivalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "PlayerPositions");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
