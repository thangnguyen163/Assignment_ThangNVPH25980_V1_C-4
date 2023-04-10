using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_ThangNVPH25980.Migrations
{
    public partial class Oute3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Accounts_Id",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_CartDetails_Cart_UserId",
                table: "CartDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cart",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Cart");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cart",
                table: "Cart",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Accounts_UserId",
                table: "Cart",
                column: "UserId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetails_Cart_UserId",
                table: "CartDetails",
                column: "UserId",
                principalTable: "Cart",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Accounts_UserId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_CartDetails_Cart_UserId",
                table: "CartDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cart",
                table: "Cart");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Cart",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cart",
                table: "Cart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Accounts_Id",
                table: "Cart",
                column: "Id",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetails_Cart_UserId",
                table: "CartDetails",
                column: "UserId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
