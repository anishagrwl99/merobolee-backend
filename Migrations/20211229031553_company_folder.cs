using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class company_folder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FolderName",
                schema: "dbo",
                table: "mb_company",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 53, 245, DateTimeKind.Local).AddTicks(2372), new DateTime(2021, 12, 29, 9, 0, 53, 245, DateTimeKind.Local).AddTicks(2400) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 53, 245, DateTimeKind.Local).AddTicks(2434), new DateTime(2021, 12, 29, 9, 0, 53, 245, DateTimeKind.Local).AddTicks(2437) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 53, 245, DateTimeKind.Local).AddTicks(2458), new DateTime(2021, 12, 29, 9, 0, 53, 245, DateTimeKind.Local).AddTicks(2461) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 53, 315, DateTimeKind.Local).AddTicks(3089), new DateTime(2021, 12, 29, 9, 0, 53, 315, DateTimeKind.Local).AddTicks(3113) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 53, 315, DateTimeKind.Local).AddTicks(3126), new DateTime(2021, 12, 29, 9, 0, 53, 315, DateTimeKind.Local).AddTicks(3129) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 53, 315, DateTimeKind.Local).AddTicks(3138), new DateTime(2021, 12, 29, 9, 0, 53, 315, DateTimeKind.Local).AddTicks(3141) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 53, 272, DateTimeKind.Local).AddTicks(3773), new DateTime(2021, 12, 29, 9, 0, 53, 272, DateTimeKind.Local).AddTicks(3824), "MB122129090052655" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 53, 272, DateTimeKind.Local).AddTicks(3958), new DateTime(2021, 12, 29, 9, 0, 53, 272, DateTimeKind.Local).AddTicks(3961), "BI122129090052659" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 0, 53, 272, DateTimeKind.Local).AddTicks(4022), new DateTime(2021, 12, 29, 9, 0, 53, 272, DateTimeKind.Local).AddTicks(4025), "SP122129090052659" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FolderName",
                schema: "dbo",
                table: "mb_company");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 9, 636, DateTimeKind.Local).AddTicks(1806), new DateTime(2021, 12, 26, 21, 43, 9, 636, DateTimeKind.Local).AddTicks(1844) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 9, 636, DateTimeKind.Local).AddTicks(1879), new DateTime(2021, 12, 26, 21, 43, 9, 636, DateTimeKind.Local).AddTicks(1883) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 9, 636, DateTimeKind.Local).AddTicks(1897), new DateTime(2021, 12, 26, 21, 43, 9, 636, DateTimeKind.Local).AddTicks(1900) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 9, 636, DateTimeKind.Local).AddTicks(8204), new DateTime(2021, 12, 26, 21, 43, 9, 636, DateTimeKind.Local).AddTicks(8215) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 9, 636, DateTimeKind.Local).AddTicks(8227), new DateTime(2021, 12, 26, 21, 43, 9, 636, DateTimeKind.Local).AddTicks(8231) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 9, 636, DateTimeKind.Local).AddTicks(8241), new DateTime(2021, 12, 26, 21, 43, 9, 636, DateTimeKind.Local).AddTicks(8245) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 9, 636, DateTimeKind.Local).AddTicks(5752), new DateTime(2021, 12, 26, 21, 43, 9, 636, DateTimeKind.Local).AddTicks(5761), "MB122126214308428" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 9, 636, DateTimeKind.Local).AddTicks(5851), new DateTime(2021, 12, 26, 21, 43, 9, 636, DateTimeKind.Local).AddTicks(5855), "BI122126214308431" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 9, 636, DateTimeKind.Local).AddTicks(5914), new DateTime(2021, 12, 26, 21, 43, 9, 636, DateTimeKind.Local).AddTicks(5918), "SP122126214308431" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(8105), new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(8110) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 426, DateTimeKind.Local).AddTicks(8938), new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(6544) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(6924), new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(6929) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(6931), new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(6932) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(9046), new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(9050) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(9054), new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(9055) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(9056), new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(9057) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(9059), new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(9060) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(9062), new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(9063) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(9064), new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(9065) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(9066), new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(9067) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 428, DateTimeKind.Local).AddTicks(2307), new DateTime(2021, 12, 26, 21, 43, 8, 428, DateTimeKind.Local).AddTicks(2312) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 428, DateTimeKind.Local).AddTicks(2356), new DateTime(2021, 12, 26, 21, 43, 8, 428, DateTimeKind.Local).AddTicks(2358) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 428, DateTimeKind.Local).AddTicks(2359), new DateTime(2021, 12, 26, 21, 43, 8, 428, DateTimeKind.Local).AddTicks(2360) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 432, DateTimeKind.Local).AddTicks(727), new DateTime(2021, 12, 26, 21, 43, 8, 432, DateTimeKind.Local).AddTicks(736) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 435, DateTimeKind.Local).AddTicks(2358), new DateTime(2021, 12, 26, 21, 43, 8, 435, DateTimeKind.Local).AddTicks(2381) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 435, DateTimeKind.Local).AddTicks(2778), new DateTime(2021, 12, 26, 21, 43, 8, 435, DateTimeKind.Local).AddTicks(2780) });
        }
    }
}
