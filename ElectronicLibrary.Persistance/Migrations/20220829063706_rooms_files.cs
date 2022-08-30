using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronicBookingSystem.Persistance.Migrations
{
    public partial class rooms_files : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_File_DecorationId",
                table: "File");

            migrationBuilder.DropIndex(
                name: "IX_File_EquipmentId",
                table: "File");

            migrationBuilder.DropIndex(
                name: "IX_File_RoomId",
                table: "File");

            migrationBuilder.CreateIndex(
                name: "IX_File_DecorationId",
                table: "File",
                column: "DecorationId");

            migrationBuilder.CreateIndex(
                name: "IX_File_EquipmentId",
                table: "File",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_File_RoomId",
                table: "File",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_File_DecorationId",
                table: "File");

            migrationBuilder.DropIndex(
                name: "IX_File_EquipmentId",
                table: "File");

            migrationBuilder.DropIndex(
                name: "IX_File_RoomId",
                table: "File");

            migrationBuilder.CreateIndex(
                name: "IX_File_DecorationId",
                table: "File",
                column: "DecorationId",
                unique: true,
                filter: "[DecorationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_File_EquipmentId",
                table: "File",
                column: "EquipmentId",
                unique: true,
                filter: "[EquipmentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_File_RoomId",
                table: "File",
                column: "RoomId",
                unique: true,
                filter: "[RoomId] IS NOT NULL");
        }
    }
}
