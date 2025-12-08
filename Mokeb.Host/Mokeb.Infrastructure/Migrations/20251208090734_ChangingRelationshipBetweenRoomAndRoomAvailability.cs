using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mokeb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangingRelationshipBetweenRoomAndRoomAvailability : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomAvailability",
                table: "RoomAvailability");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomAvailability",
                table: "RoomAvailability",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAvailability_RoomId",
                table: "RoomAvailability",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomAvailability",
                table: "RoomAvailability");

            migrationBuilder.DropIndex(
                name: "IX_RoomAvailability_RoomId",
                table: "RoomAvailability");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomAvailability",
                table: "RoomAvailability",
                columns: new[] { "RoomId", "Id" });
        }
    }
}
