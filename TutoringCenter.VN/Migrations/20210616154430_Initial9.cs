using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TutoringCenter.VN.Migrations
{
    public partial class Initial9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHocSinh = table.Column<string>(maxLength: 100, nullable: true),
                    SoDienThoai = table.Column<string>(maxLength: 20, nullable: true),
                    Lop = table.Column<string>(maxLength: 20, nullable: true),
                    TenPhuHuynh = table.Column<string>(maxLength: 100, nullable: true),
                    SdtPhuHuynh = table.Column<string>(maxLength: 20, nullable: true),
                    NgaySinh = table.Column<DateTime>(nullable: false),
                    NoiOHienTai = table.Column<string>(maxLength: 300, nullable: true),
                    CreateAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    UpdateAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMonHoc = table.Column<string>(maxLength: 100, nullable: true),
                    Lop = table.Column<string>(maxLength: 20, nullable: true),
                    CreateAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    UpdateAt = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Subject");
        }
    }
}
