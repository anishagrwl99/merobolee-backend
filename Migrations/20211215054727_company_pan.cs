using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class company_pan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PANNumber",
                schema: "dbo",
                table: "mb_company",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 848, DateTimeKind.Local).AddTicks(2413), new DateTime(2021, 12, 15, 11, 32, 26, 848, DateTimeKind.Local).AddTicks(2455) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 848, DateTimeKind.Local).AddTicks(2492), new DateTime(2021, 12, 15, 11, 32, 26, 848, DateTimeKind.Local).AddTicks(2496) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 848, DateTimeKind.Local).AddTicks(2510), new DateTime(2021, 12, 15, 11, 32, 26, 848, DateTimeKind.Local).AddTicks(2513) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 892, DateTimeKind.Local).AddTicks(4443), new DateTime(2021, 12, 15, 11, 32, 26, 892, DateTimeKind.Local).AddTicks(4467) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 892, DateTimeKind.Local).AddTicks(4480), new DateTime(2021, 12, 15, 11, 32, 26, 892, DateTimeKind.Local).AddTicks(4483) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 892, DateTimeKind.Local).AddTicks(4492), new DateTime(2021, 12, 15, 11, 32, 26, 892, DateTimeKind.Local).AddTicks(4495) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "PANNumber", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 859, DateTimeKind.Local).AddTicks(4153), new DateTime(2021, 12, 15, 11, 32, 26, 859, DateTimeKind.Local).AddTicks(4174), "123", "MB122115113226188" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "PANNumber", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 859, DateTimeKind.Local).AddTicks(4260), new DateTime(2021, 12, 15, 11, 32, 26, 859, DateTimeKind.Local).AddTicks(4263), "1234", "BI122115113226192" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "PANNumber", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 859, DateTimeKind.Local).AddTicks(4314), new DateTime(2021, 12, 15, 11, 32, 26, 859, DateTimeKind.Local).AddTicks(4317), "12345", "SP122115113226192" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(7912), new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(7917) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 186, DateTimeKind.Local).AddTicks(6928), new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(5786) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(6278), new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(6284) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(6286), new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(6287) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(9293), new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(9299) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(9302), new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(9303) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(9305), new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(9306) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(9307), new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(9308) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(9310), new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(9311) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(9312), new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(9313) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(9315), new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(9316) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 188, DateTimeKind.Local).AddTicks(3946), new DateTime(2021, 12, 15, 11, 32, 26, 188, DateTimeKind.Local).AddTicks(3951) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 188, DateTimeKind.Local).AddTicks(3955), new DateTime(2021, 12, 15, 11, 32, 26, 188, DateTimeKind.Local).AddTicks(3956) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 188, DateTimeKind.Local).AddTicks(3957), new DateTime(2021, 12, 15, 11, 32, 26, 188, DateTimeKind.Local).AddTicks(3958) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 192, DateTimeKind.Local).AddTicks(5394), new DateTime(2021, 12, 15, 11, 32, 26, 192, DateTimeKind.Local).AddTicks(5402) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 195, DateTimeKind.Local).AddTicks(7947), new DateTime(2021, 12, 15, 11, 32, 26, 195, DateTimeKind.Local).AddTicks(7960) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 195, DateTimeKind.Local).AddTicks(8440), new DateTime(2021, 12, 15, 11, 32, 26, 195, DateTimeKind.Local).AddTicks(8444) });

            migrationBuilder.CreateIndex(
                name: "IX_mb_company_PANNumber",
                schema: "dbo",
                table: "mb_company",
                column: "PANNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_mb_company_PANNumber",
                schema: "dbo",
                table: "mb_company");

            migrationBuilder.DropColumn(
                name: "PANNumber",
                schema: "dbo",
                table: "mb_company");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 36, 372, DateTimeKind.Local).AddTicks(137), new DateTime(2021, 12, 14, 19, 2, 36, 372, DateTimeKind.Local).AddTicks(167) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 36, 372, DateTimeKind.Local).AddTicks(192), new DateTime(2021, 12, 14, 19, 2, 36, 372, DateTimeKind.Local).AddTicks(195) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 36, 372, DateTimeKind.Local).AddTicks(209), new DateTime(2021, 12, 14, 19, 2, 36, 372, DateTimeKind.Local).AddTicks(213) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 36, 372, DateTimeKind.Local).AddTicks(6097), new DateTime(2021, 12, 14, 19, 2, 36, 372, DateTimeKind.Local).AddTicks(6106) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 36, 372, DateTimeKind.Local).AddTicks(6118), new DateTime(2021, 12, 14, 19, 2, 36, 372, DateTimeKind.Local).AddTicks(6121) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 36, 372, DateTimeKind.Local).AddTicks(6131), new DateTime(2021, 12, 14, 19, 2, 36, 372, DateTimeKind.Local).AddTicks(6134) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 36, 372, DateTimeKind.Local).AddTicks(3465), new DateTime(2021, 12, 14, 19, 2, 36, 372, DateTimeKind.Local).AddTicks(3472), "MB122114190234955" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 36, 372, DateTimeKind.Local).AddTicks(3558), new DateTime(2021, 12, 14, 19, 2, 36, 372, DateTimeKind.Local).AddTicks(3562), "BI122114190234960" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 36, 372, DateTimeKind.Local).AddTicks(3618), new DateTime(2021, 12, 14, 19, 2, 36, 372, DateTimeKind.Local).AddTicks(3621), "SP122114190234960" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(3501), new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(3506) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 951, DateTimeKind.Local).AddTicks(9188), new DateTime(2021, 12, 14, 19, 2, 34, 953, DateTimeKind.Local).AddTicks(9930) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(636), new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(641) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(643), new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(644) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(5518), new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(5524) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(5527), new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(5528) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(5530), new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(5531) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(5532), new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(5533) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(5534), new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(5535) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(5537), new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(5538) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(5539), new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(5540) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 955, DateTimeKind.Local).AddTicks(3155), new DateTime(2021, 12, 14, 19, 2, 34, 955, DateTimeKind.Local).AddTicks(3160) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 955, DateTimeKind.Local).AddTicks(3163), new DateTime(2021, 12, 14, 19, 2, 34, 955, DateTimeKind.Local).AddTicks(3164) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 955, DateTimeKind.Local).AddTicks(3166), new DateTime(2021, 12, 14, 19, 2, 34, 955, DateTimeKind.Local).AddTicks(3167) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 961, DateTimeKind.Local).AddTicks(1213), new DateTime(2021, 12, 14, 19, 2, 34, 961, DateTimeKind.Local).AddTicks(1221) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 966, DateTimeKind.Local).AddTicks(2650), new DateTime(2021, 12, 14, 19, 2, 34, 966, DateTimeKind.Local).AddTicks(2673) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 966, DateTimeKind.Local).AddTicks(3060), new DateTime(2021, 12, 14, 19, 2, 34, 966, DateTimeKind.Local).AddTicks(3064) });
        }
    }
}
