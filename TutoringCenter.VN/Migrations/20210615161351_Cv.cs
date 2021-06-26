using Microsoft.EntityFrameworkCore.Migrations;

namespace TutoringCenter.VN.Migrations
{
    public partial class Cv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cv",
                table: "Teacher",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cv",
                table: "Teacher");
        }
    }
}
