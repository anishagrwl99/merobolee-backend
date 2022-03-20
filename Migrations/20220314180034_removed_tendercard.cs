using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class removed_tendercard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mb_TenderCard",
                schema: "dbo");

            migrationBuilder.AddColumn<string>(
                name: "Units",
                schema: "dbo",
                table: "mb_tender_material",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 34, 205, DateTimeKind.Unspecified).AddTicks(1489), new DateTime(2022, 3, 14, 23, 45, 34, 205, DateTimeKind.Unspecified).AddTicks(1550) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 34, 205, DateTimeKind.Unspecified).AddTicks(1565), new DateTime(2022, 3, 14, 23, 45, 34, 205, DateTimeKind.Unspecified).AddTicks(1570) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 34, 205, DateTimeKind.Unspecified).AddTicks(1609), new DateTime(2022, 3, 14, 23, 45, 34, 205, DateTimeKind.Unspecified).AddTicks(1614) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 34, 252, DateTimeKind.Unspecified).AddTicks(5721), new DateTime(2022, 3, 14, 23, 45, 34, 252, DateTimeKind.Unspecified).AddTicks(5775) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 34, 252, DateTimeKind.Unspecified).AddTicks(5796), new DateTime(2022, 3, 14, 23, 45, 34, 252, DateTimeKind.Unspecified).AddTicks(5801) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 34, 252, DateTimeKind.Unspecified).AddTicks(5811), new DateTime(2022, 3, 14, 23, 45, 34, 252, DateTimeKind.Unspecified).AddTicks(5815) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 34, 217, DateTimeKind.Unspecified).AddTicks(1107), new DateTime(2022, 3, 14, 23, 45, 34, 217, DateTimeKind.Unspecified).AddTicks(1164), "MB220314001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 34, 217, DateTimeKind.Unspecified).AddTicks(1257), new DateTime(2022, 3, 14, 23, 45, 34, 217, DateTimeKind.Unspecified).AddTicks(1263), "BI220314002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 34, 217, DateTimeKind.Unspecified).AddTicks(1321), new DateTime(2022, 3, 14, 23, 45, 34, 217, DateTimeKind.Unspecified).AddTicks(1326), "SP220314003" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(1044), new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(1048) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 627, DateTimeKind.Local).AddTicks(7335), new DateTime(2022, 3, 14, 23, 45, 33, 628, DateTimeKind.Local).AddTicks(9042) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 628, DateTimeKind.Local).AddTicks(9502), new DateTime(2022, 3, 14, 23, 45, 33, 628, DateTimeKind.Local).AddTicks(9507) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 628, DateTimeKind.Local).AddTicks(9509), new DateTime(2022, 3, 14, 23, 45, 33, 628, DateTimeKind.Local).AddTicks(9510) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(2222), new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(2226) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(2230), new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(2231) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(2232), new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(2233) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(2235), new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(2236) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(2237), new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(2238) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(2240), new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(2240) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(2242), new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(2243) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(7522), new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(7528) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(7530), new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(7532) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(7533), new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(7534) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(7535), new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(7536) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(7537), new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(7538) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 634, DateTimeKind.Local).AddTicks(7717), new DateTime(2022, 3, 14, 23, 45, 33, 634, DateTimeKind.Local).AddTicks(7724) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 644, DateTimeKind.Local).AddTicks(981), new DateTime(2022, 3, 14, 23, 45, 33, 644, DateTimeKind.Local).AddTicks(1006) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 644, DateTimeKind.Local).AddTicks(1351), new DateTime(2022, 3, 14, 23, 45, 33, 644, DateTimeKind.Local).AddTicks(1353) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 644, DateTimeKind.Local).AddTicks(1390), new DateTime(2022, 3, 14, 23, 45, 33, 644, DateTimeKind.Local).AddTicks(1391) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 644, DateTimeKind.Local).AddTicks(1496), new DateTime(2022, 3, 14, 23, 45, 33, 644, DateTimeKind.Local).AddTicks(1497) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Units",
                schema: "dbo",
                table: "mb_tender_material");

            migrationBuilder.CreateTable(
                name: "mb_TenderCard",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    TenderId = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_TenderCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mb_TenderCard_mb_tender_TenderId",
                        column: x => x.TenderId,
                        principalSchema: "dbo",
                        principalTable: "mb_tender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 18, 383, DateTimeKind.Local).AddTicks(3374), new DateTime(2022, 2, 27, 21, 25, 18, 383, DateTimeKind.Local).AddTicks(3398) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 18, 383, DateTimeKind.Local).AddTicks(3411), new DateTime(2022, 2, 27, 21, 25, 18, 383, DateTimeKind.Local).AddTicks(3415) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 18, 383, DateTimeKind.Local).AddTicks(3425), new DateTime(2022, 2, 27, 21, 25, 18, 383, DateTimeKind.Local).AddTicks(3428) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 18, 384, DateTimeKind.Local).AddTicks(1016), new DateTime(2022, 2, 27, 21, 25, 18, 384, DateTimeKind.Local).AddTicks(1025) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 18, 384, DateTimeKind.Local).AddTicks(1039), new DateTime(2022, 2, 27, 21, 25, 18, 384, DateTimeKind.Local).AddTicks(1043) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 18, 384, DateTimeKind.Local).AddTicks(1054), new DateTime(2022, 2, 27, 21, 25, 18, 384, DateTimeKind.Local).AddTicks(1057) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 18, 383, DateTimeKind.Local).AddTicks(8553), new DateTime(2022, 2, 27, 21, 25, 18, 383, DateTimeKind.Local).AddTicks(8564), "MB220227001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 18, 383, DateTimeKind.Local).AddTicks(8709), new DateTime(2022, 2, 27, 21, 25, 18, 383, DateTimeKind.Local).AddTicks(8713), "BI220227002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 18, 383, DateTimeKind.Local).AddTicks(8781), new DateTime(2022, 2, 27, 21, 25, 18, 383, DateTimeKind.Local).AddTicks(8784), "SP220227003" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(3857), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(3862) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 224, DateTimeKind.Local).AddTicks(7799), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(1651) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(2160), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(2165) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(2168), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(2169) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5143), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5148) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5152), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5153) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5154), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5155) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5156), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5157) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5159), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5160) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5162), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5163) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5164), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5165) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(9937), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(9942) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(9945), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(9946) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(9947), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(9948) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(9949), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(9950) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(9952), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(9953) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 243, DateTimeKind.Local).AddTicks(9842), new DateTime(2022, 2, 27, 21, 25, 17, 243, DateTimeKind.Local).AddTicks(9853) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 254, DateTimeKind.Local).AddTicks(91), new DateTime(2022, 2, 27, 21, 25, 17, 254, DateTimeKind.Local).AddTicks(115) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 254, DateTimeKind.Local).AddTicks(637), new DateTime(2022, 2, 27, 21, 25, 17, 254, DateTimeKind.Local).AddTicks(639) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 254, DateTimeKind.Local).AddTicks(690), new DateTime(2022, 2, 27, 21, 25, 17, 254, DateTimeKind.Local).AddTicks(692) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 254, DateTimeKind.Local).AddTicks(713), new DateTime(2022, 2, 27, 21, 25, 17, 254, DateTimeKind.Local).AddTicks(714) });

            migrationBuilder.CreateIndex(
                name: "IX_mb_TenderCard_TenderId",
                schema: "dbo",
                table: "mb_TenderCard",
                column: "TenderId");
        }
    }
}
