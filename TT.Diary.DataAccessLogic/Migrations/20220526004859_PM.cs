using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TT.Diary.DataAccessLogic.Migrations
{
    public partial class PM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "WishList",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "ToDoList",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Habits",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Appointments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "WishList");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "ToDoList");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Habits");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Appointments");
        }
    }
}
