using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnoBel.Api.Migrations
{
    public partial class filiereTechnologie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FiliereTechonologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FiliereId = table.Column<int>(type: "int", nullable: false),
                    TechnologieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiliereTechonologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FiliereTechonologies_Filieres_FiliereId",
                        column: x => x.FiliereId,
                        principalTable: "Filieres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FiliereTechonologies_Technologie_TechnologieId",
                        column: x => x.TechnologieId,
                        principalTable: "Technologie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FiliereTechonologies_FiliereId",
                table: "FiliereTechonologies",
                column: "FiliereId");

            migrationBuilder.CreateIndex(
                name: "IX_FiliereTechonologies_TechnologieId",
                table: "FiliereTechonologies",
                column: "TechnologieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FiliereTechonologies");
        }
    }
}
