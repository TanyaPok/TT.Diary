using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TT.Diary.DataAccessLogic.Migrations
{
    public partial class MPM_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PriorityModifyDateTime",
                table: "WishList",
                newName: "PriorityModifyDateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "PriorityModifyDateTime",
                table: "ToDoList",
                newName: "PriorityModifyDateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "PriorityModifyDateTime",
                table: "Habits",
                newName: "PriorityModifyDateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "PriorityModifyDateTime",
                table: "Appointments",
                newName: "PriorityModifyDateTimeUtc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PriorityModifyDateTimeUtc",
                table: "WishList",
                newName: "PriorityModifyDateTime");

            migrationBuilder.RenameColumn(
                name: "PriorityModifyDateTimeUtc",
                table: "ToDoList",
                newName: "PriorityModifyDateTime");

            migrationBuilder.RenameColumn(
                name: "PriorityModifyDateTimeUtc",
                table: "Habits",
                newName: "PriorityModifyDateTime");

            migrationBuilder.RenameColumn(
                name: "PriorityModifyDateTimeUtc",
                table: "Appointments",
                newName: "PriorityModifyDateTime");
        }
    }
}
