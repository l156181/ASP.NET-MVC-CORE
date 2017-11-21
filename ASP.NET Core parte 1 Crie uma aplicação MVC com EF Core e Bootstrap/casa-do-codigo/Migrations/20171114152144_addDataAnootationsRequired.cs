using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace casadocodigo.Migrations
{
    public partial class addDataAnootationsRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrdersUsers_orderUserId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "orderUserId",
                table: "Orders",
                newName: "OrderUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_orderUserId",
                table: "Orders",
                newName: "IX_Orders_OrderUserId");

            migrationBuilder.AlterColumn<int>(
                name: "OrderUserId",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrdersUsers_OrderUserId",
                table: "Orders",
                column: "OrderUserId",
                principalTable: "OrdersUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrdersUsers_OrderUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrderUserId",
                table: "Orders",
                newName: "orderUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_OrderUserId",
                table: "Orders",
                newName: "IX_Orders_orderUserId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "orderUserId",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrdersUsers_orderUserId",
                table: "Orders",
                column: "orderUserId",
                principalTable: "OrdersUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
