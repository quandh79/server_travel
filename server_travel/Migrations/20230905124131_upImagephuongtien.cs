using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server_travel.Migrations
{
    /// <inheritdoc />
    public partial class upImagephuongtien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TravelType",
                table: "tours",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_images_VehicleId",
                table: "images",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_images_vehicles_VehicleId",
                table: "images",
                column: "VehicleId",
                principalTable: "vehicles",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_images_vehicles_VehicleId",
                table: "images");

            migrationBuilder.DropIndex(
                name: "IX_images_VehicleId",
                table: "images");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "images");

            migrationBuilder.AlterColumn<string>(
                name: "TravelType",
                table: "tours",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
