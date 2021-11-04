using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class batchno_added_live_bid_and_history : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BatchNo",
                schema: "dbo",
                table: "mb_live_bid",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "BatchNo",
                schema: "dbo",
                table: "mb_bid_history",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 736, DateTimeKind.Local).AddTicks(420), new DateTime(2021, 11, 4, 14, 37, 22, 736, DateTimeKind.Local).AddTicks(452) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 736, DateTimeKind.Local).AddTicks(484), new DateTime(2021, 11, 4, 14, 37, 22, 736, DateTimeKind.Local).AddTicks(488) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 736, DateTimeKind.Local).AddTicks(503), new DateTime(2021, 11, 4, 14, 37, 22, 736, DateTimeKind.Local).AddTicks(506) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 779, DateTimeKind.Local).AddTicks(3152), new DateTime(2021, 11, 4, 14, 37, 22, 779, DateTimeKind.Local).AddTicks(3176) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 779, DateTimeKind.Local).AddTicks(3189), new DateTime(2021, 11, 4, 14, 37, 22, 779, DateTimeKind.Local).AddTicks(3192) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 779, DateTimeKind.Local).AddTicks(3202), new DateTime(2021, 11, 4, 14, 37, 22, 779, DateTimeKind.Local).AddTicks(3205) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 746, DateTimeKind.Local).AddTicks(9449), new DateTime(2021, 11, 4, 14, 37, 22, 746, DateTimeKind.Local).AddTicks(9475), "MB112104143722199" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 746, DateTimeKind.Local).AddTicks(9555), new DateTime(2021, 11, 4, 14, 37, 22, 746, DateTimeKind.Local).AddTicks(9558), "BI112104143722203" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode", "RegisteredAs" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 746, DateTimeKind.Local).AddTicks(9609), new DateTime(2021, 11, 4, 14, 37, 22, 746, DateTimeKind.Local).AddTicks(9612), "SP112104143722203", "Bidder" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(8370), new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(8375) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 197, DateTimeKind.Local).AddTicks(7857), new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(6246) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(6739), new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(6745) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(6747), new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(6748) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(9661), new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(9667) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(9671), new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(9672) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(9674), new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(9674) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(9676), new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(9677) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(9678), new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(9679) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(9681), new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(9682) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(9683), new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(9684) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 199, DateTimeKind.Local).AddTicks(4568), new DateTime(2021, 11, 4, 14, 37, 22, 199, DateTimeKind.Local).AddTicks(4574) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 199, DateTimeKind.Local).AddTicks(4577), new DateTime(2021, 11, 4, 14, 37, 22, 199, DateTimeKind.Local).AddTicks(4578) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 199, DateTimeKind.Local).AddTicks(4579), new DateTime(2021, 11, 4, 14, 37, 22, 199, DateTimeKind.Local).AddTicks(4580) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 203, DateTimeKind.Local).AddTicks(7895), new DateTime(2021, 11, 4, 14, 37, 22, 203, DateTimeKind.Local).AddTicks(7903) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 207, DateTimeKind.Local).AddTicks(596), new DateTime(2021, 11, 4, 14, 37, 22, 207, DateTimeKind.Local).AddTicks(609) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 207, DateTimeKind.Local).AddTicks(982), new DateTime(2021, 11, 4, 14, 37, 22, 207, DateTimeKind.Local).AddTicks(985) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatchNo",
                schema: "dbo",
                table: "mb_live_bid");

            migrationBuilder.DropColumn(
                name: "BatchNo",
                schema: "dbo",
                table: "mb_bid_history");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 12, 457, DateTimeKind.Local).AddTicks(7403), new DateTime(2021, 11, 3, 12, 42, 12, 457, DateTimeKind.Local).AddTicks(7428) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 12, 457, DateTimeKind.Local).AddTicks(7456), new DateTime(2021, 11, 3, 12, 42, 12, 457, DateTimeKind.Local).AddTicks(7460) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 12, 457, DateTimeKind.Local).AddTicks(7475), new DateTime(2021, 11, 3, 12, 42, 12, 457, DateTimeKind.Local).AddTicks(7479) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 12, 458, DateTimeKind.Local).AddTicks(3503), new DateTime(2021, 11, 3, 12, 42, 12, 458, DateTimeKind.Local).AddTicks(3512) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 12, 458, DateTimeKind.Local).AddTicks(3523), new DateTime(2021, 11, 3, 12, 42, 12, 458, DateTimeKind.Local).AddTicks(3527) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 12, 458, DateTimeKind.Local).AddTicks(3537), new DateTime(2021, 11, 3, 12, 42, 12, 458, DateTimeKind.Local).AddTicks(3541) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 12, 458, DateTimeKind.Local).AddTicks(1095), new DateTime(2021, 11, 3, 12, 42, 12, 458, DateTimeKind.Local).AddTicks(1105), "MB112103124211492" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 12, 458, DateTimeKind.Local).AddTicks(1193), new DateTime(2021, 11, 3, 12, 42, 12, 458, DateTimeKind.Local).AddTicks(1197), "BI112103124211495" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode", "RegisteredAs" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 12, 458, DateTimeKind.Local).AddTicks(1254), new DateTime(2021, 11, 3, 12, 42, 12, 458, DateTimeKind.Local).AddTicks(1257), "SP112103124211495", "Bidder,BidInviter" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(5663), new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(5668) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 490, DateTimeKind.Local).AddTicks(4001), new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(3419) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(3911), new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(3916) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(3918), new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(3920) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(7138), new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(7143) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(7146), new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(7147) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(7149), new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(7150) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(7151), new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(7152) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(7154), new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(7155) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(7157), new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(7158) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(7159), new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(7160) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 492, DateTimeKind.Local).AddTicks(1828), new DateTime(2021, 11, 3, 12, 42, 11, 492, DateTimeKind.Local).AddTicks(1834) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 492, DateTimeKind.Local).AddTicks(1837), new DateTime(2021, 11, 3, 12, 42, 11, 492, DateTimeKind.Local).AddTicks(1838) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 492, DateTimeKind.Local).AddTicks(1840), new DateTime(2021, 11, 3, 12, 42, 11, 492, DateTimeKind.Local).AddTicks(1841) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 496, DateTimeKind.Local).AddTicks(2417), new DateTime(2021, 11, 3, 12, 42, 11, 496, DateTimeKind.Local).AddTicks(2426) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 499, DateTimeKind.Local).AddTicks(6990), new DateTime(2021, 11, 3, 12, 42, 11, 499, DateTimeKind.Local).AddTicks(7013) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 499, DateTimeKind.Local).AddTicks(7464), new DateTime(2021, 11, 3, 12, 42, 11, 499, DateTimeKind.Local).AddTicks(7469) });
        }
    }
}
