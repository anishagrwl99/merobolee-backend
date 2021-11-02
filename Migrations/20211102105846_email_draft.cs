using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class email_draft : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                schema: "dbo",
                table: "mb_email",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 2, 16, 43, 45, 897, DateTimeKind.Local).AddTicks(3097), new DateTime(2021, 11, 2, 16, 43, 45, 897, DateTimeKind.Local).AddTicks(3126) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 2, 16, 43, 45, 897, DateTimeKind.Local).AddTicks(3157), new DateTime(2021, 11, 2, 16, 43, 45, 897, DateTimeKind.Local).AddTicks(3161) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 2, 16, 43, 45, 897, DateTimeKind.Local).AddTicks(3176), new DateTime(2021, 11, 2, 16, 43, 45, 897, DateTimeKind.Local).AddTicks(3179) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 2, 16, 43, 45, 976, DateTimeKind.Local).AddTicks(6775), new DateTime(2021, 11, 2, 16, 43, 45, 976, DateTimeKind.Local).AddTicks(6817) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 2, 16, 43, 45, 976, DateTimeKind.Local).AddTicks(6848), new DateTime(2021, 11, 2, 16, 43, 45, 976, DateTimeKind.Local).AddTicks(6859) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 2, 16, 43, 45, 976, DateTimeKind.Local).AddTicks(6959), new DateTime(2021, 11, 2, 16, 43, 45, 976, DateTimeKind.Local).AddTicks(6966) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 2, 16, 43, 45, 917, DateTimeKind.Local).AddTicks(2011), new DateTime(2021, 11, 2, 16, 43, 45, 917, DateTimeKind.Local).AddTicks(2052), "SP112102164345130" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 2, 16, 43, 45, 129, DateTimeKind.Local).AddTicks(869), new DateTime(2021, 11, 2, 16, 43, 45, 129, DateTimeKind.Local).AddTicks(874) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 2, 16, 43, 45, 126, DateTimeKind.Local).AddTicks(7567), new DateTime(2021, 11, 2, 16, 43, 45, 128, DateTimeKind.Local).AddTicks(7389) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 2, 16, 43, 45, 128, DateTimeKind.Local).AddTicks(8068), new DateTime(2021, 11, 2, 16, 43, 45, 128, DateTimeKind.Local).AddTicks(8073) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 2, 16, 43, 45, 128, DateTimeKind.Local).AddTicks(8075), new DateTime(2021, 11, 2, 16, 43, 45, 128, DateTimeKind.Local).AddTicks(8076) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 2, 16, 43, 45, 129, DateTimeKind.Local).AddTicks(2760), new DateTime(2021, 11, 2, 16, 43, 45, 129, DateTimeKind.Local).AddTicks(2765) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 2, 16, 43, 45, 129, DateTimeKind.Local).AddTicks(2768), new DateTime(2021, 11, 2, 16, 43, 45, 129, DateTimeKind.Local).AddTicks(2769) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 2, 16, 43, 45, 129, DateTimeKind.Local).AddTicks(2771), new DateTime(2021, 11, 2, 16, 43, 45, 129, DateTimeKind.Local).AddTicks(2772) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 2, 16, 43, 45, 129, DateTimeKind.Local).AddTicks(2773), new DateTime(2021, 11, 2, 16, 43, 45, 129, DateTimeKind.Local).AddTicks(2774) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 2, 16, 43, 45, 129, DateTimeKind.Local).AddTicks(2775), new DateTime(2021, 11, 2, 16, 43, 45, 129, DateTimeKind.Local).AddTicks(2778) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 2, 16, 43, 45, 129, DateTimeKind.Local).AddTicks(2868), new DateTime(2021, 11, 2, 16, 43, 45, 129, DateTimeKind.Local).AddTicks(2869) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 2, 16, 43, 45, 129, DateTimeKind.Local).AddTicks(2871), new DateTime(2021, 11, 2, 16, 43, 45, 129, DateTimeKind.Local).AddTicks(2872) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 2, 16, 43, 45, 130, DateTimeKind.Local).AddTicks(99), new DateTime(2021, 11, 2, 16, 43, 45, 130, DateTimeKind.Local).AddTicks(113) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 2, 16, 43, 45, 130, DateTimeKind.Local).AddTicks(116), new DateTime(2021, 11, 2, 16, 43, 45, 130, DateTimeKind.Local).AddTicks(117) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 2, 16, 43, 45, 130, DateTimeKind.Local).AddTicks(118), new DateTime(2021, 11, 2, 16, 43, 45, 130, DateTimeKind.Local).AddTicks(119) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 2, 16, 43, 45, 134, DateTimeKind.Local).AddTicks(9756), new DateTime(2021, 11, 2, 16, 43, 45, 134, DateTimeKind.Local).AddTicks(9776) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 2, 16, 43, 45, 141, DateTimeKind.Local).AddTicks(1305), new DateTime(2021, 11, 2, 16, 43, 45, 141, DateTimeKind.Local).AddTicks(1331) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 2, 16, 43, 45, 141, DateTimeKind.Local).AddTicks(1698), new DateTime(2021, 11, 2, 16, 43, 45, 141, DateTimeKind.Local).AddTicks(1700) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDraft",
                schema: "dbo",
                table: "mb_email");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 19, 869, DateTimeKind.Local).AddTicks(4758), new DateTime(2021, 11, 1, 17, 34, 19, 869, DateTimeKind.Local).AddTicks(4789) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 19, 869, DateTimeKind.Local).AddTicks(4816), new DateTime(2021, 11, 1, 17, 34, 19, 869, DateTimeKind.Local).AddTicks(4820) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 19, 869, DateTimeKind.Local).AddTicks(4834), new DateTime(2021, 11, 1, 17, 34, 19, 869, DateTimeKind.Local).AddTicks(4837) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 19, 870, DateTimeKind.Local).AddTicks(26), new DateTime(2021, 11, 1, 17, 34, 19, 870, DateTimeKind.Local).AddTicks(36) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 19, 870, DateTimeKind.Local).AddTicks(48), new DateTime(2021, 11, 1, 17, 34, 19, 870, DateTimeKind.Local).AddTicks(51) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 19, 870, DateTimeKind.Local).AddTicks(61), new DateTime(2021, 11, 1, 17, 34, 19, 870, DateTimeKind.Local).AddTicks(64) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 19, 869, DateTimeKind.Local).AddTicks(8120), new DateTime(2021, 11, 1, 17, 34, 19, 869, DateTimeKind.Local).AddTicks(8129), "SP112101173418593" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 591, DateTimeKind.Local).AddTicks(9592), new DateTime(2021, 11, 1, 17, 34, 18, 591, DateTimeKind.Local).AddTicks(9598) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 589, DateTimeKind.Local).AddTicks(9470), new DateTime(2021, 11, 1, 17, 34, 18, 591, DateTimeKind.Local).AddTicks(6166) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 591, DateTimeKind.Local).AddTicks(6838), new DateTime(2021, 11, 1, 17, 34, 18, 591, DateTimeKind.Local).AddTicks(6843) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 591, DateTimeKind.Local).AddTicks(6845), new DateTime(2021, 11, 1, 17, 34, 18, 591, DateTimeKind.Local).AddTicks(6846) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(1550), new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(1554) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(1558), new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(1559) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(1560), new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(1561) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(1563), new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(1564) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(1565), new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(1566) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(1568), new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(1569) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(1570), new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(1571) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(8920), new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(8926) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(8928), new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(8929) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(8930), new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(8931) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 598, DateTimeKind.Local).AddTicks(7956), new DateTime(2021, 11, 1, 17, 34, 18, 598, DateTimeKind.Local).AddTicks(7977) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 603, DateTimeKind.Local).AddTicks(6821), new DateTime(2021, 11, 1, 17, 34, 18, 603, DateTimeKind.Local).AddTicks(6844) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 603, DateTimeKind.Local).AddTicks(7179), new DateTime(2021, 11, 1, 17, 34, 18, 603, DateTimeKind.Local).AddTicks(7181) });
        }
    }
}
