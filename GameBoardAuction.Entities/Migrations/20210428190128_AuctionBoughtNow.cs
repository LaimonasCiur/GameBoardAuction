using Microsoft.EntityFrameworkCore.Migrations;

namespace GameBoardAuction.Entities.Migrations
{
    public partial class AuctionBoughtNow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BoughtNowBy",
                table: "Auctions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoughtNowBy",
                table: "Auctions");
        }
    }
}
