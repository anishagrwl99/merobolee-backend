using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class AddingBidderReuestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IFB_RFB_EOI",
                table: "mb_tender");

            migrationBuilder.CreateTable(
                name: "mb_bidder_request",
                columns: table => new
                {
                    request_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    request_code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    tender_id = table.Column<int>(type: "int", nullable: false),
                    admin_status_id = table.Column<int>(type: "int", nullable: false),
                    request_send_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
                    date_modified = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_bidder_request", x => x.request_id);
                    table.ForeignKey(
                        name: "FK_mb_bidder_request_mb_admin_status_admin_status_id",
                        column: x => x.admin_status_id,
                        principalTable: "mb_admin_status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_bidder_request_mb_tender_tender_id",
                        column: x => x.tender_id,
                        principalTable: "mb_tender",
                        principalColumn: "tender_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_bidder_request_mb_user_user_id",
                        column: x => x.user_id,
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mb_bidder_requesst_doc",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bidder_request_doc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BidderRequestEntityRequest_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_bidder_requesst_doc", x => x.id);
                    table.ForeignKey(
                        name: "FK_mb_bidder_requesst_doc_mb_bidder_request_BidderRequestEntityRequest_Id",
                        column: x => x.BidderRequestEntityRequest_Id,
                        principalTable: "mb_bidder_request",
                        principalColumn: "request_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mb_bidder_requesst_doc_BidderRequestEntityRequest_Id",
                table: "mb_bidder_requesst_doc",
                column: "BidderRequestEntityRequest_Id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_bidder_request_admin_status_id",
                table: "mb_bidder_request",
                column: "admin_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_bidder_request_tender_id",
                table: "mb_bidder_request",
                column: "tender_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_bidder_request_user_id",
                table: "mb_bidder_request",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mb_bidder_requesst_doc");

            migrationBuilder.DropTable(
                name: "mb_bidder_request");

            migrationBuilder.AddColumn<string>(
                name: "IFB_RFB_EOI",
                table: "mb_tender",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
