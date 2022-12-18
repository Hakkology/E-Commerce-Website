using Microsoft.EntityFrameworkCore.Migrations;

namespace MerchantFS.DataAccessLayer.Migrations
{
    public partial class Merchant17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Basket_Product_ProductID",
                table: "Basket");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "Basket",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Basket_ProductID",
                table: "Basket",
                newName: "IX_Basket_ProductId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "435898b1-ae86-46e1-bd8b-23dd3806bfc9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "620518bc-853e-4c52-8cf1-5138e180f710");

            migrationBuilder.AddForeignKey(
                name: "FK_Basket_Product_ProductId",
                table: "Basket",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Basket_Product_ProductId",
                table: "Basket");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Basket",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_Basket_ProductId",
                table: "Basket",
                newName: "IX_Basket_ProductID");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "cef9949d-611c-4f33-86c6-bd38fbc97d00");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "f705841f-0a33-4324-9619-5e7e5ecf1006");

            migrationBuilder.AddForeignKey(
                name: "FK_Basket_Product_ProductID",
                table: "Basket",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
