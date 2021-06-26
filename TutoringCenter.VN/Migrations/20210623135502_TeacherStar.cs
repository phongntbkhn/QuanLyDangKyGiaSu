using Microsoft.EntityFrameworkCore.Migrations;

namespace TutoringCenter.VN.Migrations
{
    public partial class TeacherStar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdKhoi",
                table: "Course",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdLop",
                table: "Course",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdKhoi",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "IdLop",
                table: "Course");
        }
    }
}
