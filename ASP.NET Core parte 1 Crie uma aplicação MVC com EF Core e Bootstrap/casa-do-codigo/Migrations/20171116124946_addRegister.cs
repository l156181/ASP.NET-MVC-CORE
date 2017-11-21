using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace casadocodigo.Migrations
{
    public partial class addRegister : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "OrdersUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "OrdersUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Complement",
                table: "OrdersUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "OrdersUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OrdersUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Neighborhood",
                table: "OrdersUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "OrdersUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UF",
                table: "OrdersUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "OrdersUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "OrdersUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "OrdersUsers");

            migrationBuilder.DropColumn(
                name: "Complement",
                table: "OrdersUsers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "OrdersUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "OrdersUsers");

            migrationBuilder.DropColumn(
                name: "Neighborhood",
                table: "OrdersUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "OrdersUsers");

            migrationBuilder.DropColumn(
                name: "UF",
                table: "OrdersUsers");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "OrdersUsers");
        }
    }
}
