using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class tender_maxQuotation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MaxQuotation",
                schema: "dbo",
                table: "mb_tender",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 921, DateTimeKind.Local).AddTicks(6052), new DateTime(2021, 12, 22, 8, 33, 51, 921, DateTimeKind.Local).AddTicks(6105) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 921, DateTimeKind.Local).AddTicks(6168), new DateTime(2021, 12, 22, 8, 33, 51, 921, DateTimeKind.Local).AddTicks(6172) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 921, DateTimeKind.Local).AddTicks(6185), new DateTime(2021, 12, 22, 8, 33, 51, 921, DateTimeKind.Local).AddTicks(6188) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 988, DateTimeKind.Local).AddTicks(5481), new DateTime(2021, 12, 22, 8, 33, 51, 988, DateTimeKind.Local).AddTicks(5531) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 988, DateTimeKind.Local).AddTicks(5544), new DateTime(2021, 12, 22, 8, 33, 51, 988, DateTimeKind.Local).AddTicks(5547) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 988, DateTimeKind.Local).AddTicks(5557), new DateTime(2021, 12, 22, 8, 33, 51, 988, DateTimeKind.Local).AddTicks(5560) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 934, DateTimeKind.Local).AddTicks(5839), new DateTime(2021, 12, 22, 8, 33, 51, 934, DateTimeKind.Local).AddTicks(5865), "MB122122083351331" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 934, DateTimeKind.Local).AddTicks(6005), new DateTime(2021, 12, 22, 8, 33, 51, 934, DateTimeKind.Local).AddTicks(6008), "BI122122083351335" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 934, DateTimeKind.Local).AddTicks(6062), new DateTime(2021, 12, 22, 8, 33, 51, 934, DateTimeKind.Local).AddTicks(6065), "SP122122083351335" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(7077), new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(7081) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 329, DateTimeKind.Local).AddTicks(6274), new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(4841) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(5343), new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(5348) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(5350), new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(5351) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(8364), new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(8368) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(8371), new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(8372) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(8375), new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(8376) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(8378), new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(8379) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(8380), new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(8381) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(8383), new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(8384) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(8385), new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(8387) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 331, DateTimeKind.Local).AddTicks(3326), new DateTime(2021, 12, 22, 8, 33, 51, 331, DateTimeKind.Local).AddTicks(3334) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 331, DateTimeKind.Local).AddTicks(3337), new DateTime(2021, 12, 22, 8, 33, 51, 331, DateTimeKind.Local).AddTicks(3338) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 331, DateTimeKind.Local).AddTicks(3339), new DateTime(2021, 12, 22, 8, 33, 51, 331, DateTimeKind.Local).AddTicks(3340) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 335, DateTimeKind.Local).AddTicks(3910), new DateTime(2021, 12, 22, 8, 33, 51, 335, DateTimeKind.Local).AddTicks(3919) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 338, DateTimeKind.Local).AddTicks(8410), new DateTime(2021, 12, 22, 8, 33, 51, 338, DateTimeKind.Local).AddTicks(8442) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 338, DateTimeKind.Local).AddTicks(9095), new DateTime(2021, 12, 22, 8, 33, 51, 338, DateTimeKind.Local).AddTicks(9102) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxQuotation",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 39, 532, DateTimeKind.Local).AddTicks(4553), new DateTime(2021, 12, 19, 16, 11, 39, 532, DateTimeKind.Local).AddTicks(4581) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 39, 532, DateTimeKind.Local).AddTicks(4606), new DateTime(2021, 12, 19, 16, 11, 39, 532, DateTimeKind.Local).AddTicks(4610) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 39, 532, DateTimeKind.Local).AddTicks(4625), new DateTime(2021, 12, 19, 16, 11, 39, 532, DateTimeKind.Local).AddTicks(4629) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 39, 533, DateTimeKind.Local).AddTicks(1157), new DateTime(2021, 12, 19, 16, 11, 39, 533, DateTimeKind.Local).AddTicks(1167) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 39, 533, DateTimeKind.Local).AddTicks(1179), new DateTime(2021, 12, 19, 16, 11, 39, 533, DateTimeKind.Local).AddTicks(1183) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 39, 533, DateTimeKind.Local).AddTicks(1193), new DateTime(2021, 12, 19, 16, 11, 39, 533, DateTimeKind.Local).AddTicks(1196) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 39, 532, DateTimeKind.Local).AddTicks(8570), new DateTime(2021, 12, 19, 16, 11, 39, 532, DateTimeKind.Local).AddTicks(8579), "MB122119161138473" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 39, 532, DateTimeKind.Local).AddTicks(8665), new DateTime(2021, 12, 19, 16, 11, 39, 532, DateTimeKind.Local).AddTicks(8669), "BI122119161138476" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 39, 532, DateTimeKind.Local).AddTicks(8732), new DateTime(2021, 12, 19, 16, 11, 39, 532, DateTimeKind.Local).AddTicks(8736), "SP122119161138476" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(6725), new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(6729) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 471, DateTimeKind.Local).AddTicks(6598), new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(4693) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(5166), new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(5171) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(5173), new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(5174) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(7903), new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(7907) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(7911), new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(7913) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(7914), new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(7915) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(7917), new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(7918) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(7919), new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(7920) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(7921), new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(7922) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(7924), new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(7925) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 473, DateTimeKind.Local).AddTicks(2716), new DateTime(2021, 12, 19, 16, 11, 38, 473, DateTimeKind.Local).AddTicks(2723) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 473, DateTimeKind.Local).AddTicks(2726), new DateTime(2021, 12, 19, 16, 11, 38, 473, DateTimeKind.Local).AddTicks(2727) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 473, DateTimeKind.Local).AddTicks(2728), new DateTime(2021, 12, 19, 16, 11, 38, 473, DateTimeKind.Local).AddTicks(2729) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 477, DateTimeKind.Local).AddTicks(1179), new DateTime(2021, 12, 19, 16, 11, 38, 477, DateTimeKind.Local).AddTicks(1187) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 480, DateTimeKind.Local).AddTicks(820), new DateTime(2021, 12, 19, 16, 11, 38, 480, DateTimeKind.Local).AddTicks(829) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 480, DateTimeKind.Local).AddTicks(1208), new DateTime(2021, 12, 19, 16, 11, 38, 480, DateTimeKind.Local).AddTicks(1211) });
        }
    }
}
