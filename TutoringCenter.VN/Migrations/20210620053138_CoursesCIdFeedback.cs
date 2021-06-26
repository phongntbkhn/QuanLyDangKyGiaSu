using Microsoft.EntityFrameworkCore.Migrations;

namespace TutoringCenter.VN.Migrations
{
    public partial class CoursesCIdFeedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoursesCId",
                table: "Feedback",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_CoursesCId",
                table: "Feedback",
                column: "CoursesCId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Course_CoursesCId",
                table: "Feedback",
                column: "CoursesCId",
                principalTable: "Course",
                principalColumn: "CId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Course_CoursesCId",
                table: "Feedback");

            migrationBuilder.DropIndex(
                name: "IX_Feedback_CoursesCId",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "CoursesCId",
                table: "Feedback");
        }
    }
}
