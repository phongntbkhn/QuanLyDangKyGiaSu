using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TutoringCenter.VN.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewsCategory",
                columns: table => new
                {
                    NCId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    CreateAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    UpdateAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsCategory", x => x.NCId);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    TId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(maxLength: 100, nullable: true),
                    Avatar = table.Column<string>(maxLength: 200, nullable: true),
                    CreateAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    UpdateAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.TId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(maxLength: 100, nullable: true),
                    EncryptPassword = table.Column<string>(maxLength: 200, nullable: true),
                    DisplayName = table.Column<string>(maxLength: 100, nullable: true),
                    Avatar = table.Column<string>(maxLength: 200, nullable: true),
                    Role = table.Column<int>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    UpdateAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UId);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Price = table.Column<float>(nullable: false),
                    LearningTime = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Detail = table.Column<string>(nullable: true),
                    Schedule = table.Column<string>(nullable: true),
                    Image = table.Column<string>(maxLength: 200, nullable: true),
                    CreateAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    UpdateAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CId);
                    table.ForeignKey(
                        name: "FK_Course_Teacher_TId",
                        column: x => x.TId,
                        principalTable: "Teacher",
                        principalColumn: "TId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AboutUs",
                columns: table => new
                {
                    AUId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 200, nullable: true),
                    Content = table.Column<string>(nullable: true),
                    UId = table.Column<int>(nullable: false),
                    Services = table.Column<bool>(nullable: false, defaultValue: false),
                    CreateAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    UpdateAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUs", x => x.AUId);
                    table.ForeignKey(
                        name: "FK_AboutUs_User_UId",
                        column: x => x.UId,
                        principalTable: "User",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    FId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(maxLength: 200, nullable: true),
                    Address = table.Column<string>(maxLength: 200, nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 200, nullable: true),
                    Content = table.Column<string>(nullable: true),
                    ReplyByUserId = table.Column<int>(nullable: true),
                    CreateAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    UpdateAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.FId);
                    table.ForeignKey(
                        name: "FK_Feedback_User_ReplyByUserId",
                        column: x => x.ReplyByUserId,
                        principalTable: "User",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    NId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NCId = table.Column<int>(nullable: false),
                    UId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Tags = table.Column<string>(maxLength: 50, nullable: true),
                    Image = table.Column<string>(maxLength: 200, nullable: true),
                    CreateAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    UpdateAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.NId);
                    table.ForeignKey(
                        name: "FK_News_NewsCategory_NCId",
                        column: x => x.NCId,
                        principalTable: "NewsCategory",
                        principalColumn: "NCId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_News_User_UId",
                        column: x => x.UId,
                        principalTable: "User",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AboutUs_UId",
                table: "AboutUs",
                column: "UId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_TId",
                table: "Course",
                column: "TId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_ReplyByUserId",
                table: "Feedback",
                column: "ReplyByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_News_NCId",
                table: "News",
                column: "NCId");

            migrationBuilder.CreateIndex(
                name: "IX_News_UId",
                table: "News",
                column: "UId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutUs");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "NewsCategory");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
