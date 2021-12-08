using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class auctionlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mb_AuctionLog",
                schema: "dbo",
                columns: table => new
                {
                    LogId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    TenderId = table.Column<long>(type: "bigint", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    BiddingId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_AuctionLog", x => x.LogId);
                    table.ForeignKey(
                        name: "FK_mb_AuctionLog_mb_bidder_request_BiddingId",
                        column: x => x.BiddingId,
                        principalSchema: "dbo",
                        principalTable: "mb_bidder_request",
                        principalColumn: "request_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_AuctionLog_mb_company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "dbo",
                        principalTable: "mb_company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_AuctionLog_mb_tender_TenderId",
                        column: x => x.TenderId,
                        principalSchema: "dbo",
                        principalTable: "mb_tender",
                        principalColumn: "tender_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_AuctionLog_mb_user_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 5, 116, DateTimeKind.Local).AddTicks(4615), new DateTime(2021, 12, 8, 22, 2, 5, 116, DateTimeKind.Local).AddTicks(4642) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 5, 116, DateTimeKind.Local).AddTicks(4670), new DateTime(2021, 12, 8, 22, 2, 5, 116, DateTimeKind.Local).AddTicks(4673) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 5, 116, DateTimeKind.Local).AddTicks(4685), new DateTime(2021, 12, 8, 22, 2, 5, 116, DateTimeKind.Local).AddTicks(4688) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 5, 165, DateTimeKind.Local).AddTicks(1729), new DateTime(2021, 12, 8, 22, 2, 5, 165, DateTimeKind.Local).AddTicks(1761) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 5, 165, DateTimeKind.Local).AddTicks(1772), new DateTime(2021, 12, 8, 22, 2, 5, 165, DateTimeKind.Local).AddTicks(1775) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 5, 165, DateTimeKind.Local).AddTicks(1783), new DateTime(2021, 12, 8, 22, 2, 5, 165, DateTimeKind.Local).AddTicks(1786) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 5, 127, DateTimeKind.Local).AddTicks(7516), new DateTime(2021, 12, 8, 22, 2, 5, 127, DateTimeKind.Local).AddTicks(7543), "MB122108220204452" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 5, 127, DateTimeKind.Local).AddTicks(7615), new DateTime(2021, 12, 8, 22, 2, 5, 127, DateTimeKind.Local).AddTicks(7618), "BI122108220204457" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 5, 127, DateTimeKind.Local).AddTicks(7664), new DateTime(2021, 12, 8, 22, 2, 5, 127, DateTimeKind.Local).AddTicks(7667), "SP122108220204457" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 450, DateTimeKind.Local).AddTicks(9014), new DateTime(2021, 12, 8, 22, 2, 4, 450, DateTimeKind.Local).AddTicks(9019) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 448, DateTimeKind.Local).AddTicks(2832), new DateTime(2021, 12, 8, 22, 2, 4, 450, DateTimeKind.Local).AddTicks(4230) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 450, DateTimeKind.Local).AddTicks(5827), new DateTime(2021, 12, 8, 22, 2, 4, 450, DateTimeKind.Local).AddTicks(5839) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 450, DateTimeKind.Local).AddTicks(5843), new DateTime(2021, 12, 8, 22, 2, 4, 450, DateTimeKind.Local).AddTicks(5845) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(1215), new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(1220) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(1224), new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(1225) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(1227), new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(1228) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(1230), new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(1231) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(1232), new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(1233) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(1235), new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(1236) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(1237), new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(1238) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(9018), new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(9024) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(9028), new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(9029) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(9030), new DateTime(2021, 12, 8, 22, 2, 4, 451, DateTimeKind.Local).AddTicks(9031) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 457, DateTimeKind.Local).AddTicks(7523), new DateTime(2021, 12, 8, 22, 2, 4, 457, DateTimeKind.Local).AddTicks(7533) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 465, DateTimeKind.Local).AddTicks(995), new DateTime(2021, 12, 8, 22, 2, 4, 465, DateTimeKind.Local).AddTicks(1021) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 8, 22, 2, 4, 465, DateTimeKind.Local).AddTicks(1648), new DateTime(2021, 12, 8, 22, 2, 4, 465, DateTimeKind.Local).AddTicks(1655) });

            migrationBuilder.CreateIndex(
                name: "IX_mb_AuctionLog_BiddingId",
                schema: "dbo",
                table: "mb_AuctionLog",
                column: "BiddingId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_AuctionLog_CompanyId",
                schema: "dbo",
                table: "mb_AuctionLog",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_AuctionLog_TenderId",
                schema: "dbo",
                table: "mb_AuctionLog",
                column: "TenderId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_AuctionLog_UserId",
                schema: "dbo",
                table: "mb_AuctionLog",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mb_AuctionLog",
                schema: "dbo");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 37, 598, DateTimeKind.Local).AddTicks(6255), new DateTime(2021, 11, 25, 22, 29, 37, 598, DateTimeKind.Local).AddTicks(6283) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 37, 598, DateTimeKind.Local).AddTicks(6307), new DateTime(2021, 11, 25, 22, 29, 37, 598, DateTimeKind.Local).AddTicks(6311) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 37, 598, DateTimeKind.Local).AddTicks(6326), new DateTime(2021, 11, 25, 22, 29, 37, 598, DateTimeKind.Local).AddTicks(6330) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 37, 599, DateTimeKind.Local).AddTicks(2078), new DateTime(2021, 11, 25, 22, 29, 37, 599, DateTimeKind.Local).AddTicks(2087) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 37, 599, DateTimeKind.Local).AddTicks(2099), new DateTime(2021, 11, 25, 22, 29, 37, 599, DateTimeKind.Local).AddTicks(2103) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 37, 599, DateTimeKind.Local).AddTicks(2113), new DateTime(2021, 11, 25, 22, 29, 37, 599, DateTimeKind.Local).AddTicks(2116) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 37, 598, DateTimeKind.Local).AddTicks(9696), new DateTime(2021, 11, 25, 22, 29, 37, 598, DateTimeKind.Local).AddTicks(9705), "MB112125222936502" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 37, 598, DateTimeKind.Local).AddTicks(9797), new DateTime(2021, 11, 25, 22, 29, 37, 598, DateTimeKind.Local).AddTicks(9801), "BI112125222936506" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 37, 598, DateTimeKind.Local).AddTicks(9864), new DateTime(2021, 11, 25, 22, 29, 37, 598, DateTimeKind.Local).AddTicks(9868), "SP112125222936506" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(502), new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(507) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 501, DateTimeKind.Local).AddTicks(631), new DateTime(2021, 11, 25, 22, 29, 36, 501, DateTimeKind.Local).AddTicks(8434) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 501, DateTimeKind.Local).AddTicks(8916), new DateTime(2021, 11, 25, 22, 29, 36, 501, DateTimeKind.Local).AddTicks(8921) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 501, DateTimeKind.Local).AddTicks(8924), new DateTime(2021, 11, 25, 22, 29, 36, 501, DateTimeKind.Local).AddTicks(8925) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(1712), new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(1717) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(1720), new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(1721) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(1723), new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(1724) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(1725), new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(1726) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(1728), new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(1729) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(1731), new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(1732) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(1733), new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(1734) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(6361), new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(6367) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(6369), new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(6371) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(6372), new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(6373) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 506, DateTimeKind.Local).AddTicks(9823), new DateTime(2021, 11, 25, 22, 29, 36, 506, DateTimeKind.Local).AddTicks(9831) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 510, DateTimeKind.Local).AddTicks(978), new DateTime(2021, 11, 25, 22, 29, 36, 510, DateTimeKind.Local).AddTicks(998) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 510, DateTimeKind.Local).AddTicks(1335), new DateTime(2021, 11, 25, 22, 29, 36, 510, DateTimeKind.Local).AddTicks(1338) });
        }
    }
}
