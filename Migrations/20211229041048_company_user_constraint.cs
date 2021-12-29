using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class company_user_constraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "email",
                schema: "dbo",
                table: "mb_user",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 47, 534, DateTimeKind.Local).AddTicks(6976), new DateTime(2021, 12, 29, 9, 55, 47, 534, DateTimeKind.Local).AddTicks(7006) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 47, 534, DateTimeKind.Local).AddTicks(7039), new DateTime(2021, 12, 29, 9, 55, 47, 534, DateTimeKind.Local).AddTicks(7043) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 47, 534, DateTimeKind.Local).AddTicks(7056), new DateTime(2021, 12, 29, 9, 55, 47, 534, DateTimeKind.Local).AddTicks(7059) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 47, 590, DateTimeKind.Local).AddTicks(9187), new DateTime(2021, 12, 29, 9, 55, 47, 590, DateTimeKind.Local).AddTicks(9216) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 47, 590, DateTimeKind.Local).AddTicks(9228), new DateTime(2021, 12, 29, 9, 55, 47, 590, DateTimeKind.Local).AddTicks(9231) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 47, 590, DateTimeKind.Local).AddTicks(9240), new DateTime(2021, 12, 29, 9, 55, 47, 590, DateTimeKind.Local).AddTicks(9243) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "FolderName", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 47, 553, DateTimeKind.Local).AddTicks(7170), new DateTime(2021, 12, 29, 9, 55, 47, 553, DateTimeKind.Local).AddTicks(7198), "001M", "MB211229001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "FolderName", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 47, 553, DateTimeKind.Local).AddTicks(7320), new DateTime(2021, 12, 29, 9, 55, 47, 553, DateTimeKind.Local).AddTicks(7324), "002BIC", "BI211229002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "FolderName", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 47, 553, DateTimeKind.Local).AddTicks(7375), new DateTime(2021, 12, 29, 9, 55, 47, 553, DateTimeKind.Local).AddTicks(7378), "003SC", "SP211229003" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(4186), new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(4191) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 964, DateTimeKind.Local).AddTicks(3503), new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(2053) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(2529), new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(2533) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(2535), new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(2536) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(5412), new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(5417) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(5420), new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(5421) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(5422), new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(5423) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(5424), new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(5425) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(5427), new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(5428) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(5429), new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(5430) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(5431), new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(5432) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 966, DateTimeKind.Local).AddTicks(65), new DateTime(2021, 12, 29, 9, 55, 46, 966, DateTimeKind.Local).AddTicks(70) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 966, DateTimeKind.Local).AddTicks(73), new DateTime(2021, 12, 29, 9, 55, 46, 966, DateTimeKind.Local).AddTicks(74) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 966, DateTimeKind.Local).AddTicks(75), new DateTime(2021, 12, 29, 9, 55, 46, 966, DateTimeKind.Local).AddTicks(77) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 970, DateTimeKind.Local).AddTicks(8209), new DateTime(2021, 12, 29, 9, 55, 46, 970, DateTimeKind.Local).AddTicks(8222) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 974, DateTimeKind.Local).AddTicks(9455), new DateTime(2021, 12, 29, 9, 55, 46, 974, DateTimeKind.Local).AddTicks(9485) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 975, DateTimeKind.Local).AddTicks(108), new DateTime(2021, 12, 29, 9, 55, 46, 975, DateTimeKind.Local).AddTicks(112) });

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_email",
                schema: "dbo",
                table: "mb_user",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_mb_company_CompanyEmail",
                schema: "dbo",
                table: "mb_company",
                column: "CompanyEmail",
                unique: true,
                filter: "[CompanyEmail] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_mb_user_email",
                schema: "dbo",
                table: "mb_user");

            migrationBuilder.DropIndex(
                name: "IX_mb_company_CompanyEmail",
                schema: "dbo",
                table: "mb_company");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                schema: "dbo",
                table: "mb_user",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 53, 918, DateTimeKind.Local).AddTicks(8214), new DateTime(2021, 12, 29, 9, 0, 53, 918, DateTimeKind.Local).AddTicks(8278) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 53, 918, DateTimeKind.Local).AddTicks(8309), new DateTime(2021, 12, 29, 9, 0, 53, 918, DateTimeKind.Local).AddTicks(8312) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 53, 918, DateTimeKind.Local).AddTicks(8327), new DateTime(2021, 12, 29, 9, 0, 53, 918, DateTimeKind.Local).AddTicks(8331) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 53, 922, DateTimeKind.Local).AddTicks(2826), new DateTime(2021, 12, 29, 9, 0, 53, 922, DateTimeKind.Local).AddTicks(2838) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 53, 922, DateTimeKind.Local).AddTicks(2906), new DateTime(2021, 12, 29, 9, 0, 53, 922, DateTimeKind.Local).AddTicks(2910) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 53, 922, DateTimeKind.Local).AddTicks(2921), new DateTime(2021, 12, 29, 9, 0, 53, 922, DateTimeKind.Local).AddTicks(2924) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "FolderName", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 53, 921, DateTimeKind.Local).AddTicks(9271), new DateTime(2021, 12, 29, 9, 0, 53, 921, DateTimeKind.Local).AddTicks(9325), null, "MB122129090052655" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "FolderName", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 53, 921, DateTimeKind.Local).AddTicks(9518), new DateTime(2021, 12, 29, 9, 0, 53, 921, DateTimeKind.Local).AddTicks(9522), null, "BI122129090052659" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "FolderName", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 53, 921, DateTimeKind.Local).AddTicks(9587), new DateTime(2021, 12, 29, 9, 0, 53, 921, DateTimeKind.Local).AddTicks(9591), null, "SP122129090052659" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 52, 654, DateTimeKind.Local).AddTicks(9945), new DateTime(2021, 12, 29, 9, 0, 52, 654, DateTimeKind.Local).AddTicks(9951) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 52, 653, DateTimeKind.Local).AddTicks(6242), new DateTime(2021, 12, 29, 9, 0, 52, 654, DateTimeKind.Local).AddTicks(7180) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 52, 654, DateTimeKind.Local).AddTicks(7710), new DateTime(2021, 12, 29, 9, 0, 52, 654, DateTimeKind.Local).AddTicks(7715) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 52, 654, DateTimeKind.Local).AddTicks(7717), new DateTime(2021, 12, 29, 9, 0, 52, 654, DateTimeKind.Local).AddTicks(7719) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 52, 655, DateTimeKind.Local).AddTicks(1218), new DateTime(2021, 12, 29, 9, 0, 52, 655, DateTimeKind.Local).AddTicks(1223) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 52, 655, DateTimeKind.Local).AddTicks(1226), new DateTime(2021, 12, 29, 9, 0, 52, 655, DateTimeKind.Local).AddTicks(1227) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 52, 655, DateTimeKind.Local).AddTicks(1229), new DateTime(2021, 12, 29, 9, 0, 52, 655, DateTimeKind.Local).AddTicks(1230) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 52, 655, DateTimeKind.Local).AddTicks(1231), new DateTime(2021, 12, 29, 9, 0, 52, 655, DateTimeKind.Local).AddTicks(1232) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 52, 655, DateTimeKind.Local).AddTicks(1233), new DateTime(2021, 12, 29, 9, 0, 52, 655, DateTimeKind.Local).AddTicks(1234) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 52, 655, DateTimeKind.Local).AddTicks(1235), new DateTime(2021, 12, 29, 9, 0, 52, 655, DateTimeKind.Local).AddTicks(1236) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 52, 655, DateTimeKind.Local).AddTicks(1238), new DateTime(2021, 12, 29, 9, 0, 52, 655, DateTimeKind.Local).AddTicks(1239) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 52, 655, DateTimeKind.Local).AddTicks(6183), new DateTime(2021, 12, 29, 9, 0, 52, 655, DateTimeKind.Local).AddTicks(6190) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 52, 655, DateTimeKind.Local).AddTicks(6192), new DateTime(2021, 12, 29, 9, 0, 52, 655, DateTimeKind.Local).AddTicks(6193) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 52, 655, DateTimeKind.Local).AddTicks(6194), new DateTime(2021, 12, 29, 9, 0, 52, 655, DateTimeKind.Local).AddTicks(6195) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 52, 659, DateTimeKind.Local).AddTicks(8080), new DateTime(2021, 12, 29, 9, 0, 52, 659, DateTimeKind.Local).AddTicks(8090) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 52, 663, DateTimeKind.Local).AddTicks(1584), new DateTime(2021, 12, 29, 9, 0, 52, 663, DateTimeKind.Local).AddTicks(1612) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 52, 663, DateTimeKind.Local).AddTicks(1969), new DateTime(2021, 12, 29, 9, 0, 52, 663, DateTimeKind.Local).AddTicks(1972) });
        }
    }
}
