using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TutoringCenter.VN.Migrations
{
    public partial class Teacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CMND",
                table: "Teacher",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Teacher",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KhuVucGiangDay",
                table: "Teacher",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgaySinh",
                table: "Teacher",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "NoiOHienTai",
                table: "Teacher",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QueQuan",
                table: "Teacher",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoDienThoai",
                table: "Teacher",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CMND",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "KhuVucGiangDay",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "NgaySinh",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "NoiOHienTai",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "QueQuan",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "SoDienThoai",
                table: "Teacher");
        }
    }
}
