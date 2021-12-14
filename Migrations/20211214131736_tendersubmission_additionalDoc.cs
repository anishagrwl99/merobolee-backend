using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class tendersubmission_additionalDoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mb_TenderSubmissionAdditionalDocument",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenderSubmissionId = table.Column<long>(type: "bigint", nullable: false),
                    DocTitle = table.Column<string>(type: "VARCHAR(300)", maxLength: 300, nullable: false),
                    DocPath = table.Column<string>(type: "VARCHAR(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_TenderSubmissionAdditionalDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mb_TenderSubmissionAdditionalDocument_mb_TenderSubmission_TenderSubmissionId",
                        column: x => x.TenderSubmissionId,
                        principalSchema: "dbo",
                        principalTable: "mb_TenderSubmission",
                        principalColumn: "SubmissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 35, 689, DateTimeKind.Local).AddTicks(8447), new DateTime(2021, 12, 14, 19, 2, 35, 689, DateTimeKind.Local).AddTicks(8469) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 35, 689, DateTimeKind.Local).AddTicks(8496), new DateTime(2021, 12, 14, 19, 2, 35, 689, DateTimeKind.Local).AddTicks(8499) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 35, 689, DateTimeKind.Local).AddTicks(8511), new DateTime(2021, 12, 14, 19, 2, 35, 689, DateTimeKind.Local).AddTicks(8515) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 35, 741, DateTimeKind.Local).AddTicks(2070), new DateTime(2021, 12, 14, 19, 2, 35, 741, DateTimeKind.Local).AddTicks(2099) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 35, 741, DateTimeKind.Local).AddTicks(2110), new DateTime(2021, 12, 14, 19, 2, 35, 741, DateTimeKind.Local).AddTicks(2114) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 35, 741, DateTimeKind.Local).AddTicks(2122), new DateTime(2021, 12, 14, 19, 2, 35, 741, DateTimeKind.Local).AddTicks(2125) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 35, 701, DateTimeKind.Local).AddTicks(3425), new DateTime(2021, 12, 14, 19, 2, 35, 701, DateTimeKind.Local).AddTicks(3450), "MB122114190234955" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 35, 701, DateTimeKind.Local).AddTicks(3590), new DateTime(2021, 12, 14, 19, 2, 35, 701, DateTimeKind.Local).AddTicks(3594), "BI122114190234960" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 35, 701, DateTimeKind.Local).AddTicks(3645), new DateTime(2021, 12, 14, 19, 2, 35, 701, DateTimeKind.Local).AddTicks(3647), "SP122114190234960" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(3501), new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(3506) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 951, DateTimeKind.Local).AddTicks(9188), new DateTime(2021, 12, 14, 19, 2, 34, 953, DateTimeKind.Local).AddTicks(9930) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(636), new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(641) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(643), new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(644) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(5518), new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(5524) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(5527), new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(5528) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(5530), new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(5531) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(5532), new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(5533) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(5534), new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(5535) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(5537), new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(5538) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(5539), new DateTime(2021, 12, 14, 19, 2, 34, 954, DateTimeKind.Local).AddTicks(5540) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 955, DateTimeKind.Local).AddTicks(3155), new DateTime(2021, 12, 14, 19, 2, 34, 955, DateTimeKind.Local).AddTicks(3160) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 955, DateTimeKind.Local).AddTicks(3163), new DateTime(2021, 12, 14, 19, 2, 34, 955, DateTimeKind.Local).AddTicks(3164) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 955, DateTimeKind.Local).AddTicks(3166), new DateTime(2021, 12, 14, 19, 2, 34, 955, DateTimeKind.Local).AddTicks(3167) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 961, DateTimeKind.Local).AddTicks(1213), new DateTime(2021, 12, 14, 19, 2, 34, 961, DateTimeKind.Local).AddTicks(1221) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 966, DateTimeKind.Local).AddTicks(2650), new DateTime(2021, 12, 14, 19, 2, 34, 966, DateTimeKind.Local).AddTicks(2673) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 14, 19, 2, 34, 966, DateTimeKind.Local).AddTicks(3060), new DateTime(2021, 12, 14, 19, 2, 34, 966, DateTimeKind.Local).AddTicks(3064) });

            migrationBuilder.CreateIndex(
                name: "IX_mb_TenderSubmissionAdditionalDocument_TenderSubmissionId",
                schema: "dbo",
                table: "mb_TenderSubmissionAdditionalDocument",
                column: "TenderSubmissionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mb_TenderSubmissionAdditionalDocument",
                schema: "dbo");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 49, 551, DateTimeKind.Local).AddTicks(7682), new DateTime(2021, 12, 10, 9, 5, 49, 551, DateTimeKind.Local).AddTicks(7712) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 49, 551, DateTimeKind.Local).AddTicks(7736), new DateTime(2021, 12, 10, 9, 5, 49, 551, DateTimeKind.Local).AddTicks(7740) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 49, 551, DateTimeKind.Local).AddTicks(7755), new DateTime(2021, 12, 10, 9, 5, 49, 551, DateTimeKind.Local).AddTicks(7758) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 49, 552, DateTimeKind.Local).AddTicks(3220), new DateTime(2021, 12, 10, 9, 5, 49, 552, DateTimeKind.Local).AddTicks(3229) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 49, 552, DateTimeKind.Local).AddTicks(3240), new DateTime(2021, 12, 10, 9, 5, 49, 552, DateTimeKind.Local).AddTicks(3243) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 49, 552, DateTimeKind.Local).AddTicks(3253), new DateTime(2021, 12, 10, 9, 5, 49, 552, DateTimeKind.Local).AddTicks(3256) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 49, 552, DateTimeKind.Local).AddTicks(959), new DateTime(2021, 12, 10, 9, 5, 49, 552, DateTimeKind.Local).AddTicks(967), "MB122110090548311" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 49, 552, DateTimeKind.Local).AddTicks(1056), new DateTime(2021, 12, 10, 9, 5, 49, 552, DateTimeKind.Local).AddTicks(1060), "BI122110090548315" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 49, 552, DateTimeKind.Local).AddTicks(1117), new DateTime(2021, 12, 10, 9, 5, 49, 552, DateTimeKind.Local).AddTicks(1121), "SP122110090548315" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(4670), new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(4675) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 309, DateTimeKind.Local).AddTicks(3139), new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(2347) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(2839), new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(2844) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(2848), new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(2849) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(5906), new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(5910) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(5914), new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(5915) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(5917), new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(5918) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(5921), new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(5922) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(5923), new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(5924) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(5925), new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(5926) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(5928), new DateTime(2021, 12, 10, 9, 5, 48, 310, DateTimeKind.Local).AddTicks(5929) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 311, DateTimeKind.Local).AddTicks(820), new DateTime(2021, 12, 10, 9, 5, 48, 311, DateTimeKind.Local).AddTicks(826) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 311, DateTimeKind.Local).AddTicks(828), new DateTime(2021, 12, 10, 9, 5, 48, 311, DateTimeKind.Local).AddTicks(829) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 311, DateTimeKind.Local).AddTicks(832), new DateTime(2021, 12, 10, 9, 5, 48, 311, DateTimeKind.Local).AddTicks(833) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 315, DateTimeKind.Local).AddTicks(3956), new DateTime(2021, 12, 10, 9, 5, 48, 315, DateTimeKind.Local).AddTicks(3966) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 319, DateTimeKind.Local).AddTicks(2249), new DateTime(2021, 12, 10, 9, 5, 48, 319, DateTimeKind.Local).AddTicks(2274) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 10, 9, 5, 48, 319, DateTimeKind.Local).AddTicks(2789), new DateTime(2021, 12, 10, 9, 5, 48, 319, DateTimeKind.Local).AddTicks(2792) });
        }
    }
}
