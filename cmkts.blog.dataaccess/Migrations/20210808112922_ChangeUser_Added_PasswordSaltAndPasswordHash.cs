using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cmkts.blog.dataaccess.Migrations
{
    public partial class ChangeUser_Added_PasswordSaltAndPasswordHash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                schema: "blogging",
                table: "Users",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                schema: "blogging",
                table: "Users",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                schema: "blogging",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                schema: "blogging",
                table: "Users");
        }
    }
}
