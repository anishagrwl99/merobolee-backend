using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class changeinUsertable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_experience_doc_mb_user_UserEntityUser_Id",
                table: "mb_experience_doc");

            migrationBuilder.DropIndex(
                name: "IX_mb_experience_doc_UserEntityUser_Id",
                table: "mb_experience_doc");

            migrationBuilder.DropColumn(
                name: "UserEntityUser_Id",
                table: "mb_experience_doc");

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "mb_experience_doc",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_mb_experience_doc_user_id",
                table: "mb_experience_doc",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_experience_doc_mb_user_user_id",
                table: "mb_experience_doc",
                column: "user_id",
                principalTable: "mb_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_experience_doc_mb_user_user_id",
                table: "mb_experience_doc");

            migrationBuilder.DropIndex(
                name: "IX_mb_experience_doc_user_id",
                table: "mb_experience_doc");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "mb_experience_doc");

            migrationBuilder.AddColumn<int>(
                name: "UserEntityUser_Id",
                table: "mb_experience_doc",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_mb_experience_doc_UserEntityUser_Id",
                table: "mb_experience_doc",
                column: "UserEntityUser_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_experience_doc_mb_user_UserEntityUser_Id",
                table: "mb_experience_doc",
                column: "UserEntityUser_Id",
                principalTable: "mb_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
