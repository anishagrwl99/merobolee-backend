using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class tendersubmission_rowno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RowNo",
                schema: "dbo",
                table: "mb_TenderSubmissionProductSpec",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RowNo",
                schema: "dbo",
                table: "mb_TenderSubmissionPriceSchedule",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 49, 13, DateTimeKind.Local).AddTicks(2938), new DateTime(2021, 12, 10, 9, 5, 49, 13, DateTimeKind.Local).AddTicks(2971) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 49, 13, DateTimeKind.Local).AddTicks(3002), new DateTime(2021, 12, 10, 9, 5, 49, 13, DateTimeKind.Local).AddTicks(3005) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 49, 13, DateTimeKind.Local).AddTicks(3019), new DateTime(2021, 12, 10, 9, 5, 49, 13, DateTimeKind.Local).AddTicks(3021) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 49, 60, DateTimeKind.Local).AddTicks(5137), new DateTime(2021, 12, 10, 9, 5, 49, 60, DateTimeKind.Local).AddTicks(5164) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 49, 60, DateTimeKind.Local).AddTicks(5176), new DateTime(2021, 12, 10, 9, 5, 49, 60, DateTimeKind.Local).AddTicks(5179) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 49, 60, DateTimeKind.Local).AddTicks(5189), new DateTime(2021, 12, 10, 9, 5, 49, 60, DateTimeKind.Local).AddTicks(5191) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 49, 25, DateTimeKind.Local).AddTicks(6544), new DateTime(2021, 12, 10, 9, 5, 49, 25, DateTimeKind.Local).AddTicks(6569), "MB122110090548311" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 49, 25, DateTimeKind.Local).AddTicks(6656), new DateTime(2021, 12, 10, 9, 5, 49, 25, DateTimeKind.Local).AddTicks(6659), "BI122110090548315" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 49, 25, DateTimeKind.Local).AddTicks(6708), new DateTime(2021, 12, 10, 9, 5, 49, 25, DateTimeKind.Local).AddTicks(6711), "SP122110090548315" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(4670), new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(4675) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 309, DateTimeKind.Local).AddTicks(3139), new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(2347) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(2839), new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(2844) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(2848), new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(2849) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(5906), new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(5910) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(5914), new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(5915) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(5917), new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(5918) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(5921), new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(5922) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(5923), new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(5924) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(5925), new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(5926) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(5928), new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(5929) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 311, DateTimeKind.Local).AddTicks(820), new DateTime(2021, 12, 10, 9, 5, 48, 311, DateTimeKind.Local).AddTicks(826) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 311, DateTimeKind.Local).AddTicks(828), new DateTime(2021, 12, 10, 9, 5, 48, 311, DateTimeKind.Local).AddTicks(829) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 311, DateTimeKind.Local).AddTicks(832), new DateTime(2021, 12, 10, 9, 5, 48, 311, DateTimeKind.Local).AddTicks(833) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 315, DateTimeKind.Local).AddTicks(3956), new DateTime(2021, 12, 10, 9, 5, 48, 315, DateTimeKind.Local).AddTicks(3966) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 319, DateTimeKind.Local).AddTicks(2249), new DateTime(2021, 12, 10, 9, 5, 48, 319, DateTimeKind.Local).AddTicks(2274) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 319, DateTimeKind.Local).AddTicks(2789), new DateTime(2021, 12, 10, 9, 5, 48, 319, DateTimeKind.Local).AddTicks(2792) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowNo",
                schema: "dbo",
                table: "mb_TenderSubmissionProductSpec");

            migrationBuilder.DropColumn(
                name: "RowNo",
                schema: "dbo",
                table: "mb_TenderSubmissionPriceSchedule");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 5, 708, DateTimeKind.Local).AddTicks(757), new DateTime(2021, 12, 8, 22, 2, 5, 708, DateTimeKind.Local).AddTicks(792) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 5, 708, DateTimeKind.Local).AddTicks(817), new DateTime(2021, 12, 8, 22, 2, 5, 708, DateTimeKind.Local).AddTicks(820) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 5, 708, DateTimeKind.Local).AddTicks(834), new DateTime(2021, 12, 8, 22, 2, 5, 708, DateTimeKind.Local).AddTicks(837) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 5, 708, DateTimeKind.Local).AddTicks(6268), new DateTime(2021, 12, 8, 22, 2, 5, 708, DateTimeKind.Local).AddTicks(6276) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 5, 708, DateTimeKind.Local).AddTicks(6288), new DateTime(2021, 12, 8, 22, 2, 5, 708, DateTimeKind.Local).AddTicks(6292) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 5, 708, DateTimeKind.Local).AddTicks(6301), new DateTime(2021, 12, 8, 22, 2, 5, 708, DateTimeKind.Local).AddTicks(6304) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 5, 708, DateTimeKind.Local).AddTicks(3972), new DateTime(2021, 12, 8, 22, 2, 5, 708, DateTimeKind.Local).AddTicks(3981), "MB122108220204452" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 5, 708, DateTimeKind.Local).AddTicks(4067), new DateTime(2021, 12, 8, 22, 2, 5, 708, DateTimeKind.Local).AddTicks(4071), "BI122108220204457" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 5, 708, DateTimeKind.Local).AddTicks(4128), new DateTime(2021, 12, 8, 22, 2, 5, 708, DateTimeKind.Local).AddTicks(4131), "SP122108220204457" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 450, DateTimeKind.Local).AddTicks(9014), new DateTime(2021, 12, 8, 22, 2, 4, 450, DateTimeKind.Local).AddTicks(9019) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 448, DateTimeKind.Local).AddTicks(2832), new DateTime(2021, 12, 8, 22, 2, 4, 450, DateTimeKind.Local).AddTicks(4230) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 450, DateTimeKind.Local).AddTicks(5827), new DateTime(2021, 12, 8, 22, 2, 4, 450, DateTimeKind.Local).AddTicks(5839) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 450, DateTimeKind.Local).AddTicks(5843), new DateTime(2021, 12, 8, 22, 2, 4, 450, DateTimeKind.Local).AddTicks(5845) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(1215), new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(1220) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(1224), new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(1225) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(1227), new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(1228) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(1230), new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(1231) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(1232), new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(1233) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(1235), new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(1236) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(1237), new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(1238) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(9018), new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(9024) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(9028), new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(9029) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(9030), new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(9031) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 457, DateTimeKind.Local).AddTicks(7523), new DateTime(2021, 12, 8, 22, 2, 4, 457, DateTimeKind.Local).AddTicks(7533) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 465, DateTimeKind.Local).AddTicks(995), new DateTime(2021, 12, 8, 22, 2, 4, 465, DateTimeKind.Local).AddTicks(1021) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 465, DateTimeKind.Local).AddTicks(1648), new DateTime(2021, 12, 8, 22, 2, 4, 465, DateTimeKind.Local).AddTicks(1655) });
        }
    }
}
