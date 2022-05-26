using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronicLibrary.Persistance.Migrations
{
    public partial class book_updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelivery",
                table: "Borrow",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "BookPiece",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelivery",
                table: "Borrow");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "BookPiece");
        }
    }
}
