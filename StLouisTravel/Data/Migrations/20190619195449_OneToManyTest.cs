using Microsoft.EntityFrameworkCore.Migrations;

namespace StLouisTravel.Data.Migrations
{
    public partial class OneToManyTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationName",
                table: "Feedbacks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LocationName",
                table: "Feedbacks",
                nullable: true);
        }
    }
}
