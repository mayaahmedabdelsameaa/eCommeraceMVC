using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerace.Migrations
{
    public partial class EditshoppingCart1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoopingCartItems_Movies_MovieId",
                table: "ShoopingCartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoopingCartItems",
                table: "ShoopingCartItems");

            migrationBuilder.RenameTable(
                name: "ShoopingCartItems",
                newName: "ShoppingCartItems");

            migrationBuilder.RenameIndex(
                name: "IX_ShoopingCartItems_MovieId",
                table: "ShoppingCartItems",
                newName: "IX_ShoppingCartItems_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartItems",
                table: "ShoppingCartItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Movies_MovieId",
                table: "ShoppingCartItems",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Movies_MovieId",
                table: "ShoppingCartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartItems",
                table: "ShoppingCartItems");

            migrationBuilder.RenameTable(
                name: "ShoppingCartItems",
                newName: "ShoopingCartItems");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItems_MovieId",
                table: "ShoopingCartItems",
                newName: "IX_ShoopingCartItems_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoopingCartItems",
                table: "ShoopingCartItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoopingCartItems_Movies_MovieId",
                table: "ShoopingCartItems",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
