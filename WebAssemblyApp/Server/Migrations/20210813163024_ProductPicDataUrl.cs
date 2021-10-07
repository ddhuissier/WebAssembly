using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAssemblyApp.Server.Migrations
{
    public partial class ProductPicDataUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductPicDataUrl",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductPicDataUrl",
                table: "Product");
        }
    }
}
