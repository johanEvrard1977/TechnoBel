using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnoBel.Api.Migrations
{
    public partial class correctionProfil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Profile_ProfileId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_ProfileId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Image");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Image",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Image_ProfileId",
                table: "Image",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Profile_ProfileId",
                table: "Image",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
