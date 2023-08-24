using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace travel_api.Migrations
{
    /// <inheritdoc />
    public partial class DB_district_roo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_images_District_DistrictId",
                table: "images");

            migrationBuilder.DropForeignKey(
                name: "FK_images_Room_RoomId",
                table: "images");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_hotels_HotelId",
                table: "Room");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_resorts_ResortId",
                table: "Room");

            migrationBuilder.DropForeignKey(
                name: "FK_touristspots_District_DistrictId",
                table: "touristspots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_District",
                table: "District");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "District",
                newName: "Districts");

            migrationBuilder.RenameIndex(
                name: "IX_Room_ResortId",
                table: "Rooms",
                newName: "IX_Rooms_ResortId");

            migrationBuilder.RenameIndex(
                name: "IX_Room_HotelId",
                table: "Rooms",
                newName: "IX_Rooms_HotelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Districts",
                table: "Districts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_images_Districts_DistrictId",
                table: "images",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_images_Rooms_RoomId",
                table: "images",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_hotels_HotelId",
                table: "Rooms",
                column: "HotelId",
                principalTable: "hotels",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_resorts_ResortId",
                table: "Rooms",
                column: "ResortId",
                principalTable: "resorts",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_touristspots_Districts_DistrictId",
                table: "touristspots",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_images_Districts_DistrictId",
                table: "images");

            migrationBuilder.DropForeignKey(
                name: "FK_images_Rooms_RoomId",
                table: "images");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_hotels_HotelId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_resorts_ResortId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_touristspots_Districts_DistrictId",
                table: "touristspots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Districts",
                table: "Districts");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Room");

            migrationBuilder.RenameTable(
                name: "Districts",
                newName: "District");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_ResortId",
                table: "Room",
                newName: "IX_Room_ResortId");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_HotelId",
                table: "Room",
                newName: "IX_Room_HotelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_District",
                table: "District",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_images_District_DistrictId",
                table: "images",
                column: "DistrictId",
                principalTable: "District",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_images_Room_RoomId",
                table: "images",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_hotels_HotelId",
                table: "Room",
                column: "HotelId",
                principalTable: "hotels",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_resorts_ResortId",
                table: "Room",
                column: "ResortId",
                principalTable: "resorts",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_touristspots_District_DistrictId",
                table: "touristspots",
                column: "DistrictId",
                principalTable: "District",
                principalColumn: "Id");
        }
    }
}
