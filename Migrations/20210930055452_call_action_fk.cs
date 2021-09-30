using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class call_action_fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ParentId",
                schema: "dbo",
                table: "mb_callaction_email",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 39, 51, 885, DateTimeKind.Local).AddTicks(8133), new DateTime(2021, 9, 30, 11, 39, 51, 885, DateTimeKind.Local).AddTicks(8157) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 39, 51, 885, DateTimeKind.Local).AddTicks(8184), new DateTime(2021, 9, 30, 11, 39, 51, 885, DateTimeKind.Local).AddTicks(8187) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 39, 51, 885, DateTimeKind.Local).AddTicks(8200), new DateTime(2021, 9, 30, 11, 39, 51, 885, DateTimeKind.Local).AddTicks(8203) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 39, 51, 904, DateTimeKind.Local).AddTicks(7096), new DateTime(2021, 9, 30, 11, 39, 51, 904, DateTimeKind.Local).AddTicks(7128) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 39, 51, 904, DateTimeKind.Local).AddTicks(7140), new DateTime(2021, 9, 30, 11, 39, 51, 904, DateTimeKind.Local).AddTicks(7142) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 39, 51, 904, DateTimeKind.Local).AddTicks(7151), new DateTime(2021, 9, 30, 11, 39, 51, 904, DateTimeKind.Local).AddTicks(7154) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 39, 51, 467, DateTimeKind.Local).AddTicks(3371), new DateTime(2021, 9, 30, 11, 39, 51, 468, DateTimeKind.Local).AddTicks(1162) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 39, 51, 468, DateTimeKind.Local).AddTicks(2479), new DateTime(2021, 9, 30, 11, 39, 51, 468, DateTimeKind.Local).AddTicks(2484) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 39, 51, 468, DateTimeKind.Local).AddTicks(2487), new DateTime(2021, 9, 30, 11, 39, 51, 468, DateTimeKind.Local).AddTicks(2488) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 39, 51, 468, DateTimeKind.Local).AddTicks(2490), new DateTime(2021, 9, 30, 11, 39, 51, 468, DateTimeKind.Local).AddTicks(2491) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 39, 51, 468, DateTimeKind.Local).AddTicks(2492), new DateTime(2021, 9, 30, 11, 39, 51, 468, DateTimeKind.Local).AddTicks(2493) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 39, 51, 468, DateTimeKind.Local).AddTicks(2495), new DateTime(2021, 9, 30, 11, 39, 51, 468, DateTimeKind.Local).AddTicks(2496) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 39, 51, 468, DateTimeKind.Local).AddTicks(2497), new DateTime(2021, 9, 30, 11, 39, 51, 468, DateTimeKind.Local).AddTicks(2498) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 39, 51, 468, DateTimeKind.Local).AddTicks(2500), new DateTime(2021, 9, 30, 11, 39, 51, 468, DateTimeKind.Local).AddTicks(2501) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 39, 51, 468, DateTimeKind.Local).AddTicks(4451), new DateTime(2021, 9, 30, 11, 39, 51, 468, DateTimeKind.Local).AddTicks(4456) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 39, 51, 468, DateTimeKind.Local).AddTicks(4458), new DateTime(2021, 9, 30, 11, 39, 51, 468, DateTimeKind.Local).AddTicks(4459) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 39, 51, 468, DateTimeKind.Local).AddTicks(4461), new DateTime(2021, 9, 30, 11, 39, 51, 468, DateTimeKind.Local).AddTicks(4462) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 39, 51, 468, DateTimeKind.Local).AddTicks(8313), new DateTime(2021, 9, 30, 11, 39, 51, 468, DateTimeKind.Local).AddTicks(8320) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 39, 51, 472, DateTimeKind.Local).AddTicks(2084), new DateTime(2021, 9, 30, 11, 39, 51, 472, DateTimeKind.Local).AddTicks(2110) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 39, 51, 472, DateTimeKind.Local).AddTicks(2469), new DateTime(2021, 9, 30, 11, 39, 51, 472, DateTimeKind.Local).AddTicks(2472) });

            migrationBuilder.CreateIndex(
                name: "IX_mb_callaction_email_ParentId",
                schema: "dbo",
                table: "mb_callaction_email",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_callaction_email_mb_callaction_email_ParentId",
                schema: "dbo",
                table: "mb_callaction_email",
                column: "ParentId",
                principalSchema: "dbo",
                principalTable: "mb_callaction_email",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_callaction_email_mb_callaction_email_ParentId",
                schema: "dbo",
                table: "mb_callaction_email");

            migrationBuilder.DropIndex(
                name: "IX_mb_callaction_email_ParentId",
                schema: "dbo",
                table: "mb_callaction_email");

            migrationBuilder.AlterColumn<long>(
                name: "ParentId",
                schema: "dbo",
                table: "mb_callaction_email",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 36, 859, DateTimeKind.Local).AddTicks(464), new DateTime(2021, 9, 30, 11, 12, 36, 859, DateTimeKind.Local).AddTicks(498) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 36, 859, DateTimeKind.Local).AddTicks(530), new DateTime(2021, 9, 30, 11, 12, 36, 859, DateTimeKind.Local).AddTicks(533) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 36, 859, DateTimeKind.Local).AddTicks(549), new DateTime(2021, 9, 30, 11, 12, 36, 859, DateTimeKind.Local).AddTicks(552) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 36, 859, DateTimeKind.Local).AddTicks(3686), new DateTime(2021, 9, 30, 11, 12, 36, 859, DateTimeKind.Local).AddTicks(3696) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 36, 859, DateTimeKind.Local).AddTicks(3711), new DateTime(2021, 9, 30, 11, 12, 36, 859, DateTimeKind.Local).AddTicks(3715) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 36, 859, DateTimeKind.Local).AddTicks(3724), new DateTime(2021, 9, 30, 11, 12, 36, 859, DateTimeKind.Local).AddTicks(3728) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 35, 877, DateTimeKind.Local).AddTicks(1340), new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(1669) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(3267), new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(3274) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(3277), new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(3278) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(3280), new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(3281) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(3282), new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(3283) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(3285), new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(3286) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(3287), new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(3288) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(3289), new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(3290) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(5459), new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(5464) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(5469), new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(5470) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(5471), new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(5472) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(9516), new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(9523) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 35, 882, DateTimeKind.Local).AddTicks(2552), new DateTime(2021, 9, 30, 11, 12, 35, 882, DateTimeKind.Local).AddTicks(2573) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 35, 882, DateTimeKind.Local).AddTicks(2961), new DateTime(2021, 9, 30, 11, 12, 35, 882, DateTimeKind.Local).AddTicks(2963) });
        }
    }
}
