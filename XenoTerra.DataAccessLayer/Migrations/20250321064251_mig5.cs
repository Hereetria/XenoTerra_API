using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XenoTerra.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "BlockUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "BlockUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlockUsers_UserId",
                table: "BlockUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlockUsers_UserId1",
                table: "BlockUsers",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BlockUsers_AspNetUsers_UserId",
                table: "BlockUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlockUsers_AspNetUsers_UserId1",
                table: "BlockUsers",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlockUsers_AspNetUsers_UserId",
                table: "BlockUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_BlockUsers_AspNetUsers_UserId1",
                table: "BlockUsers");

            migrationBuilder.DropIndex(
                name: "IX_BlockUsers_UserId",
                table: "BlockUsers");

            migrationBuilder.DropIndex(
                name: "IX_BlockUsers_UserId1",
                table: "BlockUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BlockUsers");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "BlockUsers");
        }
    }
}
