using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XenoTerra.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReportStory",
                columns: table => new
                {
                    ReportStoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReporterUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportStory", x => x.ReportStoryId);
                    table.ForeignKey(
                        name: "FK_ReportStory_AspNetUsers_ReporterUserId",
                        column: x => x.ReporterUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReportStory_Stories_StoryId",
                        column: x => x.StoryId,
                        principalTable: "Stories",
                        principalColumn: "StoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoryLike",
                columns: table => new
                {
                    StoryLikeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LikedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryLike", x => x.StoryLikeId);
                    table.ForeignKey(
                        name: "FK_StoryLike_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoryLike_Stories_StoryId",
                        column: x => x.StoryId,
                        principalTable: "Stories",
                        principalColumn: "StoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportStory_ReporterUserId",
                table: "ReportStory",
                column: "ReporterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportStory_StoryId",
                table: "ReportStory",
                column: "StoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StoryLike_StoryId",
                table: "StoryLike",
                column: "StoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StoryLike_UserId",
                table: "StoryLike",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportStory");

            migrationBuilder.DropTable(
                name: "StoryLike");
        }
    }
}
