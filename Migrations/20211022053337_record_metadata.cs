using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class record_metadata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_vdc",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_vdc",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_user",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_user",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_tender",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_tender",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_role",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_role",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_request_help",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_request_help",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_province",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_province",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_municipality",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_municipality",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_membership",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_membership",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_mail_data",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_mail_data",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_FAQ",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_FAQ",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_district",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_district",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_country",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_country",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_company_type",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_company_type",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_company",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_company",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_city",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_city",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_bidder_request",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_bidder_request",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "lk_company_type",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "lk_company_type",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "lk_category",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "lk_category",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 36, 645, DateTimeKind.Local).AddTicks(2839), new DateTime(2021, 10, 22, 11, 18, 36, 645, DateTimeKind.Local).AddTicks(2867) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 36, 645, DateTimeKind.Local).AddTicks(2900), new DateTime(2021, 10, 22, 11, 18, 36, 645, DateTimeKind.Local).AddTicks(2903) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 36, 645, DateTimeKind.Local).AddTicks(2916), new DateTime(2021, 10, 22, 11, 18, 36, 645, DateTimeKind.Local).AddTicks(2919) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 36, 684, DateTimeKind.Local).AddTicks(9658), new DateTime(2021, 10, 22, 11, 18, 36, 684, DateTimeKind.Local).AddTicks(9686) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 36, 684, DateTimeKind.Local).AddTicks(9698), new DateTime(2021, 10, 22, 11, 18, 36, 684, DateTimeKind.Local).AddTicks(9701) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 36, 684, DateTimeKind.Local).AddTicks(9709), new DateTime(2021, 10, 22, 11, 18, 36, 684, DateTimeKind.Local).AddTicks(9712) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 36, 658, DateTimeKind.Local).AddTicks(1395), new DateTime(2021, 10, 22, 11, 18, 36, 658, DateTimeKind.Local).AddTicks(1423), "SP102122111835979" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(4736), new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(4741) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 35, 974, DateTimeKind.Local).AddTicks(107), new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(1245) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(1923), new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(1928) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(1930), new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(1931) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(6621), new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(6626) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(6630), new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(6631) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(6633), new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(6633) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(6635), new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(6636) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(6637), new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(6638) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(6640), new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(6641) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(6642), new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(6643) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 35, 978, DateTimeKind.Local).AddTicks(4513), new DateTime(2021, 10, 22, 11, 18, 35, 978, DateTimeKind.Local).AddTicks(4519) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 35, 978, DateTimeKind.Local).AddTicks(4522), new DateTime(2021, 10, 22, 11, 18, 35, 978, DateTimeKind.Local).AddTicks(4523) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 35, 978, DateTimeKind.Local).AddTicks(4524), new DateTime(2021, 10, 22, 11, 18, 35, 978, DateTimeKind.Local).AddTicks(4525) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 36, 0, DateTimeKind.Local).AddTicks(5761), new DateTime(2021, 10, 22, 11, 18, 36, 0, DateTimeKind.Local).AddTicks(5782) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 36, 21, DateTimeKind.Local).AddTicks(3052), new DateTime(2021, 10, 22, 11, 18, 36, 21, DateTimeKind.Local).AddTicks(3075) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 36, 21, DateTimeKind.Local).AddTicks(3460), new DateTime(2021, 10, 22, 11, 18, 36, 21, DateTimeKind.Local).AddTicks(3463) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_vdc",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_vdc",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_user",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_user",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_tender",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_tender",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_role",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_role",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_request_help",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_request_help",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_province",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_province",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_municipality",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_municipality",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_membership",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_membership",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_mail_data",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_mail_data",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_FAQ",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_FAQ",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_district",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_district",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_country",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_country",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_company_type",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_company_type",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_company",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_company",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_city",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_city",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_bidder_request",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_bidder_request",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "lk_company_type",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "lk_company_type",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "lk_category",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "lk_category",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 20, 16, 3, 9, 320, DateTimeKind.Local).AddTicks(5106), new DateTime(2021, 10, 20, 16, 3, 9, 320, DateTimeKind.Local).AddTicks(5135) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 20, 16, 3, 9, 320, DateTimeKind.Local).AddTicks(5161), new DateTime(2021, 10, 20, 16, 3, 9, 320, DateTimeKind.Local).AddTicks(5164) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 20, 16, 3, 9, 320, DateTimeKind.Local).AddTicks(5178), new DateTime(2021, 10, 20, 16, 3, 9, 320, DateTimeKind.Local).AddTicks(5182) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 20, 16, 3, 9, 321, DateTimeKind.Local).AddTicks(1066), new DateTime(2021, 10, 20, 16, 3, 9, 321, DateTimeKind.Local).AddTicks(1080) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 20, 16, 3, 9, 321, DateTimeKind.Local).AddTicks(1093), new DateTime(2021, 10, 20, 16, 3, 9, 321, DateTimeKind.Local).AddTicks(1097) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 20, 16, 3, 9, 321, DateTimeKind.Local).AddTicks(1106), new DateTime(2021, 10, 20, 16, 3, 9, 321, DateTimeKind.Local).AddTicks(1109) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 10, 20, 16, 3, 9, 320, DateTimeKind.Local).AddTicks(9575), new DateTime(2021, 10, 20, 16, 3, 9, 320, DateTimeKind.Local).AddTicks(9586), "SP102120160307921" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 20, 16, 3, 7, 920, DateTimeKind.Local).AddTicks(4376), new DateTime(2021, 10, 20, 16, 3, 7, 920, DateTimeKind.Local).AddTicks(4381) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 20, 16, 3, 7, 918, DateTimeKind.Local).AddTicks(4257), new DateTime(2021, 10, 20, 16, 3, 7, 920, DateTimeKind.Local).AddTicks(916) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 20, 16, 3, 7, 920, DateTimeKind.Local).AddTicks(1639), new DateTime(2021, 10, 20, 16, 3, 7, 920, DateTimeKind.Local).AddTicks(1644) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 20, 16, 3, 7, 920, DateTimeKind.Local).AddTicks(1646), new DateTime(2021, 10, 20, 16, 3, 7, 920, DateTimeKind.Local).AddTicks(1647) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 20, 16, 3, 7, 920, DateTimeKind.Local).AddTicks(6263), new DateTime(2021, 10, 20, 16, 3, 7, 920, DateTimeKind.Local).AddTicks(6268) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 20, 16, 3, 7, 920, DateTimeKind.Local).AddTicks(6272), new DateTime(2021, 10, 20, 16, 3, 7, 920, DateTimeKind.Local).AddTicks(6273) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 20, 16, 3, 7, 920, DateTimeKind.Local).AddTicks(6274), new DateTime(2021, 10, 20, 16, 3, 7, 920, DateTimeKind.Local).AddTicks(6275) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 20, 16, 3, 7, 920, DateTimeKind.Local).AddTicks(6277), new DateTime(2021, 10, 20, 16, 3, 7, 920, DateTimeKind.Local).AddTicks(6278) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 20, 16, 3, 7, 920, DateTimeKind.Local).AddTicks(6279), new DateTime(2021, 10, 20, 16, 3, 7, 920, DateTimeKind.Local).AddTicks(6280) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 20, 16, 3, 7, 920, DateTimeKind.Local).AddTicks(6281), new DateTime(2021, 10, 20, 16, 3, 7, 920, DateTimeKind.Local).AddTicks(6282) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 20, 16, 3, 7, 920, DateTimeKind.Local).AddTicks(6284), new DateTime(2021, 10, 20, 16, 3, 7, 920, DateTimeKind.Local).AddTicks(6284) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 20, 16, 3, 7, 921, DateTimeKind.Local).AddTicks(3618), new DateTime(2021, 10, 20, 16, 3, 7, 921, DateTimeKind.Local).AddTicks(3624) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 20, 16, 3, 7, 921, DateTimeKind.Local).AddTicks(3626), new DateTime(2021, 10, 20, 16, 3, 7, 921, DateTimeKind.Local).AddTicks(3627) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 20, 16, 3, 7, 921, DateTimeKind.Local).AddTicks(3629), new DateTime(2021, 10, 20, 16, 3, 7, 921, DateTimeKind.Local).AddTicks(3630) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 20, 16, 3, 7, 926, DateTimeKind.Local).AddTicks(2628), new DateTime(2021, 10, 20, 16, 3, 7, 926, DateTimeKind.Local).AddTicks(2645) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 20, 16, 3, 7, 934, DateTimeKind.Local).AddTicks(4046), new DateTime(2021, 10, 20, 16, 3, 7, 934, DateTimeKind.Local).AddTicks(4069) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 20, 16, 3, 7, 934, DateTimeKind.Local).AddTicks(4404), new DateTime(2021, 10, 20, 16, 3, 7, 934, DateTimeKind.Local).AddTicks(4406) });
        }
    }
}
