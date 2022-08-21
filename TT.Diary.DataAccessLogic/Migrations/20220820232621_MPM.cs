using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TT.Diary.DataAccessLogic.Migrations
{
    public partial class MPM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PriorityModifyDateTime",
                table: "WishList",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PriorityModifyDateTime",
                table: "ToDoList",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PriorityModifyDateTime",
                table: "Habits",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PriorityModifyDateTime",
                table: "Appointments",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriorityModifyDateTime",
                table: "WishList");

            migrationBuilder.DropColumn(
                name: "PriorityModifyDateTime",
                table: "ToDoList");

            migrationBuilder.DropColumn(
                name: "PriorityModifyDateTime",
                table: "Habits");

            migrationBuilder.DropColumn(
                name: "PriorityModifyDateTime",
                table: "Appointments");
        }
    }
}
