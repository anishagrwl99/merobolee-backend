using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class faq_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_FAQ_lk_common_status_status_id",
                schema: "dbo",
                table: "mb_FAQ");

            migrationBuilder.DropIndex(
                name: "IX_mb_FAQ_status_id",
                schema: "dbo",
                table: "mb_FAQ");

            migrationBuilder.DropColumn(
                name: "status_id",
                schema: "dbo",
                table: "mb_FAQ");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 20, 16, 3, 8, 637, DateTimeKind.Local).AddTicks(6564), new DateTime(2021, 10, 20, 16, 3, 8, 637, DateTimeKind.Local).AddTicks(6591) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 20, 16, 3, 8, 637, DateTimeKind.Local).AddTicks(6622), new DateTime(2021, 10, 20, 16, 3, 8, 637, DateTimeKind.Local).AddTicks(6625) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 20, 16, 3, 8, 637, DateTimeKind.Local).AddTicks(6638), new DateTime(2021, 10, 20, 16, 3, 8, 637, DateTimeKind.Local).AddTicks(6640) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 20, 16, 3, 8, 682, DateTimeKind.Local).AddTicks(7159), new DateTime(2021, 10, 20, 16, 3, 8, 682, DateTimeKind.Local).AddTicks(7186) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 20, 16, 3, 8, 682, DateTimeKind.Local).AddTicks(7198), new DateTime(2021, 10, 20, 16, 3, 8, 682, DateTimeKind.Local).AddTicks(7201) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 20, 16, 3, 8, 682, DateTimeKind.Local).AddTicks(7209), new DateTime(2021, 10, 20, 16, 3, 8, 682, DateTimeKind.Local).AddTicks(7212) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 10, 20, 16, 3, 8, 652, DateTimeKind.Local).AddTicks(2363), new DateTime(2021, 10, 20, 16, 3, 8, 652, DateTimeKind.Local).AddTicks(2387), "SP102120160307921" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status_id",
                schema: "dbo",
                table: "mb_FAQ",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 11, 0, 627, DateTimeKind.Local).AddTicks(6364), new DateTime(2021, 10, 14, 10, 11, 0, 627, DateTimeKind.Local).AddTicks(6399) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 11, 0, 627, DateTimeKind.Local).AddTicks(6424), new DateTime(2021, 10, 14, 10, 11, 0, 627, DateTimeKind.Local).AddTicks(6428) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 11, 0, 627, DateTimeKind.Local).AddTicks(6442), new DateTime(2021, 10, 14, 10, 11, 0, 627, DateTimeKind.Local).AddTicks(6446) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 11, 0, 628, DateTimeKind.Local).AddTicks(4844), new DateTime(2021, 10, 14, 10, 11, 0, 628, DateTimeKind.Local).AddTicks(4857) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 11, 0, 628, DateTimeKind.Local).AddTicks(4870), new DateTime(2021, 10, 14, 10, 11, 0, 628, DateTimeKind.Local).AddTicks(4873) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 11, 0, 628, DateTimeKind.Local).AddTicks(4883), new DateTime(2021, 10, 14, 10, 11, 0, 628, DateTimeKind.Local).AddTicks(4886) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 11, 0, 628, DateTimeKind.Local).AddTicks(802), new DateTime(2021, 10, 14, 10, 11, 0, 628, DateTimeKind.Local).AddTicks(810), "SP102114101059651" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(3458), new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(3463) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 648, DateTimeKind.Local).AddTicks(4120), new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(1177) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(1680), new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(1686) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(1688), new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(1689) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(5134), new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(5140) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(5143), new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(5144) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(5145), new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(5146) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(5147), new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(5148) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(5150), new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(5151) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(5152), new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(5153) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(5154), new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(5155) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(9738), new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(9744) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(9748), new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(9749) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(9751), new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(9752) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 663, DateTimeKind.Local).AddTicks(1369), new DateTime(2021, 10, 14, 10, 10, 59, 663, DateTimeKind.Local).AddTicks(1386) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 672, DateTimeKind.Local).AddTicks(157), new DateTime(2021, 10, 14, 10, 10, 59, 672, DateTimeKind.Local).AddTicks(179) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 672, DateTimeKind.Local).AddTicks(509), new DateTime(2021, 10, 14, 10, 10, 59, 672, DateTimeKind.Local).AddTicks(512) });

            migrationBuilder.CreateIndex(
                name: "IX_mb_FAQ_status_id",
                schema: "dbo",
                table: "mb_FAQ",
                column: "status_id");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_FAQ_lk_common_status_status_id",
                schema: "dbo",
                table: "mb_FAQ",
                column: "status_id",
                principalSchema: "dbo",
                principalTable: "lk_common_status",
                principalColumn: "status_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
