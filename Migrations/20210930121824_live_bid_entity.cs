using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class live_bid_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mb_live_bid",
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
                    table.PrimaryKey("PK_mb_live_bid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mb_live_bid_mb_bidder_request_BiddingRequestId",
                        column: x => x.BiddingRequestId,
                        principalSchema: "dbo",
                        principalTable: "mb_bidder_request",
                        principalColumn: "request_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_live_bid_mb_tender_material_MaterialId",
                        column: x => x.MaterialId,
                        principalSchema: "dbo",
                        principalTable: "mb_tender_material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_live_bid_mb_tender_TenderId",
                        column: x => x.TenderId,
                        principalSchema: "dbo",
                        principalTable: "mb_tender",
                        principalColumn: "tender_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_live_bid_mb_user_SupplierId",
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
                values: new object[] { new DateTime(2021, 9, 30, 18, 3, 23, 411, DateTimeKind.Local).AddTicks(6117), new DateTime(2021, 9, 30, 18, 3, 23, 411, DateTimeKind.Local).AddTicks(6151) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 18, 3, 23, 411, DateTimeKind.Local).AddTicks(6206), new DateTime(2021, 9, 30, 18, 3, 23, 411, DateTimeKind.Local).AddTicks(6214) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 18, 3, 23, 411, DateTimeKind.Local).AddTicks(6244), new DateTime(2021, 9, 30, 18, 3, 23, 411, DateTimeKind.Local).AddTicks(6255) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 18, 3, 23, 453, DateTimeKind.Local).AddTicks(4235), new DateTime(2021, 9, 30, 18, 3, 23, 453, DateTimeKind.Local).AddTicks(4270) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 18, 3, 23, 453, DateTimeKind.Local).AddTicks(4285), new DateTime(2021, 9, 30, 18, 3, 23, 453, DateTimeKind.Local).AddTicks(4289) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 18, 3, 23, 453, DateTimeKind.Local).AddTicks(4299), new DateTime(2021, 9, 30, 18, 3, 23, 453, DateTimeKind.Local).AddTicks(4302) });

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

            migrationBuilder.CreateIndex(
                name: "IX_mb_live_bid_BiddingRequestId",
                schema: "dbo",
                table: "mb_live_bid",
                column: "BiddingRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_live_bid_MaterialId",
                schema: "dbo",
                table: "mb_live_bid",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_live_bid_SupplierId",
                schema: "dbo",
                table: "mb_live_bid",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_live_bid_TenderId",
                schema: "dbo",
                table: "mb_live_bid",
                column: "TenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mb_live_bid",
                schema: "dbo");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 39, 52, 404, DateTimeKind.Local).AddTicks(7726), new DateTime(2021, 9, 30, 11, 39, 52, 404, DateTimeKind.Local).AddTicks(7795) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 39, 52, 404, DateTimeKind.Local).AddTicks(7859), new DateTime(2021, 9, 30, 11, 39, 52, 404, DateTimeKind.Local).AddTicks(7863) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 39, 52, 404, DateTimeKind.Local).AddTicks(7878), new DateTime(2021, 9, 30, 11, 39, 52, 404, DateTimeKind.Local).AddTicks(7881) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 39, 52, 405, DateTimeKind.Local).AddTicks(5602), new DateTime(2021, 9, 30, 11, 39, 52, 405, DateTimeKind.Local).AddTicks(5657) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 39, 52, 405, DateTimeKind.Local).AddTicks(5671), new DateTime(2021, 9, 30, 11, 39, 52, 405, DateTimeKind.Local).AddTicks(5675) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 39, 52, 405, DateTimeKind.Local).AddTicks(5686), new DateTime(2021, 9, 30, 11, 39, 52, 405, DateTimeKind.Local).AddTicks(5689) });

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
        }
    }
}
