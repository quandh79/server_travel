using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server_travel.Migrations
{
    /// <inheritdoc />
    public partial class upImagephuongtien1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK__vehicles__spotId__571DF1D5",
            //    table: "vehicles");

            //migrationBuilder.RenameColumn(
            //    name: "spotId",
            //    table: "vehicles",
            //    newName: "tourId");

            migrationBuilder.RenameIndex(
                name: "IX_vehicles_spotId",
                table: "vehicles",
                newName: "IX_vehicles_tourId");

            migrationBuilder.AddForeignKey(
                name: "FK__vehicles__tourId__571DF1D5",
                table: "vehicles",
                column: "tourId",
                principalTable: "tours",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__vehicles__spotId__571DF1D5",
                table: "vehicles");

            migrationBuilder.RenameColumn(
                name: "tourId",
                table: "vehicles",
                newName: "spotId");

            migrationBuilder.RenameIndex(
                name: "IX_vehicles_tourId",
                table: "vehicles",
                newName: "IX_vehicles_spotId");

            migrationBuilder.AddForeignKey(
                name: "FK__vehicles__spotId__571DF1D5",
                table: "vehicles",
                column: "spotId",
                principalTable: "touristspots",
                principalColumn: "id");
        }
    }
}
