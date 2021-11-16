using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class user_profile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                schema: "dbo",
                table: "mb_user",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 888, DateTimeKind.Local).AddTicks(324), new DateTime(2021, 11, 16, 10, 26, 31, 888, DateTimeKind.Local).AddTicks(356) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 888, DateTimeKind.Local).AddTicks(395), new DateTime(2021, 11, 16, 10, 26, 31, 888, DateTimeKind.Local).AddTicks(398) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 888, DateTimeKind.Local).AddTicks(411), new DateTime(2021, 11, 16, 10, 26, 31, 888, DateTimeKind.Local).AddTicks(414) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 939, DateTimeKind.Local).AddTicks(8366), new DateTime(2021, 11, 16, 10, 26, 31, 939, DateTimeKind.Local).AddTicks(8394) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 939, DateTimeKind.Local).AddTicks(8407), new DateTime(2021, 11, 16, 10, 26, 31, 939, DateTimeKind.Local).AddTicks(8411) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 939, DateTimeKind.Local).AddTicks(8420), new DateTime(2021, 11, 16, 10, 26, 31, 939, DateTimeKind.Local).AddTicks(8423) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 902, DateTimeKind.Local).AddTicks(382), new DateTime(2021, 11, 16, 10, 26, 31, 902, DateTimeKind.Local).AddTicks(448), "MB112116102631252" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 902, DateTimeKind.Local).AddTicks(575), new DateTime(2021, 11, 16, 10, 26, 31, 902, DateTimeKind.Local).AddTicks(578), "BI112116102631270" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 902, DateTimeKind.Local).AddTicks(632), new DateTime(2021, 11, 16, 10, 26, 31, 902, DateTimeKind.Local).AddTicks(635), "SP112116102631270" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(8509), new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(8514) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 250, DateTimeKind.Local).AddTicks(8249), new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(6284) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(6766), new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(6771) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(6773), new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(6774) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(9753), new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(9757) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(9761), new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(9762) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(9764), new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(9765) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(9767), new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(9768) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(9769), new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(9770) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(9771), new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(9772) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(9773), new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(9774) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 252, DateTimeKind.Local).AddTicks(4704), new DateTime(2021, 11, 16, 10, 26, 31, 252, DateTimeKind.Local).AddTicks(4710) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 252, DateTimeKind.Local).AddTicks(4714), new DateTime(2021, 11, 16, 10, 26, 31, 252, DateTimeKind.Local).AddTicks(4715) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 252, DateTimeKind.Local).AddTicks(4716), new DateTime(2021, 11, 16, 10, 26, 31, 252, DateTimeKind.Local).AddTicks(4717) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 270, DateTimeKind.Local).AddTicks(6464), new DateTime(2021, 11, 16, 10, 26, 31, 270, DateTimeKind.Local).AddTicks(6471) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 276, DateTimeKind.Local).AddTicks(9065), new DateTime(2021, 11, 16, 10, 26, 31, 276, DateTimeKind.Local).AddTicks(9090) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 276, DateTimeKind.Local).AddTicks(9481), new DateTime(2021, 11, 16, 10, 26, 31, 276, DateTimeKind.Local).AddTicks(9485) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                schema: "dbo",
                table: "mb_user");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 30, 902, DateTimeKind.Local).AddTicks(4412), new DateTime(2021, 11, 12, 16, 49, 30, 902, DateTimeKind.Local).AddTicks(4452) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 30, 902, DateTimeKind.Local).AddTicks(4510), new DateTime(2021, 11, 12, 16, 49, 30, 902, DateTimeKind.Local).AddTicks(4517) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 30, 902, DateTimeKind.Local).AddTicks(4545), new DateTime(2021, 11, 12, 16, 49, 30, 902, DateTimeKind.Local).AddTicks(4551) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 30, 903, DateTimeKind.Local).AddTicks(9157), new DateTime(2021, 11, 12, 16, 49, 30, 903, DateTimeKind.Local).AddTicks(9181) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 30, 903, DateTimeKind.Local).AddTicks(9193), new DateTime(2021, 11, 12, 16, 49, 30, 903, DateTimeKind.Local).AddTicks(9196) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 30, 903, DateTimeKind.Local).AddTicks(9207), new DateTime(2021, 11, 12, 16, 49, 30, 903, DateTimeKind.Local).AddTicks(9210) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 30, 903, DateTimeKind.Local).AddTicks(2095), new DateTime(2021, 11, 12, 16, 49, 30, 903, DateTimeKind.Local).AddTicks(2124), "MB112112164929586" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 30, 903, DateTimeKind.Local).AddTicks(2286), new DateTime(2021, 11, 12, 16, 49, 30, 903, DateTimeKind.Local).AddTicks(2294), "BI112112164929591" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 30, 903, DateTimeKind.Local).AddTicks(2406), new DateTime(2021, 11, 12, 16, 49, 30, 903, DateTimeKind.Local).AddTicks(2412), "SP112112164929591" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 29, 583, DateTimeKind.Local).AddTicks(6822), new DateTime(2021, 11, 12, 16, 49, 29, 583, DateTimeKind.Local).AddTicks(6831) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 29, 581, DateTimeKind.Local).AddTicks(5106), new DateTime(2021, 11, 12, 16, 49, 29, 583, DateTimeKind.Local).AddTicks(1231) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 29, 583, DateTimeKind.Local).AddTicks(2434), new DateTime(2021, 11, 12, 16, 49, 29, 583, DateTimeKind.Local).AddTicks(2441) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 29, 583, DateTimeKind.Local).AddTicks(2444), new DateTime(2021, 11, 12, 16, 49, 29, 583, DateTimeKind.Local).AddTicks(2445) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 29, 584, DateTimeKind.Local).AddTicks(194), new DateTime(2021, 11, 12, 16, 49, 29, 584, DateTimeKind.Local).AddTicks(204) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 29, 584, DateTimeKind.Local).AddTicks(211), new DateTime(2021, 11, 12, 16, 49, 29, 584, DateTimeKind.Local).AddTicks(213) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 29, 584, DateTimeKind.Local).AddTicks(216), new DateTime(2021, 11, 12, 16, 49, 29, 584, DateTimeKind.Local).AddTicks(219) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 29, 584, DateTimeKind.Local).AddTicks(224), new DateTime(2021, 11, 12, 16, 49, 29, 584, DateTimeKind.Local).AddTicks(226) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 29, 584, DateTimeKind.Local).AddTicks(230), new DateTime(2021, 11, 12, 16, 49, 29, 584, DateTimeKind.Local).AddTicks(232) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 29, 584, DateTimeKind.Local).AddTicks(237), new DateTime(2021, 11, 12, 16, 49, 29, 584, DateTimeKind.Local).AddTicks(238) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 29, 584, DateTimeKind.Local).AddTicks(242), new DateTime(2021, 11, 12, 16, 49, 29, 584, DateTimeKind.Local).AddTicks(244) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 29, 585, DateTimeKind.Local).AddTicks(1894), new DateTime(2021, 11, 12, 16, 49, 29, 585, DateTimeKind.Local).AddTicks(1905) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 29, 585, DateTimeKind.Local).AddTicks(1909), new DateTime(2021, 11, 12, 16, 49, 29, 585, DateTimeKind.Local).AddTicks(1911) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 29, 585, DateTimeKind.Local).AddTicks(1913), new DateTime(2021, 11, 12, 16, 49, 29, 585, DateTimeKind.Local).AddTicks(1914) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 29, 591, DateTimeKind.Local).AddTicks(8976), new DateTime(2021, 11, 12, 16, 49, 29, 591, DateTimeKind.Local).AddTicks(8987) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 29, 597, DateTimeKind.Local).AddTicks(3389), new DateTime(2021, 11, 12, 16, 49, 29, 597, DateTimeKind.Local).AddTicks(3415) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 29, 597, DateTimeKind.Local).AddTicks(3876), new DateTime(2021, 11, 12, 16, 49, 29, 597, DateTimeKind.Local).AddTicks(3878) });
        }
    }
}
