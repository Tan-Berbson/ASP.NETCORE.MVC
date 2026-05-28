using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRACWEB102.Migrations
{
    /// <inheritdoc />
    public partial class lessonplandb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LessonStatus",
                table: "LessonPlanners",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LessonStatus",
                table: "LessonPlanners");
        }
    }
}
