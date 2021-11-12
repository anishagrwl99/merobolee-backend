using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class watchlistchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "company_id",
                schema: "dbo",
                table: "mb_watchlist",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 30, 269, DateTimeKind.Local).AddTicks(6894), new DateTime(2021, 11, 12, 16, 49, 30, 269, DateTimeKind.Local).AddTicks(6990) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 30, 269, DateTimeKind.Local).AddTicks(7029), new DateTime(2021, 11, 12, 16, 49, 30, 269, DateTimeKind.Local).AddTicks(7033) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 30, 269, DateTimeKind.Local).AddTicks(7046), new DateTime(2021, 11, 12, 16, 49, 30, 269, DateTimeKind.Local).AddTicks(7049) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 30, 317, DateTimeKind.Local).AddTicks(3472), new DateTime(2021, 11, 12, 16, 49, 30, 317, DateTimeKind.Local).AddTicks(3499) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 30, 317, DateTimeKind.Local).AddTicks(3511), new DateTime(2021, 11, 12, 16, 49, 30, 317, DateTimeKind.Local).AddTicks(3513) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 30, 317, DateTimeKind.Local).AddTicks(3522), new DateTime(2021, 11, 12, 16, 49, 30, 317, DateTimeKind.Local).AddTicks(3525) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 30, 281, DateTimeKind.Local).AddTicks(6231), new DateTime(2021, 11, 12, 16, 49, 30, 281, DateTimeKind.Local).AddTicks(6256), "MB112112164929586" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 30, 281, DateTimeKind.Local).AddTicks(6326), new DateTime(2021, 11, 12, 16, 49, 30, 281, DateTimeKind.Local).AddTicks(6329), "BI112112164929591" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 12, 16, 49, 30, 281, DateTimeKind.Local).AddTicks(6376), new DateTime(2021, 11, 12, 16, 49, 30, 281, DateTimeKind.Local).AddTicks(6379), "SP112112164929591" });

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

            migrationBuilder.CreateIndex(
                name: "IX_mb_watchlist_company_id",
                schema: "dbo",
                table: "mb_watchlist",
                column: "company_id");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_watchlist_mb_company_company_id",
                schema: "dbo",
                table: "mb_watchlist",
                column: "company_id",
                principalSchema: "dbo",
                principalTable: "mb_company",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_watchlist_mb_company_company_id",
                schema: "dbo",
                table: "mb_watchlist");

            migrationBuilder.DropIndex(
                name: "IX_mb_watchlist_company_id",
                schema: "dbo",
                table: "mb_watchlist");

            migrationBuilder.DropColumn(
                name: "company_id",
                schema: "dbo",
                table: "mb_watchlist");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 2, 238, DateTimeKind.Local).AddTicks(1577), new DateTime(2021, 11, 8, 16, 0, 2, 238, DateTimeKind.Local).AddTicks(1602) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 2, 238, DateTimeKind.Local).AddTicks(1625), new DateTime(2021, 11, 8, 16, 0, 2, 238, DateTimeKind.Local).AddTicks(1629) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 2, 238, DateTimeKind.Local).AddTicks(1644), new DateTime(2021, 11, 8, 16, 0, 2, 238, DateTimeKind.Local).AddTicks(1647) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 2, 238, DateTimeKind.Local).AddTicks(7355), new DateTime(2021, 11, 8, 16, 0, 2, 238, DateTimeKind.Local).AddTicks(7366) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 2, 238, DateTimeKind.Local).AddTicks(7377), new DateTime(2021, 11, 8, 16, 0, 2, 238, DateTimeKind.Local).AddTicks(7381) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 2, 238, DateTimeKind.Local).AddTicks(7391), new DateTime(2021, 11, 8, 16, 0, 2, 238, DateTimeKind.Local).AddTicks(7394) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 2, 238, DateTimeKind.Local).AddTicks(4982), new DateTime(2021, 11, 8, 16, 0, 2, 238, DateTimeKind.Local).AddTicks(4991), "MB112108160000854" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 2, 238, DateTimeKind.Local).AddTicks(5079), new DateTime(2021, 11, 8, 16, 0, 2, 238, DateTimeKind.Local).AddTicks(5083), "BI112108160000858" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 2, 238, DateTimeKind.Local).AddTicks(5143), new DateTime(2021, 11, 8, 16, 0, 2, 238, DateTimeKind.Local).AddTicks(5146), "SP112108160000858" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(8361), new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(8365) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 852, DateTimeKind.Local).AddTicks(7940), new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(6299) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(6768), new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(6773) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(6776), new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(6777) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(9533), new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(9537) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(9540), new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(9541) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(9543), new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(9544) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(9546), new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(9547) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(9548), new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(9549) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(9553), new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(9554) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(9556), new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(9557) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 854, DateTimeKind.Local).AddTicks(4351), new DateTime(2021, 11, 8, 16, 0, 0, 854, DateTimeKind.Local).AddTicks(4356) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 854, DateTimeKind.Local).AddTicks(4359), new DateTime(2021, 11, 8, 16, 0, 0, 854, DateTimeKind.Local).AddTicks(4360) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 854, DateTimeKind.Local).AddTicks(4361), new DateTime(2021, 11, 8, 16, 0, 0, 854, DateTimeKind.Local).AddTicks(4362) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 858, DateTimeKind.Local).AddTicks(3603), new DateTime(2021, 11, 8, 16, 0, 0, 858, DateTimeKind.Local).AddTicks(3609) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 861, DateTimeKind.Local).AddTicks(5116), new DateTime(2021, 11, 8, 16, 0, 0, 861, DateTimeKind.Local).AddTicks(5132) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 861, DateTimeKind.Local).AddTicks(5497), new DateTime(2021, 11, 8, 16, 0, 0, 861, DateTimeKind.Local).AddTicks(5499) });
        }
    }
}
