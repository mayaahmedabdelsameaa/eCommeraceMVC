using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerace.Migrations
{
    public partial class editMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MovieCatogory",
                table: "Movies",
                newName: "MovieCategory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MovieCategory",
                table: "Movies",
                newName: "MovieCatogory");
        }
    }
}
