using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class email_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                schema: "dbo",
                table: "mb_email",
                type: "VARCHAR(300)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR");

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                schema: "dbo",
                table: "mb_email",
                type: "VARCHAR(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 861, DateTimeKind.Local).AddTicks(7501), new DateTime(2021, 11, 1, 16, 22, 18, 861, DateTimeKind.Local).AddTicks(7529) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 861, DateTimeKind.Local).AddTicks(7606), new DateTime(2021, 11, 1, 16, 22, 18, 861, DateTimeKind.Local).AddTicks(7610) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 861, DateTimeKind.Local).AddTicks(7627), new DateTime(2021, 11, 1, 16, 22, 18, 861, DateTimeKind.Local).AddTicks(7630) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 936, DateTimeKind.Local).AddTicks(9898), new DateTime(2021, 11, 1, 16, 22, 18, 936, DateTimeKind.Local).AddTicks(9921) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 936, DateTimeKind.Local).AddTicks(9937), new DateTime(2021, 11, 1, 16, 22, 18, 936, DateTimeKind.Local).AddTicks(9941) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 936, DateTimeKind.Local).AddTicks(9950), new DateTime(2021, 11, 1, 16, 22, 18, 936, DateTimeKind.Local).AddTicks(9953) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 882, DateTimeKind.Local).AddTicks(629), new DateTime(2021, 11, 1, 16, 22, 18, 882, DateTimeKind.Local).AddTicks(660), "SP112101162218090" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(6974), new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(6979) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 86, DateTimeKind.Local).AddTicks(5786), new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(3368) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(4067), new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(4072) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(4074), new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(4075) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(9099), new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(9104) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(9107), new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(9108) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(9110), new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(9111) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(9113), new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(9114) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(9115), new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(9116) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(9117), new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(9118) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(9120), new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(9121) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 89, DateTimeKind.Local).AddTicks(7535), new DateTime(2021, 11, 1, 16, 22, 18, 89, DateTimeKind.Local).AddTicks(7540) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 89, DateTimeKind.Local).AddTicks(7543), new DateTime(2021, 11, 1, 16, 22, 18, 89, DateTimeKind.Local).AddTicks(7544) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 89, DateTimeKind.Local).AddTicks(7546), new DateTime(2021, 11, 1, 16, 22, 18, 89, DateTimeKind.Local).AddTicks(7547) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 99, DateTimeKind.Local).AddTicks(3224), new DateTime(2021, 11, 1, 16, 22, 18, 99, DateTimeKind.Local).AddTicks(3251) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 105, DateTimeKind.Local).AddTicks(3208), new DateTime(2021, 11, 1, 16, 22, 18, 105, DateTimeKind.Local).AddTicks(3231) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 105, DateTimeKind.Local).AddTicks(3573), new DateTime(2021, 11, 1, 16, 22, 18, 105, DateTimeKind.Local).AddTicks(3576) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                schema: "dbo",
                table: "mb_email",
                type: "VARCHAR",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(300)");

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                schema: "dbo",
                table: "mb_email",
                type: "VARCHAR",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(max)");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 21, 712, DateTimeKind.Local).AddTicks(589), new DateTime(2021, 11, 1, 16, 11, 21, 712, DateTimeKind.Local).AddTicks(616) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 21, 712, DateTimeKind.Local).AddTicks(664), new DateTime(2021, 11, 1, 16, 11, 21, 712, DateTimeKind.Local).AddTicks(668) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 21, 712, DateTimeKind.Local).AddTicks(683), new DateTime(2021, 11, 1, 16, 11, 21, 712, DateTimeKind.Local).AddTicks(686) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 21, 712, DateTimeKind.Local).AddTicks(6168), new DateTime(2021, 11, 1, 16, 11, 21, 712, DateTimeKind.Local).AddTicks(6176) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 21, 712, DateTimeKind.Local).AddTicks(6188), new DateTime(2021, 11, 1, 16, 11, 21, 712, DateTimeKind.Local).AddTicks(6191) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 21, 712, DateTimeKind.Local).AddTicks(6201), new DateTime(2021, 11, 1, 16, 11, 21, 712, DateTimeKind.Local).AddTicks(6204) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 21, 712, DateTimeKind.Local).AddTicks(4538), new DateTime(2021, 11, 1, 16, 11, 21, 712, DateTimeKind.Local).AddTicks(4548), "SP112101161120377" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 375, DateTimeKind.Local).AddTicks(8334), new DateTime(2021, 11, 1, 16, 11, 20, 375, DateTimeKind.Local).AddTicks(8339) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 373, DateTimeKind.Local).AddTicks(7307), new DateTime(2021, 11, 1, 16, 11, 20, 375, DateTimeKind.Local).AddTicks(4733) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 375, DateTimeKind.Local).AddTicks(5448), new DateTime(2021, 11, 1, 16, 11, 20, 375, DateTimeKind.Local).AddTicks(5454) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 375, DateTimeKind.Local).AddTicks(5456), new DateTime(2021, 11, 1, 16, 11, 20, 375, DateTimeKind.Local).AddTicks(5457) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(375), new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(380) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(383), new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(385) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(386), new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(387) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(389), new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(390) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(391), new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(392) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(394), new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(395) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(397), new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(398) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(8209), new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(8215) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(8218), new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(8219) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(8220), new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(8221) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 381, DateTimeKind.Local).AddTicks(9677), new DateTime(2021, 11, 1, 16, 11, 20, 381, DateTimeKind.Local).AddTicks(9696) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 387, DateTimeKind.Local).AddTicks(8509), new DateTime(2021, 11, 1, 16, 11, 20, 387, DateTimeKind.Local).AddTicks(8533) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 387, DateTimeKind.Local).AddTicks(9124), new DateTime(2021, 11, 1, 16, 11, 20, 387, DateTimeKind.Local).AddTicks(9127) });
        }
    }
}
