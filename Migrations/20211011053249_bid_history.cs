using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class bid_history : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mb_bid_history",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BiddingRequestId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    TenderId = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    Quotation = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BidDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_bid_history", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mb_bid_history_mb_bidder_request_BiddingRequestId",
                        column: x => x.BiddingRequestId,
                        principalSchema: "dbo",
                        principalTable: "mb_bidder_request",
                        principalColumn: "request_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_bid_history_mb_tender_material_MaterialId",
                        column: x => x.MaterialId,
                        principalSchema: "dbo",
                        principalTable: "mb_tender_material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_bid_history_mb_tender_TenderId",
                        column: x => x.TenderId,
                        principalSchema: "dbo",
                        principalTable: "mb_tender",
                        principalColumn: "tender_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_bid_history_mb_user_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "dbo",
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 11, 11, 17, 49, 129, DateTimeKind.Local).AddTicks(8962), new DateTime(2021, 10, 11, 11, 17, 49, 129, DateTimeKind.Local).AddTicks(8989) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 11, 11, 17, 49, 129, DateTimeKind.Local).AddTicks(9014), new DateTime(2021, 10, 11, 11, 17, 49, 129, DateTimeKind.Local).AddTicks(9017) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 11, 11, 17, 49, 129, DateTimeKind.Local).AddTicks(9031), new DateTime(2021, 10, 11, 11, 17, 49, 129, DateTimeKind.Local).AddTicks(9034) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 11, 11, 17, 49, 148, DateTimeKind.Local).AddTicks(25), new DateTime(2021, 10, 11, 11, 17, 49, 148, DateTimeKind.Local).AddTicks(46) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 11, 11, 17, 49, 148, DateTimeKind.Local).AddTicks(58), new DateTime(2021, 10, 11, 11, 17, 49, 148, DateTimeKind.Local).AddTicks(61) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 11, 11, 17, 49, 148, DateTimeKind.Local).AddTicks(70), new DateTime(2021, 10, 11, 11, 17, 49, 148, DateTimeKind.Local).AddTicks(73) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 11, 11, 17, 48, 664, DateTimeKind.Local).AddTicks(1918), new DateTime(2021, 10, 11, 11, 17, 48, 664, DateTimeKind.Local).AddTicks(9480) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 11, 11, 17, 48, 665, DateTimeKind.Local).AddTicks(1277), new DateTime(2021, 10, 11, 11, 17, 48, 665, DateTimeKind.Local).AddTicks(1284) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 11, 11, 17, 48, 665, DateTimeKind.Local).AddTicks(1287), new DateTime(2021, 10, 11, 11, 17, 48, 665, DateTimeKind.Local).AddTicks(1288) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 11, 11, 17, 48, 665, DateTimeKind.Local).AddTicks(1290), new DateTime(2021, 10, 11, 11, 17, 48, 665, DateTimeKind.Local).AddTicks(1291) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 11, 11, 17, 48, 665, DateTimeKind.Local).AddTicks(1292), new DateTime(2021, 10, 11, 11, 17, 48, 665, DateTimeKind.Local).AddTicks(1293) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 11, 11, 17, 48, 665, DateTimeKind.Local).AddTicks(1294), new DateTime(2021, 10, 11, 11, 17, 48, 665, DateTimeKind.Local).AddTicks(1295) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 11, 11, 17, 48, 665, DateTimeKind.Local).AddTicks(1296), new DateTime(2021, 10, 11, 11, 17, 48, 665, DateTimeKind.Local).AddTicks(1297) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 11, 11, 17, 48, 665, DateTimeKind.Local).AddTicks(1299), new DateTime(2021, 10, 11, 11, 17, 48, 665, DateTimeKind.Local).AddTicks(1300) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 11, 11, 17, 48, 665, DateTimeKind.Local).AddTicks(5848), new DateTime(2021, 10, 11, 11, 17, 48, 665, DateTimeKind.Local).AddTicks(5854) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 11, 11, 17, 48, 665, DateTimeKind.Local).AddTicks(5857), new DateTime(2021, 10, 11, 11, 17, 48, 665, DateTimeKind.Local).AddTicks(5858) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 11, 11, 17, 48, 665, DateTimeKind.Local).AddTicks(5859), new DateTime(2021, 10, 11, 11, 17, 48, 665, DateTimeKind.Local).AddTicks(5860) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 11, 11, 17, 48, 666, DateTimeKind.Local).AddTicks(1295), new DateTime(2021, 10, 11, 11, 17, 48, 666, DateTimeKind.Local).AddTicks(1301) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 11, 11, 17, 48, 669, DateTimeKind.Local).AddTicks(2647), new DateTime(2021, 10, 11, 11, 17, 48, 669, DateTimeKind.Local).AddTicks(2661) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 11, 11, 17, 48, 669, DateTimeKind.Local).AddTicks(2986), new DateTime(2021, 10, 11, 11, 17, 48, 669, DateTimeKind.Local).AddTicks(2988) });

            migrationBuilder.CreateIndex(
                name: "IX_mb_bid_history_BiddingRequestId",
                schema: "dbo",
                table: "mb_bid_history",
                column: "BiddingRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_bid_history_MaterialId",
                schema: "dbo",
                table: "mb_bid_history",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_bid_history_SupplierId",
                schema: "dbo",
                table: "mb_bid_history",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_bid_history_TenderId",
                schema: "dbo",
                table: "mb_bid_history",
                column: "TenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mb_bid_history",
                schema: "dbo");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 8, 12, 58, 5, 372, DateTimeKind.Local).AddTicks(6699), new DateTime(2021, 10, 8, 12, 58, 5, 372, DateTimeKind.Local).AddTicks(6737) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 8, 12, 58, 5, 372, DateTimeKind.Local).AddTicks(6769), new DateTime(2021, 10, 8, 12, 58, 5, 372, DateTimeKind.Local).AddTicks(6774) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 8, 12, 58, 5, 372, DateTimeKind.Local).AddTicks(6791), new DateTime(2021, 10, 8, 12, 58, 5, 372, DateTimeKind.Local).AddTicks(6796) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 8, 12, 58, 5, 373, DateTimeKind.Local).AddTicks(1731), new DateTime(2021, 10, 8, 12, 58, 5, 373, DateTimeKind.Local).AddTicks(1743) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 8, 12, 58, 5, 373, DateTimeKind.Local).AddTicks(1757), new DateTime(2021, 10, 8, 12, 58, 5, 373, DateTimeKind.Local).AddTicks(1760) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 8, 12, 58, 5, 373, DateTimeKind.Local).AddTicks(1772), new DateTime(2021, 10, 8, 12, 58, 5, 373, DateTimeKind.Local).AddTicks(1776) });

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
    }
}
