using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class changinginUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_user_mb_category_category_id",
                table: "mb_user");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_user_mb_city_city_id",
                table: "mb_user");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_user_mb_company_type_company_type_Id",
                table: "mb_user");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_user_mb_country_country_id",
                table: "mb_user");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_user_mb_district_district_id",
                table: "mb_user");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_user_mb_membership_membership_Id",
                table: "mb_user");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_user_mb_province_province_id",
                table: "mb_user");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_user_mb_role_role_id",
                table: "mb_user");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_user_mb_user_status_UserStatusStatus_Id",
                table: "mb_user");

            migrationBuilder.RenameColumn(
                name: "UserStatusStatus_Id",
                table: "mb_user",
                newName: "status_id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_user_UserStatusStatus_Id",
                table: "mb_user",
                newName: "IX_mb_user_status_id");

            migrationBuilder.AlterColumn<int>(
                name: "role_id",
                table: "mb_user",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "province_id",
                table: "mb_user",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "membership_Id",
                table: "mb_user",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "district_id",
                table: "mb_user",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "country_id",
                table: "mb_user",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "company_type_Id",
                table: "mb_user",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "city_id",
                table: "mb_user",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "category_id",
                table: "mb_user",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_user_mb_category_category_id",
                table: "mb_user",
                column: "category_id",
                principalTable: "mb_category",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_user_mb_city_city_id",
                table: "mb_user",
                column: "city_id",
                principalTable: "mb_city",
                principalColumn: "city_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_user_mb_company_type_company_type_Id",
                table: "mb_user",
                column: "company_type_Id",
                principalTable: "mb_company_type",
                principalColumn: "company_type_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_user_mb_country_country_id",
                table: "mb_user",
                column: "country_id",
                principalTable: "mb_country",
                principalColumn: "country_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_user_mb_district_district_id",
                table: "mb_user",
                column: "district_id",
                principalTable: "mb_district",
                principalColumn: "district_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_user_mb_membership_membership_Id",
                table: "mb_user",
                column: "membership_Id",
                principalTable: "mb_membership",
                principalColumn: "membership_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_user_mb_province_province_id",
                table: "mb_user",
                column: "province_id",
                principalTable: "mb_province",
                principalColumn: "province_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_user_mb_role_role_id",
                table: "mb_user",
                column: "role_id",
                principalTable: "mb_role",
                principalColumn: "role_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_user_mb_user_status_status_id",
                table: "mb_user",
                column: "status_id",
                principalTable: "mb_user_status",
                principalColumn: "status_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_user_mb_category_category_id",
                table: "mb_user");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_user_mb_city_city_id",
                table: "mb_user");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_user_mb_company_type_company_type_Id",
                table: "mb_user");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_user_mb_country_country_id",
                table: "mb_user");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_user_mb_district_district_id",
                table: "mb_user");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_user_mb_membership_membership_Id",
                table: "mb_user");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_user_mb_province_province_id",
                table: "mb_user");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_user_mb_role_role_id",
                table: "mb_user");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_user_mb_user_status_status_id",
                table: "mb_user");

            migrationBuilder.RenameColumn(
                name: "status_id",
                table: "mb_user",
                newName: "UserStatusStatus_Id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_user_status_id",
                table: "mb_user",
                newName: "IX_mb_user_UserStatusStatus_Id");

            migrationBuilder.AlterColumn<int>(
                name: "role_id",
                table: "mb_user",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "province_id",
                table: "mb_user",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "membership_Id",
                table: "mb_user",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "district_id",
                table: "mb_user",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "country_id",
                table: "mb_user",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "company_type_Id",
                table: "mb_user",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "city_id",
                table: "mb_user",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "category_id",
                table: "mb_user",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_user_mb_category_category_id",
                table: "mb_user",
                column: "category_id",
                principalTable: "mb_category",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_user_mb_city_city_id",
                table: "mb_user",
                column: "city_id",
                principalTable: "mb_city",
                principalColumn: "city_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_user_mb_company_type_company_type_Id",
                table: "mb_user",
                column: "company_type_Id",
                principalTable: "mb_company_type",
                principalColumn: "company_type_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_user_mb_country_country_id",
                table: "mb_user",
                column: "country_id",
                principalTable: "mb_country",
                principalColumn: "country_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_user_mb_district_district_id",
                table: "mb_user",
                column: "district_id",
                principalTable: "mb_district",
                principalColumn: "district_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_user_mb_membership_membership_Id",
                table: "mb_user",
                column: "membership_Id",
                principalTable: "mb_membership",
                principalColumn: "membership_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_user_mb_province_province_id",
                table: "mb_user",
                column: "province_id",
                principalTable: "mb_province",
                principalColumn: "province_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_user_mb_role_role_id",
                table: "mb_user",
                column: "role_id",
                principalTable: "mb_role",
                principalColumn: "role_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_user_mb_user_status_UserStatusStatus_Id",
                table: "mb_user",
                column: "UserStatusStatus_Id",
                principalTable: "mb_user_status",
                principalColumn: "status_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
