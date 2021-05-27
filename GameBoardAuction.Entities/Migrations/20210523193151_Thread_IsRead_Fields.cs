using Microsoft.EntityFrameworkCore.Migrations;

namespace GameBoardAuction.Entities.Migrations
{
    public partial class Thread_IsRead_Fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "Threads",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Threads");
        }
    }
}
