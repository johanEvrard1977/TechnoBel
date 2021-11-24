using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnoBel.Api.Migrations
{
    public partial class SansDeleteDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updatedate",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Technologie",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updatedate",
                table: "Technologie",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Statut",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updatedate",
                table: "Statut",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Role",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updatedate",
                table: "Role",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Profile",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updatedate",
                table: "Profile",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Langues",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updatedate",
                table: "Langues",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Hobby",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updatedate",
                table: "Hobby",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Filieres",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updatedate",
                table: "Filieres",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Updatedate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Technologie");

            migrationBuilder.DropColumn(
                name: "Updatedate",
                table: "Technologie");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Statut");

            migrationBuilder.DropColumn(
                name: "Updatedate",
                table: "Statut");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "Updatedate",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "Updatedate",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Langues");

            migrationBuilder.DropColumn(
                name: "Updatedate",
                table: "Langues");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Hobby");

            migrationBuilder.DropColumn(
                name: "Updatedate",
                table: "Hobby");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Filieres");

            migrationBuilder.DropColumn(
                name: "Updatedate",
                table: "Filieres");
        }
    }
}
