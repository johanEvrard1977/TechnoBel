using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnoBel.Api.Migrations
{
    public partial class projetTechnologie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projet_Technologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjetId = table.Column<int>(type: "int", nullable: false),
                    TechnologieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projet_Technologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projet_Technologies_Projets_ProjetId",
                        column: x => x.ProjetId,
                        principalTable: "Projets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projet_Technologies_Technologie_TechnologieId",
                        column: x => x.TechnologieId,
                        principalTable: "Technologie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projet_Technologies_ProjetId",
                table: "Projet_Technologies",
                column: "ProjetId");

            migrationBuilder.CreateIndex(
                name: "IX_Projet_Technologies_TechnologieId",
                table: "Projet_Technologies",
                column: "TechnologieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projet_Technologies");
        }
    }
}
