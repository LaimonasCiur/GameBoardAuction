using Microsoft.EntityFrameworkCore.Migrations;

namespace GameBoardAuction.Entities.Migrations
{
    public partial class Thread_RecievedBy_IsRead_Fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecievedBy",
                table: "Threads",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecievedBy",
                table: "Threads");
        }
    }
}
