using Microsoft.EntityFrameworkCore.Migrations;

namespace MerchantFS.DataAccessLayer.Migrations
{
    public partial class Merchant3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Product",
                newName: "Product Name");

            migrationBuilder.AlterColumn<string>(
                name: "Product Name",
                table: "Product",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Product Name",
                table: "Product",
                column: "Product Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product_Product Name",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "Product Name",
                table: "Product",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");
        }
    }
}
