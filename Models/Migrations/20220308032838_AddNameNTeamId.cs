using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_reference.Models.Migrations
{
    public partial class AddNameNTeamId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameNTeamId",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true,
                computedColumnSql: "cast([TeamId] as varchar(5)) + ' ' + [Name]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameNTeamId",
                table: "Players");
        }
    }
}
