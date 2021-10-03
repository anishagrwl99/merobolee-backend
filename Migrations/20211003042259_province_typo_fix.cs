using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class province_typo_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_company_mb_province_ProvienceId",
                schema: "dbo",
                table: "mb_company");

            migrationBuilder.RenameColumn(
                name: "ProvienceId",
                schema: "dbo",
                table: "mb_company",
                newName: "ProvinceId");

            migrationBuilder.RenameIndex(
                name: "IX_mb_company_ProvienceId",
                schema: "dbo",
                table: "mb_company",
                newName: "IX_mb_company_ProvinceId");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 59, 32, DateTimeKind.Local).AddTicks(3755), new DateTime(2021, 10, 3, 10, 7, 59, 32, DateTimeKind.Local).AddTicks(3781) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 59, 32, DateTimeKind.Local).AddTicks(3819), new DateTime(2021, 10, 3, 10, 7, 59, 32, DateTimeKind.Local).AddTicks(3822) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 59, 32, DateTimeKind.Local).AddTicks(3836), new DateTime(2021, 10, 3, 10, 7, 59, 32, DateTimeKind.Local).AddTicks(3840) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 59, 54, DateTimeKind.Local).AddTicks(2243), new DateTime(2021, 10, 3, 10, 7, 59, 54, DateTimeKind.Local).AddTicks(2269) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 59, 54, DateTimeKind.Local).AddTicks(2281), new DateTime(2021, 10, 3, 10, 7, 59, 54, DateTimeKind.Local).AddTicks(2284) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 59, 54, DateTimeKind.Local).AddTicks(2293), new DateTime(2021, 10, 3, 10, 7, 59, 54, DateTimeKind.Local).AddTicks(2296) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 58, 551, DateTimeKind.Local).AddTicks(207), new DateTime(2021, 10, 3, 10, 7, 58, 551, DateTimeKind.Local).AddTicks(8476) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(417), new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(423) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(427), new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(428) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(429), new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(431) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(432), new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(433) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(435), new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(436) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(437), new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(438) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(440), new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(441) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(3545), new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(3550) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(3553), new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(3554) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(3556), new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(3557) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(9750), new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(9757) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 58, 556, DateTimeKind.Local).AddTicks(4635), new DateTime(2021, 10, 3, 10, 7, 58, 556, DateTimeKind.Local).AddTicks(4661) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 58, 556, DateTimeKind.Local).AddTicks(5245), new DateTime(2021, 10, 3, 10, 7, 58, 556, DateTimeKind.Local).AddTicks(5249) });

            migrationBuilder.AddForeignKey(
                name: "FK_mb_company_mb_province_ProvinceId",
                schema: "dbo",
                table: "mb_company",
                column: "ProvinceId",
                principalSchema: "dbo",
                principalTable: "mb_province",
                principalColumn: "province_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_company_mb_province_ProvinceId",
                schema: "dbo",
                table: "mb_company");

            migrationBuilder.RenameColumn(
                name: "ProvinceId",
                schema: "dbo",
                table: "mb_company",
                newName: "ProvienceId");

            migrationBuilder.RenameIndex(
                name: "IX_mb_company_ProvinceId",
                schema: "dbo",
                table: "mb_company",
                newName: "IX_mb_company_ProvienceId");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 1, 17, 7, 35, 187, DateTimeKind.Local).AddTicks(4694), new DateTime(2021, 10, 1, 17, 7, 35, 187, DateTimeKind.Local).AddTicks(4720) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 1, 17, 7, 35, 187, DateTimeKind.Local).AddTicks(4748), new DateTime(2021, 10, 1, 17, 7, 35, 187, DateTimeKind.Local).AddTicks(4752) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 1, 17, 7, 35, 187, DateTimeKind.Local).AddTicks(4766), new DateTime(2021, 10, 1, 17, 7, 35, 187, DateTimeKind.Local).AddTicks(4769) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 1, 17, 7, 35, 187, DateTimeKind.Local).AddTicks(7836), new DateTime(2021, 10, 1, 17, 7, 35, 187, DateTimeKind.Local).AddTicks(7845) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 1, 17, 7, 35, 187, DateTimeKind.Local).AddTicks(7857), new DateTime(2021, 10, 1, 17, 7, 35, 187, DateTimeKind.Local).AddTicks(7860) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 1, 17, 7, 35, 187, DateTimeKind.Local).AddTicks(7869), new DateTime(2021, 10, 1, 17, 7, 35, 187, DateTimeKind.Local).AddTicks(7873) });

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

            migrationBuilder.AddForeignKey(
                name: "FK_mb_company_mb_province_ProvienceId",
                schema: "dbo",
                table: "mb_company",
                column: "ProvienceId",
                principalSchema: "dbo",
                principalTable: "mb_province",
                principalColumn: "province_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
