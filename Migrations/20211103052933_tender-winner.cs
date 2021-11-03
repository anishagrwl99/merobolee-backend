using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class tenderwinner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mb_tender_winner",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenderId = table.Column<long>(type: "bigint", nullable: false),
                    WinnerCompanyId = table.Column<long>(type: "bigint", nullable: false),
                    date_created = table.Column<DateTime>(type: "datetime", nullable: false),
                    date_modified = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_tender_winner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mb_tender_winner_mb_company_WinnerCompanyId",
                        column: x => x.WinnerCompanyId,
                        principalSchema: "dbo",
                        principalTable: "mb_company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_tender_winner_mb_tender_TenderId",
                        column: x => x.TenderId,
                        principalSchema: "dbo",
                        principalTable: "mb_tender",
                        principalColumn: "tender_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 33, 216, DateTimeKind.Local).AddTicks(4395), new DateTime(2021, 11, 3, 11, 14, 33, 216, DateTimeKind.Local).AddTicks(4422) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 33, 216, DateTimeKind.Local).AddTicks(4451), new DateTime(2021, 11, 3, 11, 14, 33, 216, DateTimeKind.Local).AddTicks(4455) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 33, 216, DateTimeKind.Local).AddTicks(4469), new DateTime(2021, 11, 3, 11, 14, 33, 216, DateTimeKind.Local).AddTicks(4472) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 33, 255, DateTimeKind.Local).AddTicks(9727), new DateTime(2021, 11, 3, 11, 14, 33, 255, DateTimeKind.Local).AddTicks(9753) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 33, 255, DateTimeKind.Local).AddTicks(9765), new DateTime(2021, 11, 3, 11, 14, 33, 255, DateTimeKind.Local).AddTicks(9768) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 33, 255, DateTimeKind.Local).AddTicks(9778), new DateTime(2021, 11, 3, 11, 14, 33, 255, DateTimeKind.Local).AddTicks(9781) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 33, 226, DateTimeKind.Local).AddTicks(6809), new DateTime(2021, 11, 3, 11, 14, 33, 226, DateTimeKind.Local).AddTicks(6832), "SP112103111432696" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(212), new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(216) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 694, DateTimeKind.Local).AddTicks(9148), new DateTime(2021, 11, 3, 11, 14, 32, 695, DateTimeKind.Local).AddTicks(8139) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 695, DateTimeKind.Local).AddTicks(8603), new DateTime(2021, 11, 3, 11, 14, 32, 695, DateTimeKind.Local).AddTicks(8608) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 695, DateTimeKind.Local).AddTicks(8611), new DateTime(2021, 11, 3, 11, 14, 32, 695, DateTimeKind.Local).AddTicks(8612) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(1367), new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(1371) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(1375), new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(1376) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(1377), new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(1378) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(1381), new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(1382) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(1385), new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(1386) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(1388), new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(1389) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(1390), new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(1391) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(5981), new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(5986) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(5989), new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(5990) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(5991), new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(5992) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 700, DateTimeKind.Local).AddTicks(9737), new DateTime(2021, 11, 3, 11, 14, 32, 700, DateTimeKind.Local).AddTicks(9756) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 704, DateTimeKind.Local).AddTicks(4641), new DateTime(2021, 11, 3, 11, 14, 32, 704, DateTimeKind.Local).AddTicks(4669) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 704, DateTimeKind.Local).AddTicks(5313), new DateTime(2021, 11, 3, 11, 14, 32, 704, DateTimeKind.Local).AddTicks(5314) });

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_winner_TenderId",
                schema: "dbo",
                table: "mb_tender_winner",
                column: "TenderId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_winner_WinnerCompanyId",
                schema: "dbo",
                table: "mb_tender_winner",
                column: "WinnerCompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mb_tender_winner",
                schema: "dbo");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 2, 16, 43, 46, 657, DateTimeKind.Local).AddTicks(4411), new DateTime(2021, 11, 2, 16, 43, 46, 657, DateTimeKind.Local).AddTicks(4439) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 2, 16, 43, 46, 657, DateTimeKind.Local).AddTicks(4479), new DateTime(2021, 11, 2, 16, 43, 46, 657, DateTimeKind.Local).AddTicks(4484) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 2, 16, 43, 46, 657, DateTimeKind.Local).AddTicks(4500), new DateTime(2021, 11, 2, 16, 43, 46, 657, DateTimeKind.Local).AddTicks(4505) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 2, 16, 43, 46, 658, DateTimeKind.Local).AddTicks(2818), new DateTime(2021, 11, 2, 16, 43, 46, 658, DateTimeKind.Local).AddTicks(2830) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 2, 16, 43, 46, 658, DateTimeKind.Local).AddTicks(2844), new DateTime(2021, 11, 2, 16, 43, 46, 658, DateTimeKind.Local).AddTicks(2848) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 2, 16, 43, 46, 658, DateTimeKind.Local).AddTicks(2859), new DateTime(2021, 11, 2, 16, 43, 46, 658, DateTimeKind.Local).AddTicks(2863) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 2, 16, 43, 46, 658, DateTimeKind.Local).AddTicks(145), new DateTime(2021, 11, 2, 16, 43, 46, 658, DateTimeKind.Local).AddTicks(158), "SP112102164345130" });

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
    }
}
