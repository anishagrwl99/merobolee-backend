using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class tender_extradocs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TenderDetailDocPath",
                schema: "dbo",
                table: "mb_tender",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenderDetailDocTitle",
                schema: "dbo",
                table: "mb_tender",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TermsAndConditionDocPath",
                schema: "dbo",
                table: "mb_tender",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "mb_Tender_ExtraDocuments",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenderId = table.Column<long>(type: "bigint", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    DocTitle = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    DocPath = table.Column<string>(type: "VARCHAR(1500)", maxLength: 1500, nullable: false),
                    TenderEntityTender_Id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_Tender_ExtraDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mb_Tender_ExtraDocuments_mb_company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "dbo",
                        principalTable: "mb_company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_Tender_ExtraDocuments_mb_tender_TenderEntityTender_Id",
                        column: x => x.TenderEntityTender_Id,
                        principalSchema: "dbo",
                        principalTable: "mb_tender",
                        principalColumn: "tender_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_Tender_ExtraDocuments_mb_tender_TenderId",
                        column: x => x.TenderId,
                        principalSchema: "dbo",
                        principalTable: "mb_tender",
                        principalColumn: "tender_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_Tender_ExtraDocuments_mb_user_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 39, 15, DateTimeKind.Local).AddTicks(7172), new DateTime(2021, 12, 19, 16, 11, 39, 15, DateTimeKind.Local).AddTicks(7197) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 39, 15, DateTimeKind.Local).AddTicks(7226), new DateTime(2021, 12, 19, 16, 11, 39, 15, DateTimeKind.Local).AddTicks(7230) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 39, 15, DateTimeKind.Local).AddTicks(7244), new DateTime(2021, 12, 19, 16, 11, 39, 15, DateTimeKind.Local).AddTicks(7248) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 39, 57, DateTimeKind.Local).AddTicks(6453), new DateTime(2021, 12, 19, 16, 11, 39, 57, DateTimeKind.Local).AddTicks(6478) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 39, 57, DateTimeKind.Local).AddTicks(6491), new DateTime(2021, 12, 19, 16, 11, 39, 57, DateTimeKind.Local).AddTicks(6495) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 39, 57, DateTimeKind.Local).AddTicks(6504), new DateTime(2021, 12, 19, 16, 11, 39, 57, DateTimeKind.Local).AddTicks(6507) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 39, 25, DateTimeKind.Local).AddTicks(7821), new DateTime(2021, 12, 19, 16, 11, 39, 25, DateTimeKind.Local).AddTicks(7844), "MB122119161138473" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 39, 25, DateTimeKind.Local).AddTicks(7922), new DateTime(2021, 12, 19, 16, 11, 39, 25, DateTimeKind.Local).AddTicks(7926), "BI122119161138476" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 39, 25, DateTimeKind.Local).AddTicks(7979), new DateTime(2021, 12, 19, 16, 11, 39, 25, DateTimeKind.Local).AddTicks(7982), "SP122119161138476" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(6725), new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(6729) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 471, DateTimeKind.Local).AddTicks(6598), new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(4693) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(5166), new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(5171) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(5173), new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(5174) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(7903), new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(7907) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(7911), new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(7913) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(7914), new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(7915) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(7917), new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(7918) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(7919), new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(7920) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(7921), new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(7922) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(7924), new DateTime(2021, 12, 19, 16, 11, 38, 472, DateTimeKind.Local).AddTicks(7925) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 473, DateTimeKind.Local).AddTicks(2716), new DateTime(2021, 12, 19, 16, 11, 38, 473, DateTimeKind.Local).AddTicks(2723) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 473, DateTimeKind.Local).AddTicks(2726), new DateTime(2021, 12, 19, 16, 11, 38, 473, DateTimeKind.Local).AddTicks(2727) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 473, DateTimeKind.Local).AddTicks(2728), new DateTime(2021, 12, 19, 16, 11, 38, 473, DateTimeKind.Local).AddTicks(2729) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 477, DateTimeKind.Local).AddTicks(1179), new DateTime(2021, 12, 19, 16, 11, 38, 477, DateTimeKind.Local).AddTicks(1187) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 480, DateTimeKind.Local).AddTicks(820), new DateTime(2021, 12, 19, 16, 11, 38, 480, DateTimeKind.Local).AddTicks(829) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 16, 11, 38, 480, DateTimeKind.Local).AddTicks(1208), new DateTime(2021, 12, 19, 16, 11, 38, 480, DateTimeKind.Local).AddTicks(1211) });

            migrationBuilder.CreateIndex(
                name: "IX_mb_Tender_ExtraDocuments_CompanyId",
                schema: "dbo",
                table: "mb_Tender_ExtraDocuments",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_Tender_ExtraDocuments_TenderEntityTender_Id",
                schema: "dbo",
                table: "mb_Tender_ExtraDocuments",
                column: "TenderEntityTender_Id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_Tender_ExtraDocuments_TenderId",
                schema: "dbo",
                table: "mb_Tender_ExtraDocuments",
                column: "TenderId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_Tender_ExtraDocuments_UserId",
                schema: "dbo",
                table: "mb_Tender_ExtraDocuments",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mb_Tender_ExtraDocuments",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "TenderDetailDocPath",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropColumn(
                name: "TenderDetailDocTitle",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropColumn(
                name: "TermsAndConditionDocPath",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 29, 7, DateTimeKind.Local).AddTicks(8507), new DateTime(2021, 12, 19, 15, 28, 29, 7, DateTimeKind.Local).AddTicks(8570) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 29, 7, DateTimeKind.Local).AddTicks(8597), new DateTime(2021, 12, 19, 15, 28, 29, 7, DateTimeKind.Local).AddTicks(8601) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 29, 7, DateTimeKind.Local).AddTicks(8616), new DateTime(2021, 12, 19, 15, 28, 29, 7, DateTimeKind.Local).AddTicks(8620) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 29, 8, DateTimeKind.Local).AddTicks(4871), new DateTime(2021, 12, 19, 15, 28, 29, 8, DateTimeKind.Local).AddTicks(4881) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 29, 8, DateTimeKind.Local).AddTicks(4892), new DateTime(2021, 12, 19, 15, 28, 29, 8, DateTimeKind.Local).AddTicks(4896) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 29, 8, DateTimeKind.Local).AddTicks(4906), new DateTime(2021, 12, 19, 15, 28, 29, 8, DateTimeKind.Local).AddTicks(4909) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 29, 8, DateTimeKind.Local).AddTicks(2440), new DateTime(2021, 12, 19, 15, 28, 29, 8, DateTimeKind.Local).AddTicks(2450), "MB122119152827912" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 29, 8, DateTimeKind.Local).AddTicks(2541), new DateTime(2021, 12, 19, 15, 28, 29, 8, DateTimeKind.Local).AddTicks(2545), "BI122119152827916" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 29, 8, DateTimeKind.Local).AddTicks(2604), new DateTime(2021, 12, 19, 15, 28, 29, 8, DateTimeKind.Local).AddTicks(2607), "SP122119152827916" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(4120), new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(4125) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 910, DateTimeKind.Local).AddTicks(2903), new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(1922) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(2398), new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(2403) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(2406), new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(2407) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(5296), new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(5301) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(5304), new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(5305) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(5307), new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(5308) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(5309), new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(5310) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(5311), new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(5312) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(5314), new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(5315) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(5316), new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(5317) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(9954), new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(9960) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(9963), new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(9964) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(9965), new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(9966) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 916, DateTimeKind.Local).AddTicks(4871), new DateTime(2021, 12, 19, 15, 28, 27, 916, DateTimeKind.Local).AddTicks(4879) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 919, DateTimeKind.Local).AddTicks(7008), new DateTime(2021, 12, 19, 15, 28, 27, 919, DateTimeKind.Local).AddTicks(7020) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 919, DateTimeKind.Local).AddTicks(7408), new DateTime(2021, 12, 19, 15, 28, 27, 919, DateTimeKind.Local).AddTicks(7411) });
        }
    }
}
