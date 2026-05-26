using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRACWEB102.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMontlytask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MontlyTaskName",
                table: "MontlyTasks",
                newName: "TaskStatus");

            migrationBuilder.AddColumn<string>(
                name: "DailyTaskName",
                table: "MontlyTasks",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "EndDate",
                table: "MontlyTasks",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "MontlyTaskCategory",
                table: "MontlyTasks",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "StartDate",
                table: "MontlyTasks",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DailyTaskName",
                table: "MontlyTasks");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "MontlyTasks");

            migrationBuilder.DropColumn(
                name: "MontlyTaskCategory",
                table: "MontlyTasks");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "MontlyTasks");

            migrationBuilder.RenameColumn(
                name: "TaskStatus",
                table: "MontlyTasks",
                newName: "MontlyTaskName");
        }
    }
}
