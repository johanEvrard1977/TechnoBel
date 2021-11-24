using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnoBel.Api.Migrations
{
    public partial class curriculum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurriculumVitaeId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CurriculumVitaes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    File = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    MimeType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurriculumVitaes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_CurriculumVitaeId",
                table: "User",
                column: "CurriculumVitaeId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_CurriculumVitaes_CurriculumVitaeId",
                table: "User",
                column: "CurriculumVitaeId",
                principalTable: "CurriculumVitaes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_CurriculumVitaes_CurriculumVitaeId",
                table: "User");

            migrationBuilder.DropTable(
                name: "CurriculumVitaes");

            migrationBuilder.DropIndex(
                name: "IX_User_CurriculumVitaeId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CurriculumVitaeId",
                table: "User");
        }
    }
}
