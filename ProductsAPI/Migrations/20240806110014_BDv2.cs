using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsAPI.Migrations
{
    /// <inheritdoc />
    public partial class BDv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "PriceProduct");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "NameProduct");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PriceProduct",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "NameProduct",
                table: "Products",
                newName: "Name");
        }
    }
}
