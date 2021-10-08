using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class live_bid_encyption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Quotation",
                schema: "dbo",
                table: "mb_live_bid",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 8, 12, 58, 4, 582, DateTimeKind.Local).AddTicks(3790), new DateTime(2021, 10, 8, 12, 58, 4, 582, DateTimeKind.Local).AddTicks(3820) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 8, 12, 58, 4, 582, DateTimeKind.Local).AddTicks(3862), new DateTime(2021, 10, 8, 12, 58, 4, 582, DateTimeKind.Local).AddTicks(3866) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 8, 12, 58, 4, 582, DateTimeKind.Local).AddTicks(3888), new DateTime(2021, 10, 8, 12, 58, 4, 582, DateTimeKind.Local).AddTicks(3891) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 8, 12, 58, 4, 614, DateTimeKind.Local).AddTicks(4028), new DateTime(2021, 10, 8, 12, 58, 4, 614, DateTimeKind.Local).AddTicks(4056) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 8, 12, 58, 4, 614, DateTimeKind.Local).AddTicks(4071), new DateTime(2021, 10, 8, 12, 58, 4, 614, DateTimeKind.Local).AddTicks(4074) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 8, 12, 58, 4, 614, DateTimeKind.Local).AddTicks(4084), new DateTime(2021, 10, 8, 12, 58, 4, 614, DateTimeKind.Local).AddTicks(4087) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 8, 12, 58, 3, 667, DateTimeKind.Local).AddTicks(5640), new DateTime(2021, 10, 8, 12, 58, 3, 669, DateTimeKind.Local).AddTicks(2089) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 8, 12, 58, 3, 669, DateTimeKind.Local).AddTicks(5372), new DateTime(2021, 10, 8, 12, 58, 3, 669, DateTimeKind.Local).AddTicks(5379) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 8, 12, 58, 3, 669, DateTimeKind.Local).AddTicks(5382), new DateTime(2021, 10, 8, 12, 58, 3, 669, DateTimeKind.Local).AddTicks(5383) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 8, 12, 58, 3, 669, DateTimeKind.Local).AddTicks(5385), new DateTime(2021, 10, 8, 12, 58, 3, 669, DateTimeKind.Local).AddTicks(5386) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 8, 12, 58, 3, 669, DateTimeKind.Local).AddTicks(5388), new DateTime(2021, 10, 8, 12, 58, 3, 669, DateTimeKind.Local).AddTicks(5389) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 8, 12, 58, 3, 669, DateTimeKind.Local).AddTicks(5479), new DateTime(2021, 10, 8, 12, 58, 3, 669, DateTimeKind.Local).AddTicks(5481) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 8, 12, 58, 3, 669, DateTimeKind.Local).AddTicks(5484), new DateTime(2021, 10, 8, 12, 58, 3, 669, DateTimeKind.Local).AddTicks(5485) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 8, 12, 58, 3, 669, DateTimeKind.Local).AddTicks(5486), new DateTime(2021, 10, 8, 12, 58, 3, 669, DateTimeKind.Local).AddTicks(5487) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 8, 12, 58, 3, 670, DateTimeKind.Local).AddTicks(6625), new DateTime(2021, 10, 8, 12, 58, 3, 670, DateTimeKind.Local).AddTicks(6649) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 8, 12, 58, 3, 670, DateTimeKind.Local).AddTicks(6652), new DateTime(2021, 10, 8, 12, 58, 3, 670, DateTimeKind.Local).AddTicks(6653) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 8, 12, 58, 3, 670, DateTimeKind.Local).AddTicks(6655), new DateTime(2021, 10, 8, 12, 58, 3, 670, DateTimeKind.Local).AddTicks(6657) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 8, 12, 58, 3, 672, DateTimeKind.Local).AddTicks(1341), new DateTime(2021, 10, 8, 12, 58, 3, 672, DateTimeKind.Local).AddTicks(1374) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 8, 12, 58, 3, 677, DateTimeKind.Local).AddTicks(4781), new DateTime(2021, 10, 8, 12, 58, 3, 677, DateTimeKind.Local).AddTicks(4802) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 8, 12, 58, 3, 677, DateTimeKind.Local).AddTicks(5174), new DateTime(2021, 10, 8, 12, 58, 3, 677, DateTimeKind.Local).AddTicks(5177) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Quotation",
                schema: "dbo",
                table: "mb_live_bid",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 47, 511, DateTimeKind.Local).AddTicks(8611), new DateTime(2021, 10, 3, 17, 7, 47, 511, DateTimeKind.Local).AddTicks(8641) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 47, 511, DateTimeKind.Local).AddTicks(8666), new DateTime(2021, 10, 3, 17, 7, 47, 511, DateTimeKind.Local).AddTicks(8670) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 47, 511, DateTimeKind.Local).AddTicks(8728), new DateTime(2021, 10, 3, 17, 7, 47, 511, DateTimeKind.Local).AddTicks(8732) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 47, 512, DateTimeKind.Local).AddTicks(3395), new DateTime(2021, 10, 3, 17, 7, 47, 512, DateTimeKind.Local).AddTicks(3406) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 47, 512, DateTimeKind.Local).AddTicks(3418), new DateTime(2021, 10, 3, 17, 7, 47, 512, DateTimeKind.Local).AddTicks(3421) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 47, 512, DateTimeKind.Local).AddTicks(3432), new DateTime(2021, 10, 3, 17, 7, 47, 512, DateTimeKind.Local).AddTicks(3435) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 46, 523, DateTimeKind.Local).AddTicks(4497), new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(2659) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(4593), new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(4600) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(4604), new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(4605) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(4606), new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(4608) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(4609), new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(4610) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(4612), new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(4613) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(4614), new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(4615) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(4616), new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(4617) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(9232), new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(9238) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(9240), new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(9241) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(9243), new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(9244) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 46, 525, DateTimeKind.Local).AddTicks(5093), new DateTime(2021, 10, 3, 17, 7, 46, 525, DateTimeKind.Local).AddTicks(5101) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 46, 528, DateTimeKind.Local).AddTicks(7142), new DateTime(2021, 10, 3, 17, 7, 46, 528, DateTimeKind.Local).AddTicks(7160) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 46, 528, DateTimeKind.Local).AddTicks(7494), new DateTime(2021, 10, 3, 17, 7, 46, 528, DateTimeKind.Local).AddTicks(7497) });
        }
    }
}
