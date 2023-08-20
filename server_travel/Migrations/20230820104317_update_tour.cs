using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace travel_api.Migrations
{
    /// <inheritdoc />
    public partial class update_tour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TourId",
                table: "images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_images_TourId",
                table: "images",
                column: "TourId");

            migrationBuilder.AddForeignKey(
                name: "FK_images_tours_TourId",
                table: "images",
                column: "TourId",
                principalTable: "tours",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_images_tours_TourId",
                table: "images");

            migrationBuilder.DropIndex(
                name: "IX_images_TourId",
                table: "images");

            migrationBuilder.DropColumn(
                name: "TourId",
                table: "images");
        }
    }
}
