using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XenoTerra.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_AspNetUsers_UserId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_AspNetUsers_UserId",
                table: "Reactions");

            migrationBuilder.DropIndex(
                name: "IX_UserSettings_UserId",
                table: "UserSettings");

            migrationBuilder.DropIndex(
                name: "IX_Reactions_UserId",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Reactions");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Medias",
                newName: "SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Medias_UserId",
                table: "Medias",
                newName: "IX_Medias_SenderId");

            migrationBuilder.AddColumn<Guid>(
                name: "ReceiverId",
                table: "Medias",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Highlights",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_UserId",
                table: "UserSettings",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medias_ReceiverId",
                table: "Medias",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Highlights_UserId",
                table: "Highlights",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Highlights_AspNetUsers_UserId",
                table: "Highlights",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_AspNetUsers_ReceiverId",
                table: "Medias",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_AspNetUsers_SenderId",
                table: "Medias",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Highlights_AspNetUsers_UserId",
                table: "Highlights");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_AspNetUsers_ReceiverId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_AspNetUsers_SenderId",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_UserSettings_UserId",
                table: "UserSettings");

            migrationBuilder.DropIndex(
                name: "IX_Medias_ReceiverId",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Highlights_UserId",
                table: "Highlights");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Highlights");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "Medias",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Medias_SenderId",
                table: "Medias",
                newName: "IX_Medias_UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Reactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_UserId",
                table: "UserSettings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_UserId",
                table: "Reactions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_AspNetUsers_UserId",
                table: "Medias",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_AspNetUsers_UserId",
                table: "Reactions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
