using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YAWA.COM.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LessonPlanners",
                columns: table => new
                {
                    LessonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LessonTittle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LessonName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LessonDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonPlanners", x => x.LessonId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonPlanners");
        }
    }
}
