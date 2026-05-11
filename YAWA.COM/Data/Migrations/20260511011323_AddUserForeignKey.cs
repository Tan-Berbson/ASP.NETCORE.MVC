using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YAWA.COM.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LessonPlanners",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonPlanners_UserId",
                table: "LessonPlanners",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonPlanners_AspNetUsers_UserId",
                table: "LessonPlanners",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonPlanners_AspNetUsers_UserId",
                table: "LessonPlanners");

            migrationBuilder.DropIndex(
                name: "IX_LessonPlanners_UserId",
                table: "LessonPlanners");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LessonPlanners",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true);
        }
    }
}
