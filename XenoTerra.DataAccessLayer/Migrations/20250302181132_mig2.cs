using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XenoTerra.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlockUsers_AspNetUsers_BlockedUserId",
                table: "BlockUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_BlockUsers_AspNetUsers_BlockingUserId",
                table: "BlockUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTag_AspNetUsers_UserId",
                table: "PostTag");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTag_Posts_PostId",
                table: "PostTag");

            migrationBuilder.DropForeignKey(
                name: "FK_SearchHistoryUser_AspNetUsers_UserId",
                table: "SearchHistoryUser");

            migrationBuilder.DropForeignKey(
                name: "FK_SearchHistoryUser_SearchHistories_SearchHistoryId",
                table: "SearchHistoryUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Highlights_HighlightId",
                table: "Stories");

            migrationBuilder.DropIndex(
                name: "IX_Stories_HighlightId",
                table: "Stories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SearchHistoryUser",
                table: "SearchHistoryUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTag",
                table: "PostTag");

            migrationBuilder.DropColumn(
                name: "HighlightId",
                table: "Stories");

            migrationBuilder.RenameTable(
                name: "SearchHistoryUser",
                newName: "SearchHistoryUsers");

            migrationBuilder.RenameTable(
                name: "PostTag",
                newName: "PostTags");

            migrationBuilder.RenameIndex(
                name: "IX_SearchHistoryUser_UserId",
                table: "SearchHistoryUsers",
                newName: "IX_SearchHistoryUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PostTag_UserId",
                table: "PostTags",
                newName: "IX_PostTags_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetRoles",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SearchHistoryUsers",
                table: "SearchHistoryUsers",
                columns: new[] { "SearchHistoryId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTags",
                table: "PostTags",
                columns: new[] { "PostId", "UserId" });

            migrationBuilder.CreateTable(
                name: "HighlightStory",
                columns: table => new
                {
                    HighlightsHighlightId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoriesStoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HighlightStory", x => new { x.HighlightsHighlightId, x.StoriesStoryId });
                    table.ForeignKey(
                        name: "FK_HighlightStory_Highlights_HighlightsHighlightId",
                        column: x => x.HighlightsHighlightId,
                        principalTable: "Highlights",
                        principalColumn: "HighlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HighlightStory_Stories_StoriesStoryId",
                        column: x => x.StoriesStoryId,
                        principalTable: "Stories",
                        principalColumn: "StoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HighlightStory_StoriesStoryId",
                table: "HighlightStory",
                column: "StoriesStoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlockUsers_AspNetUsers_BlockedUserId",
                table: "BlockUsers",
                column: "BlockedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BlockUsers_AspNetUsers_BlockingUserId",
                table: "BlockUsers",
                column: "BlockingUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_AspNetUsers_UserId",
                table: "PostTags",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_Posts_PostId",
                table: "PostTags",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SearchHistoryUsers_AspNetUsers_UserId",
                table: "SearchHistoryUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SearchHistoryUsers_SearchHistories_SearchHistoryId",
                table: "SearchHistoryUsers",
                column: "SearchHistoryId",
                principalTable: "SearchHistories",
                principalColumn: "SearchHistoryId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlockUsers_AspNetUsers_BlockedUserId",
                table: "BlockUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_BlockUsers_AspNetUsers_BlockingUserId",
                table: "BlockUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_AspNetUsers_UserId",
                table: "PostTags");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_Posts_PostId",
                table: "PostTags");

            migrationBuilder.DropForeignKey(
                name: "FK_SearchHistoryUsers_AspNetUsers_UserId",
                table: "SearchHistoryUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_SearchHistoryUsers_SearchHistories_SearchHistoryId",
                table: "SearchHistoryUsers");

            migrationBuilder.DropTable(
                name: "HighlightStory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SearchHistoryUsers",
                table: "SearchHistoryUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTags",
                table: "PostTags");

            migrationBuilder.RenameTable(
                name: "SearchHistoryUsers",
                newName: "SearchHistoryUser");

            migrationBuilder.RenameTable(
                name: "PostTags",
                newName: "PostTag");

            migrationBuilder.RenameIndex(
                name: "IX_SearchHistoryUsers_UserId",
                table: "SearchHistoryUser",
                newName: "IX_SearchHistoryUser_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PostTags_UserId",
                table: "PostTag",
                newName: "IX_PostTag_UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "HighlightId",
                table: "Stories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetRoles",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SearchHistoryUser",
                table: "SearchHistoryUser",
                columns: new[] { "SearchHistoryId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTag",
                table: "PostTag",
                columns: new[] { "PostId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_Stories_HighlightId",
                table: "Stories",
                column: "HighlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlockUsers_AspNetUsers_BlockedUserId",
                table: "BlockUsers",
                column: "BlockedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlockUsers_AspNetUsers_BlockingUserId",
                table: "BlockUsers",
                column: "BlockingUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostTag_AspNetUsers_UserId",
                table: "PostTag",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTag_Posts_PostId",
                table: "PostTag",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SearchHistoryUser_AspNetUsers_UserId",
                table: "SearchHistoryUser",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SearchHistoryUser_SearchHistories_SearchHistoryId",
                table: "SearchHistoryUser",
                column: "SearchHistoryId",
                principalTable: "SearchHistories",
                principalColumn: "SearchHistoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Highlights_HighlightId",
                table: "Stories",
                column: "HighlightId",
                principalTable: "Highlights",
                principalColumn: "HighlightId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
