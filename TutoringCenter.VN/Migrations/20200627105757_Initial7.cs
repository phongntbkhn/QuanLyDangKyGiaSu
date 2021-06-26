using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TutoringCenter.VN.Migrations
{
    public partial class Initial7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommonQuestion",
                columns: table => new
                {
                    CQId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    UId = table.Column<int>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    UpdateAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonQuestion", x => x.CQId);
                    table.ForeignKey(
                        name: "FK_CommonQuestion_User_UId",
                        column: x => x.UId,
                        principalTable: "User",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommonQuestion_UId",
                table: "CommonQuestion",
                column: "UId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommonQuestion");
        }
    }
}
