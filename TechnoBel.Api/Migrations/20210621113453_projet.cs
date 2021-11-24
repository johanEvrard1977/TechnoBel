using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnoBel.Api.Migrations
{
    public partial class projet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategorieDeProjets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updatedate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieDeProjets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updatedate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projet_Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjetId = table.Column<int>(type: "int", nullable: false),
                    CategorieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projet_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projet_Categories_CategorieDeProjets_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "CategorieDeProjets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projet_Categories_Projets_ProjetId",
                        column: x => x.ProjetId,
                        principalTable: "Projets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProjets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProjetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProjets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProjets_Projets_ProjetId",
                        column: x => x.ProjetId,
                        principalTable: "Projets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProjets_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategorieDeProjets_Name",
                table: "CategorieDeProjets",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projet_Categories_CategorieId",
                table: "Projet_Categories",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Projet_Categories_ProjetId",
                table: "Projet_Categories",
                column: "ProjetId");

            migrationBuilder.CreateIndex(
                name: "IX_Projets_Name",
                table: "Projets",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProjets_ProjetId",
                table: "UserProjets",
                column: "ProjetId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProjets_UserId",
                table: "UserProjets",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projet_Categories");

            migrationBuilder.DropTable(
                name: "UserProjets");

            migrationBuilder.DropTable(
                name: "CategorieDeProjets");

            migrationBuilder.DropTable(
                name: "Projets");
        }
    }
}
