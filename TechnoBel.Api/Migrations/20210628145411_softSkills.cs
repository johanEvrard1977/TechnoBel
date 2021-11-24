using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnoBel.Api.Migrations
{
    public partial class softSkills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SoftSkills",
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
                    table.PrimaryKey("PK_SoftSkills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSoftSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SoftSkillsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSoftSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSoftSkills_SoftSkills_SoftSkillsId",
                        column: x => x.SoftSkillsId,
                        principalTable: "SoftSkills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSoftSkills_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoftSkills_Name",
                table: "SoftSkills",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSoftSkills_SoftSkillsId",
                table: "UserSoftSkills",
                column: "SoftSkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSoftSkills_UserId",
                table: "UserSoftSkills",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSoftSkills");

            migrationBuilder.DropTable(
                name: "SoftSkills");
        }
    }
}
