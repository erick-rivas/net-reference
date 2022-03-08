using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_reference.Models.Migrations
{
    public partial class AddNameNIdToPlayers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NameNId",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true,
                computedColumnSql: "cast([Id] as varchar(5)) + ' ' + [Name]",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NameNId",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComputedColumnSql: "cast([Id] as varchar(5)) + ' ' + [Name]");
        }
    }
}
