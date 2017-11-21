using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace casadocodigo.Migrations
{
    public partial class addEntityOrderUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "orderUserId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrdersUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_orderUserId",
                table: "Orders",
                column: "orderUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrdersUsers_orderUserId",
                table: "Orders",
                column: "orderUserId",
                principalTable: "OrdersUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrdersUsers_orderUserId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrdersUsers");

            migrationBuilder.DropIndex(
                name: "IX_Orders_orderUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "orderUserId",
                table: "Orders");
        }
    }
}
