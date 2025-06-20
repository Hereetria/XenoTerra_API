using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XenoTerra.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reason",
                table: "ReportPosts");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "ReportComments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "ReportPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "ReportComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
