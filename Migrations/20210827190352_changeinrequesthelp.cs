using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class changeinrequesthelp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "resolve_date",
                table: "mb_request_help",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "mb_request_help",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_mb_request_help_user_id",
                table: "mb_request_help",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_request_help_mb_user_user_id",
                table: "mb_request_help",
                column: "user_id",
                principalTable: "mb_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_request_help_mb_user_user_id",
                table: "mb_request_help");

            migrationBuilder.DropIndex(
                name: "IX_mb_request_help_user_id",
                table: "mb_request_help");

            migrationBuilder.DropColumn(
                name: "resolve_date",
                table: "mb_request_help");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "mb_request_help");
        }
    }
}
