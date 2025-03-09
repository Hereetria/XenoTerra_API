using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XenoTerra.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HighlightStory");

            migrationBuilder.DropColumn(
                name: "StoryId",
                table: "Highlights");

            migrationBuilder.CreateTable(
                name: "StoryHighlights",
                columns: table => new
                {
                    StoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HighlightId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryHighlights", x => new { x.StoryId, x.HighlightId });
                    table.ForeignKey(
                        name: "FK_StoryHighlights_Highlights_HighlightId",
                        column: x => x.HighlightId,
                        principalTable: "Highlights",
                        principalColumn: "HighlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoryHighlights_Stories_StoryId",
                        column: x => x.StoryId,
                        principalTable: "Stories",
                        principalColumn: "StoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoryHighlights_HighlightId",
                table: "StoryHighlights",
                column: "HighlightId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoryHighlights");

            migrationBuilder.AddColumn<Guid>(
                name: "StoryId",
                table: "Highlights",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
        }
    }
}
