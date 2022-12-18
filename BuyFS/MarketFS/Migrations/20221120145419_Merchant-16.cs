using Microsoft.EntityFrameworkCore.Migrations;

namespace MerchantFS.DataAccessLayer.Migrations
{
    public partial class Merchant16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "367c6633-19e6-44cc-9afc-7892c02b1673");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "b774987d-5568-48a4-be76-530f5ab975bb");
        }
    }
}
