using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StLouisTravel.Data.Migrations
{
    public partial class AddedRegionInLocationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Location",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DetailsLocationViewModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsLocationViewModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeedbackCreateViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rating = table.Column<int>(nullable: false),
                    Review = table.Column<string>(nullable: true),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackCreateViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeedbackListViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rating = table.Column<int>(nullable: false),
                    Review = table.Column<string>(nullable: true),
                    LocationId = table.Column<int>(nullable: false),
                    DetailsLocationViewModelsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackListViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeedbackListViewModel_DetailsLocationViewModels_DetailsLocationViewModelsId",
                        column: x => x.DetailsLocationViewModelsId,
                        principalTable: "DetailsLocationViewModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackListViewModel_DetailsLocationViewModelsId",
                table: "FeedbackListViewModel",
                column: "DetailsLocationViewModelsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedbackCreateViewModel");

            migrationBuilder.DropTable(
                name: "FeedbackListViewModel");

            migrationBuilder.DropTable(
                name: "DetailsLocationViewModels");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Location");
        }
    }
}
