using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GalaxyPets.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelsForClosetAndPet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Message",
                table: "ChatMessages",
                newName: "Content");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Pets",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Pets",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Expression",
                table: "Pets",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Items",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "ChatMessages",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "ChatMessages",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Expression",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "ChatMessages");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "ChatMessages",
                newName: "Message");
        }
    }
}
