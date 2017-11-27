using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace entityfraweworkcore1.Migrations
{
    public partial class addingIndexLastNameActor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        //     migrationBuilder.CreateTable(
        //         name: "actor",
        //         columns: table => new
        //         {
        //             actor_id = table.Column<int>(type: "int", nullable: false)
        //                 .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //             first_name = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
        //             last_name = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
        //             last_update = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_actor", x => x.actor_id);
        //         });

        //     migrationBuilder.CreateTable(
        //         name: "category",
        //         columns: table => new
        //         {
        //             category_id = table.Column<byte>(type: "tinyint", nullable: false)
        //                 .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //             last_update = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
        //             name = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_category", x => x.category_id);
        //         });

        //     migrationBuilder.CreateTable(
        //         name: "customer",
        //         columns: table => new
        //         {
        //             customer_id = table.Column<byte>(type: "tinyint", nullable: false)
        //                 .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //             active = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "('Y')"),
        //             create_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
        //             email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //             first_name = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
        //             last_name = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
        //             last_update = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_customer", x => x.customer_id);
        //         });

        //     migrationBuilder.CreateTable(
        //         name: "language",
        //         columns: table => new
        //         {
        //             language_id = table.Column<byte>(type: "tinyint", nullable: false)
        //                 .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //             last_update = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
        //             name = table.Column<string>(type: "char(20)", nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_language", x => x.language_id);
        //         });

        //     migrationBuilder.CreateTable(
        //         name: "staff",
        //         columns: table => new
        //         {
        //             staff_id = table.Column<byte>(type: "tinyint", nullable: false)
        //                 .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //             active = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
        //             email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //             first_name = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
        //             last_name = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
        //             last_update = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
        //             password = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
        //             username = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_staff", x => x.staff_id);
        //         });

        //     migrationBuilder.CreateTable(
        //         name: "film",
        //         columns: table => new
        //         {
        //             film_id = table.Column<int>(type: "int", nullable: false)
        //                 .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //             description = table.Column<string>(type: "text", nullable: true),
        //             language_id = table.Column<byte>(type: "tinyint", nullable: false),
        //             last_update = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
        //             length = table.Column<short>(type: "smallint", nullable: true),
        //             original_language_id = table.Column<byte>(type: "tinyint", nullable: true),
        //             rating = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true, defaultValueSql: "('G')"),
        //             release_year = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true),
        //             title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_film", x => x.film_id);
        //             table.ForeignKey(
        //                 name: "fk_film_language",
        //                 column: x => x.language_id,
        //                 principalTable: "language",
        //                 principalColumn: "language_id",
        //                 onDelete: ReferentialAction.Restrict);
        //             table.ForeignKey(
        //                 name: "fk_film_language_original",
        //                 column: x => x.original_language_id,
        //                 principalTable: "language",
        //                 principalColumn: "language_id",
        //                 onDelete: ReferentialAction.Restrict);
        //         });

        //     migrationBuilder.CreateTable(
        //         name: "film_actor",
        //         columns: table => new
        //         {
        //             actor_id = table.Column<int>(type: "int", nullable: false),
        //             film_id = table.Column<int>(type: "int", nullable: false),
        //             last_update = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_film_actor", x => new { x.actor_id, x.film_id })
        //                 .Annotation("SqlServer:Clustered", false);
        //             table.ForeignKey(
        //                 name: "fk_film_actor_actor",
        //                 column: x => x.actor_id,
        //                 principalTable: "actor",
        //                 principalColumn: "actor_id",
        //                 onDelete: ReferentialAction.Restrict);
        //             table.ForeignKey(
        //                 name: "fk_film_actor_film",
        //                 column: x => x.film_id,
        //                 principalTable: "film",
        //                 principalColumn: "film_id",
        //                 onDelete: ReferentialAction.Restrict);
        //         });

        //     migrationBuilder.CreateTable(
        //         name: "film_category",
        //         columns: table => new
        //         {
        //             film_id = table.Column<int>(type: "int", nullable: false),
        //             category_id = table.Column<byte>(type: "tinyint", nullable: false),
        //             last_update = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_film_category", x => new { x.film_id, x.category_id })
        //                 .Annotation("SqlServer:Clustered", false);
        //             table.ForeignKey(
        //                 name: "fk_film_category_category",
        //                 column: x => x.category_id,
        //                 principalTable: "category",
        //                 principalColumn: "category_id",
        //                 onDelete: ReferentialAction.Restrict);
        //             table.ForeignKey(
        //                 name: "fk_film_category_film",
        //                 column: x => x.film_id,
        //                 principalTable: "film",
        //                 principalColumn: "film_id",
        //                 onDelete: ReferentialAction.Restrict);
        //         });

            migrationBuilder.CreateIndex(
                name: "idx_actor_last_name",
                table: "actor",
                column: "last_name");

        //     migrationBuilder.CreateIndex(
        //         name: "idx_last_name",
        //         table: "customer",
        //         column: "last_name");

        //     migrationBuilder.CreateIndex(
        //         name: "idx_fk_language_id",
        //         table: "film",
        //         column: "language_id");

        //     migrationBuilder.CreateIndex(
        //         name: "idx_fk_original_language_id",
        //         table: "film",
        //         column: "original_language_id");

        //     migrationBuilder.CreateIndex(
        //         name: "idx_fk_film_actor_actor",
        //         table: "film_actor",
        //         column: "actor_id");

        //     migrationBuilder.CreateIndex(
        //         name: "idx_fk_film_actor_film",
        //         table: "film_actor",
        //         column: "film_id");

        //     migrationBuilder.CreateIndex(
        //         name: "idx_fk_film_category_category",
        //         table: "film_category",
        //         column: "category_id");

        //     migrationBuilder.CreateIndex(
        //         name: "idx_fk_film_category_film",
        //         table: "film_category",
        //         column: "film_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "film_actor");

            migrationBuilder.DropTable(
                name: "film_category");

            migrationBuilder.DropTable(
                name: "staff");

            migrationBuilder.DropTable(
                name: "actor");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "film");

            migrationBuilder.DropTable(
                name: "language");
        }
    }
}
