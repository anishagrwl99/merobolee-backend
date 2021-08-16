using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class changeinUsertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_experience_doc_mb_user_User_Id",
                table: "mb_experience_doc");

            migrationBuilder.DropIndex(
                name: "IX_mb_experience_doc_User_Id",
                table: "mb_experience_doc");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "mb_experience_doc",
                newName: "user_id");

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "mb_experience_doc",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "mb_experience_doc",
                newName: "User_Id");

            migrationBuilder.AlterColumn<int>(
                name: "User_Id",
                table: "mb_experience_doc",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_mb_experience_doc_User_Id",
                table: "mb_experience_doc",
                column: "User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_experience_doc_mb_user_User_Id",
                table: "mb_experience_doc",
                column: "User_Id",
                principalTable: "mb_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
