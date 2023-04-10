using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_ThangNVPH25980.Migrations
{
    public partial class Oute2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartDetails_Cart_CartId",
                table: "CartDetails");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "CartDetails",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CartDetails_CartId",
                table: "CartDetails",
                newName: "IX_CartDetails_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetails_Cart_UserId",
                table: "CartDetails",
                column: "UserId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartDetails_Cart_UserId",
                table: "CartDetails");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CartDetails",
                newName: "CartId");

            migrationBuilder.RenameIndex(
                name: "IX_CartDetails_UserId",
                table: "CartDetails",
                newName: "IX_CartDetails_CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetails_Cart_CartId",
                table: "CartDetails",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
