using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace travel_api.Migrations
{
    /// <inheritdoc />
    public partial class DB_district_room : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "touristspots",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "images",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: true),
                    ResortId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "hotels",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Room_resorts_ResortId",
                        column: x => x.ResortId,
                        principalTable: "resorts",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_touristspots_DistrictId",
                table: "touristspots",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_images_DistrictId",
                table: "images",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_images_RoomId",
                table: "images",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_HotelId",
                table: "Room",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_ResortId",
                table: "Room",
                column: "ResortId");

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
                name: "FK_touristspots_District_DistrictId",
                table: "touristspots",
                column: "DistrictId",
                principalTable: "District",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_images_District_DistrictId",
                table: "images");

            migrationBuilder.DropForeignKey(
                name: "FK_images_Room_RoomId",
                table: "images");

            migrationBuilder.DropForeignKey(
                name: "FK_touristspots_District_DistrictId",
                table: "touristspots");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropIndex(
                name: "IX_touristspots_DistrictId",
                table: "touristspots");

            migrationBuilder.DropIndex(
                name: "IX_images_DistrictId",
                table: "images");

            migrationBuilder.DropIndex(
                name: "IX_images_RoomId",
                table: "images");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "touristspots");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "images");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "images");
        }
    }
}
