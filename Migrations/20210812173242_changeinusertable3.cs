using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class changeinusertable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_user_mb_municipality_municipality_id",
                table: "mb_user");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_user_mb_vdc_vdc_id",
                table: "mb_user");

            migrationBuilder.AlterColumn<int>(
                name: "vdc_id",
                table: "mb_user",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "municipality_id",
                table: "mb_user",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_user_mb_municipality_municipality_id",
                table: "mb_user",
                column: "municipality_id",
                principalTable: "mb_municipality",
                principalColumn: "municipality_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_user_mb_vdc_vdc_id",
                table: "mb_user",
                column: "vdc_id",
                principalTable: "mb_vdc",
                principalColumn: "vdc_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_user_mb_municipality_municipality_id",
                table: "mb_user");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_user_mb_vdc_vdc_id",
                table: "mb_user");

            migrationBuilder.AlterColumn<int>(
                name: "vdc_id",
                table: "mb_user",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "municipality_id",
                table: "mb_user",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_user_mb_municipality_municipality_id",
                table: "mb_user",
                column: "municipality_id",
                principalTable: "mb_municipality",
                principalColumn: "municipality_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_user_mb_vdc_vdc_id",
                table: "mb_user",
                column: "vdc_id",
                principalTable: "mb_vdc",
                principalColumn: "vdc_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
