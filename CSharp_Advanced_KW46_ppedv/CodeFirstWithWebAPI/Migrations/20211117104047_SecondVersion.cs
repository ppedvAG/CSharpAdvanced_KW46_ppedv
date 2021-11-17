using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstWithWebAPI.Migrations
{
    public partial class SecondVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "IMDBRating",
                table: "Movies",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IMDBRating",
                table: "Movies");
        }
    }
}
