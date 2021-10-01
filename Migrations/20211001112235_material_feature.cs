using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class material_feature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "feature",
                schema: "dbo",
                table: "mb_material_feature",
                newName: "feature_value");

            migrationBuilder.AddColumn<string>(
                name: "feature_name",
                schema: "dbo",
                table: "mb_material_feature",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 1, 17, 7, 34, 621, DateTimeKind.Local).AddTicks(2448), new DateTime(2021, 10, 1, 17, 7, 34, 621, DateTimeKind.Local).AddTicks(2472) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 1, 17, 7, 34, 621, DateTimeKind.Local).AddTicks(2504), new DateTime(2021, 10, 1, 17, 7, 34, 621, DateTimeKind.Local).AddTicks(2507) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 1, 17, 7, 34, 621, DateTimeKind.Local).AddTicks(2519), new DateTime(2021, 10, 1, 17, 7, 34, 621, DateTimeKind.Local).AddTicks(2522) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 1, 17, 7, 34, 649, DateTimeKind.Local).AddTicks(3323), new DateTime(2021, 10, 1, 17, 7, 34, 649, DateTimeKind.Local).AddTicks(3348) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 1, 17, 7, 34, 649, DateTimeKind.Local).AddTicks(3359), new DateTime(2021, 10, 1, 17, 7, 34, 649, DateTimeKind.Local).AddTicks(3363) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 1, 17, 7, 34, 649, DateTimeKind.Local).AddTicks(3371), new DateTime(2021, 10, 1, 17, 7, 34, 649, DateTimeKind.Local).AddTicks(3373) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 1, 17, 7, 33, 982, DateTimeKind.Local).AddTicks(7243), new DateTime(2021, 10, 1, 17, 7, 33, 984, DateTimeKind.Local).AddTicks(4513) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 1, 17, 7, 33, 984, DateTimeKind.Local).AddTicks(7470), new DateTime(2021, 10, 1, 17, 7, 33, 984, DateTimeKind.Local).AddTicks(7478) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 1, 17, 7, 33, 984, DateTimeKind.Local).AddTicks(7481), new DateTime(2021, 10, 1, 17, 7, 33, 984, DateTimeKind.Local).AddTicks(7482) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 1, 17, 7, 33, 984, DateTimeKind.Local).AddTicks(7484), new DateTime(2021, 10, 1, 17, 7, 33, 984, DateTimeKind.Local).AddTicks(7485) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 1, 17, 7, 33, 984, DateTimeKind.Local).AddTicks(7486), new DateTime(2021, 10, 1, 17, 7, 33, 984, DateTimeKind.Local).AddTicks(7487) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 1, 17, 7, 33, 984, DateTimeKind.Local).AddTicks(7488), new DateTime(2021, 10, 1, 17, 7, 33, 984, DateTimeKind.Local).AddTicks(7489) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 1, 17, 7, 33, 984, DateTimeKind.Local).AddTicks(7491), new DateTime(2021, 10, 1, 17, 7, 33, 984, DateTimeKind.Local).AddTicks(7491) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 1, 17, 7, 33, 984, DateTimeKind.Local).AddTicks(7493), new DateTime(2021, 10, 1, 17, 7, 33, 984, DateTimeKind.Local).AddTicks(7494) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 1, 17, 7, 33, 985, DateTimeKind.Local).AddTicks(2079), new DateTime(2021, 10, 1, 17, 7, 33, 985, DateTimeKind.Local).AddTicks(2084) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 1, 17, 7, 33, 985, DateTimeKind.Local).AddTicks(2087), new DateTime(2021, 10, 1, 17, 7, 33, 985, DateTimeKind.Local).AddTicks(2088) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 1, 17, 7, 33, 985, DateTimeKind.Local).AddTicks(2090), new DateTime(2021, 10, 1, 17, 7, 33, 985, DateTimeKind.Local).AddTicks(2091) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 1, 17, 7, 33, 986, DateTimeKind.Local).AddTicks(1072), new DateTime(2021, 10, 1, 17, 7, 33, 986, DateTimeKind.Local).AddTicks(1080) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 1, 17, 7, 33, 991, DateTimeKind.Local).AddTicks(3263), new DateTime(2021, 10, 1, 17, 7, 33, 991, DateTimeKind.Local).AddTicks(3285) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 1, 17, 7, 33, 991, DateTimeKind.Local).AddTicks(3663), new DateTime(2021, 10, 1, 17, 7, 33, 991, DateTimeKind.Local).AddTicks(3666) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "feature_name",
                schema: "dbo",
                table: "mb_material_feature");

            migrationBuilder.RenameColumn(
                name: "feature_value",
                schema: "dbo",
                table: "mb_material_feature",
                newName: "feature");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 18, 3, 24, 351, DateTimeKind.Local).AddTicks(8719), new DateTime(2021, 9, 30, 18, 3, 24, 351, DateTimeKind.Local).AddTicks(8749) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 18, 3, 24, 351, DateTimeKind.Local).AddTicks(8784), new DateTime(2021, 9, 30, 18, 3, 24, 351, DateTimeKind.Local).AddTicks(8788) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 18, 3, 24, 351, DateTimeKind.Local).AddTicks(8805), new DateTime(2021, 9, 30, 18, 3, 24, 351, DateTimeKind.Local).AddTicks(8809) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 18, 3, 24, 352, DateTimeKind.Local).AddTicks(2455), new DateTime(2021, 9, 30, 18, 3, 24, 352, DateTimeKind.Local).AddTicks(2467) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 18, 3, 24, 352, DateTimeKind.Local).AddTicks(2481), new DateTime(2021, 9, 30, 18, 3, 24, 352, DateTimeKind.Local).AddTicks(2485) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 18, 3, 24, 352, DateTimeKind.Local).AddTicks(2496), new DateTime(2021, 9, 30, 18, 3, 24, 352, DateTimeKind.Local).AddTicks(2500) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 18, 3, 22, 527, DateTimeKind.Local).AddTicks(7634), new DateTime(2021, 9, 30, 18, 3, 22, 530, DateTimeKind.Local).AddTicks(3913) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 18, 3, 22, 531, DateTimeKind.Local).AddTicks(2308), new DateTime(2021, 9, 30, 18, 3, 22, 531, DateTimeKind.Local).AddTicks(2348) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 18, 3, 22, 531, DateTimeKind.Local).AddTicks(2354), new DateTime(2021, 9, 30, 18, 3, 22, 531, DateTimeKind.Local).AddTicks(2358) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 18, 3, 22, 531, DateTimeKind.Local).AddTicks(2360), new DateTime(2021, 9, 30, 18, 3, 22, 531, DateTimeKind.Local).AddTicks(2361) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 18, 3, 22, 531, DateTimeKind.Local).AddTicks(2363), new DateTime(2021, 9, 30, 18, 3, 22, 531, DateTimeKind.Local).AddTicks(2364) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 18, 3, 22, 531, DateTimeKind.Local).AddTicks(2366), new DateTime(2021, 9, 30, 18, 3, 22, 531, DateTimeKind.Local).AddTicks(2367) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 18, 3, 22, 531, DateTimeKind.Local).AddTicks(2371), new DateTime(2021, 9, 30, 18, 3, 22, 531, DateTimeKind.Local).AddTicks(2373) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 18, 3, 22, 531, DateTimeKind.Local).AddTicks(2374), new DateTime(2021, 9, 30, 18, 3, 22, 531, DateTimeKind.Local).AddTicks(2375) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 18, 3, 22, 531, DateTimeKind.Local).AddTicks(9671), new DateTime(2021, 9, 30, 18, 3, 22, 531, DateTimeKind.Local).AddTicks(9687) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 18, 3, 22, 531, DateTimeKind.Local).AddTicks(9690), new DateTime(2021, 9, 30, 18, 3, 22, 531, DateTimeKind.Local).AddTicks(9692) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 18, 3, 22, 531, DateTimeKind.Local).AddTicks(9694), new DateTime(2021, 9, 30, 18, 3, 22, 531, DateTimeKind.Local).AddTicks(9695) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 18, 3, 22, 533, DateTimeKind.Local).AddTicks(4537), new DateTime(2021, 9, 30, 18, 3, 22, 533, DateTimeKind.Local).AddTicks(4554) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 18, 3, 22, 540, DateTimeKind.Local).AddTicks(4791), new DateTime(2021, 9, 30, 18, 3, 22, 540, DateTimeKind.Local).AddTicks(4823) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 18, 3, 22, 540, DateTimeKind.Local).AddTicks(5389), new DateTime(2021, 9, 30, 18, 3, 22, 540, DateTimeKind.Local).AddTicks(5396) });
        }
    }
}
