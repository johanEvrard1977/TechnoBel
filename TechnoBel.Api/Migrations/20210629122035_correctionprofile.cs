using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnoBel.Api.Migrations
{
    public partial class correctionprofile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Profile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProfileTechnologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    TechnologieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileTechnologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileTechnologies_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileTechnologies_Technologie_TechnologieId",
                        column: x => x.TechnologieId,
                        principalTable: "Technologie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileTechnologies_ProfileId",
                table: "ProfileTechnologies",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileTechnologies_TechnologieId",
                table: "ProfileTechnologies",
                column: "TechnologieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileTechnologies");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Profile");
        }
    }
}
