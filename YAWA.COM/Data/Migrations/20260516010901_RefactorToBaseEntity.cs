using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YAWA.COM.Data.Migrations
{
    /// <inheritdoc />
    public partial class RefactorToBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LessonId",
                table: "LessonPlanners",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "Ipons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectIponName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProjectDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IponTotalCost = table.Column<double>(type: "float", nullable: false),
                    IponNameName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IponAdd = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ipons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ipons_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MontlyTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MontlyTaskName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MontlyTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MontlyTasks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ipons_UserId",
                table: "Ipons",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MontlyTasks_UserId",
                table: "MontlyTasks",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ipons");

            migrationBuilder.DropTable(
                name: "MontlyTasks");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LessonPlanners",
                newName: "LessonId");
        }
    }
}
