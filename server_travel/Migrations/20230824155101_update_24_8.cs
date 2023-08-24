using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace travel_api.Migrations
{
    /// <inheritdoc />
    public partial class update_24_8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "vehicles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "tours",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "restaurants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "resorts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "hotels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_DistrictId",
                table: "vehicles",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_tours_DistrictId",
                table: "tours",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_restaurants_DistrictId",
                table: "restaurants",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_resorts_DistrictId",
                table: "resorts",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_hotels_DistrictId",
                table: "hotels",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_hotels_Districts_DistrictId",
                table: "hotels",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_resorts_Districts_DistrictId",
                table: "resorts",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_restaurants_Districts_DistrictId",
                table: "restaurants",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tours_Districts_DistrictId",
                table: "tours",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicles_Districts_DistrictId",
                table: "vehicles",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hotels_Districts_DistrictId",
                table: "hotels");

            migrationBuilder.DropForeignKey(
                name: "FK_resorts_Districts_DistrictId",
                table: "resorts");

            migrationBuilder.DropForeignKey(
                name: "FK_restaurants_Districts_DistrictId",
                table: "restaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_tours_Districts_DistrictId",
                table: "tours");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicles_Districts_DistrictId",
                table: "vehicles");

            migrationBuilder.DropIndex(
                name: "IX_vehicles_DistrictId",
                table: "vehicles");

            migrationBuilder.DropIndex(
                name: "IX_tours_DistrictId",
                table: "tours");

            migrationBuilder.DropIndex(
                name: "IX_restaurants_DistrictId",
                table: "restaurants");

            migrationBuilder.DropIndex(
                name: "IX_resorts_DistrictId",
                table: "resorts");

            migrationBuilder.DropIndex(
                name: "IX_hotels_DistrictId",
                table: "hotels");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "tours");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "restaurants");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "resorts");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "hotels");
        }
    }
}
