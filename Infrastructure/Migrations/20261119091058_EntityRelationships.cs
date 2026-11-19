using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EntityRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "products_category_id_fkey",
                table: "products");

            migrationBuilder.AddForeignKey(
                name: "products_category_id_fkey",
                table: "products",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "products_category_id_fkey",
                table: "products");

            migrationBuilder.AddForeignKey(
                name: "products_category_id_fkey",
                table: "products",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "id");
        }
    }
}
