using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StLouisTravel.Data.Migrations
{
    public partial class TryManyToManyAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Location_LocationId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_LocationId",
                table: "Categories");

            migrationBuilder.CreateTable(
                name: "CategoryLocations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryLocations_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryLocations_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryLocations_CategoryId",
                table: "CategoryLocations",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryLocations_LocationId",
                table: "CategoryLocations",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryLocations");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_LocationId",
                table: "Categories",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Location_LocationId",
                table: "Categories",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
