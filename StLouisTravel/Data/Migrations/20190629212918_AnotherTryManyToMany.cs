using Microsoft.EntityFrameworkCore.Migrations;

namespace StLouisTravel.Data.Migrations
{
    public partial class AnotherTryManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Categories",
                nullable: false,
                defaultValue: 0);
        }
    }
}
