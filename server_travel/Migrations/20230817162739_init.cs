using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace travel_api.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "touristspots",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    location = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tourists__3213E83F0CCAB314", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    birthday = table.Column<DateTime>(type: "date", nullable: true),
                    roleTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    jobTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    token = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    tel = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__users__3213E83FF89A88D3", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hotels",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    spotId = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    location = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    rating = table.Column<int>(type: "int", nullable: true),
                    address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    contactNumber = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__hotels__3213E83F47977C99", x => x.id);
                    table.ForeignKey(
                        name: "FK__hotels__spotId__4E88ABD4",
                        column: x => x.spotId,
                        principalTable: "touristspots",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "resorts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    spotId = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    location = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    cacilities = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    contactNumber = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__resorts__3213E83FCFD0CDD2", x => x.id);
                    table.ForeignKey(
                        name: "FK__resorts__spotId__5441852A",
                        column: x => x.spotId,
                        principalTable: "touristspots",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "restaurants",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    spotId = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    location = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    cuisineType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    contactNumber = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__restaura__3213E83FF2E08E5A", x => x.id);
                    table.ForeignKey(
                        name: "FK__restauran__spotI__5165187F",
                        column: x => x.spotId,
                        principalTable: "touristspots",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tours",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    spotId = table.Column<int>(type: "int", nullable: true),
                    travelDate = table.Column<DateTime>(type: "date", nullable: true),
                    duration = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tours__3213E83FA2BEF46B", x => x.id);
                    table.ForeignKey(
                        name: "FK__tours__spotId__4BAC3F29",
                        column: x => x.spotId,
                        principalTable: "touristspots",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "vehicles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    spotId = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    type = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__vehicles__3213E83F8F7FEB7D", x => x.id);
                    table.ForeignKey(
                        name: "FK__vehicles__spotId__571DF1D5",
                        column: x => x.spotId,
                        principalTable: "touristspots",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    spotId = table.Column<int>(type: "int", nullable: true),
                    hotelId = table.Column<int>(type: "int", nullable: true),
                    resortId = table.Column<int>(type: "int", nullable: true),
                    restaurantId = table.Column<int>(type: "int", nullable: true),
                    imageUrl = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__images__3213E83F79A33295", x => x.id);
                    table.ForeignKey(
                        name: "FK__images__hotelId__5CD6CB2B",
                        column: x => x.hotelId,
                        principalTable: "hotels",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__images__resortId__5DCAEF64",
                        column: x => x.resortId,
                        principalTable: "resorts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__images__restaura__5EBF139D",
                        column: x => x.restaurantId,
                        principalTable: "restaurants",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__images__spotId__5FB337D6",
                        column: x => x.spotId,
                        principalTable: "touristspots",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_hotels_spotId",
                table: "hotels",
                column: "spotId");

            migrationBuilder.CreateIndex(
                name: "IX_images_hotelId",
                table: "images",
                column: "hotelId");

            migrationBuilder.CreateIndex(
                name: "IX_images_resortId",
                table: "images",
                column: "resortId");

            migrationBuilder.CreateIndex(
                name: "IX_images_restaurantId",
                table: "images",
                column: "restaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_images_spotId",
                table: "images",
                column: "spotId");

            migrationBuilder.CreateIndex(
                name: "IX_resorts_spotId",
                table: "resorts",
                column: "spotId");

            migrationBuilder.CreateIndex(
                name: "IX_restaurants_spotId",
                table: "restaurants",
                column: "spotId");

            migrationBuilder.CreateIndex(
                name: "IX_tours_spotId",
                table: "tours",
                column: "spotId");

            migrationBuilder.CreateIndex(
                name: "UQ__users__AB6E616434C83F40",
                table: "users",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_spotId",
                table: "vehicles",
                column: "spotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DropTable(
                name: "tours");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "vehicles");

            migrationBuilder.DropTable(
                name: "hotels");

            migrationBuilder.DropTable(
                name: "resorts");

            migrationBuilder.DropTable(
                name: "restaurants");

            migrationBuilder.DropTable(
                name: "touristspots");
        }
    }
}
