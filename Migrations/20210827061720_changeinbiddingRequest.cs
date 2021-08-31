using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class changeinbiddingRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_bidder_requesst_doc_mb_bidder_request_BidderRequestEntityRequest_Id",
                table: "mb_bidder_requesst_doc");

            migrationBuilder.DropIndex(
                name: "IX_mb_bidder_requesst_doc_BidderRequestEntityRequest_Id",
                table: "mb_bidder_requesst_doc");

            migrationBuilder.DropColumn(
                name: "BidderRequestEntityRequest_Id",
                table: "mb_bidder_requesst_doc");

            migrationBuilder.AddColumn<int>(
                name: "request_id",
                table: "mb_bidder_requesst_doc",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_mb_bidder_requesst_doc_request_id",
                table: "mb_bidder_requesst_doc",
                column: "request_id");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_bidder_requesst_doc_mb_bidder_request_request_id",
                table: "mb_bidder_requesst_doc",
                column: "request_id",
                principalTable: "mb_bidder_request",
                principalColumn: "request_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_bidder_requesst_doc_mb_bidder_request_request_id",
                table: "mb_bidder_requesst_doc");

            migrationBuilder.DropIndex(
                name: "IX_mb_bidder_requesst_doc_request_id",
                table: "mb_bidder_requesst_doc");

            migrationBuilder.DropColumn(
                name: "request_id",
                table: "mb_bidder_requesst_doc");

            migrationBuilder.AddColumn<int>(
                name: "BidderRequestEntityRequest_Id",
                table: "mb_bidder_requesst_doc",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_mb_bidder_requesst_doc_BidderRequestEntityRequest_Id",
                table: "mb_bidder_requesst_doc",
                column: "BidderRequestEntityRequest_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_bidder_requesst_doc_mb_bidder_request_BidderRequestEntityRequest_Id",
                table: "mb_bidder_requesst_doc",
                column: "BidderRequestEntityRequest_Id",
                principalTable: "mb_bidder_request",
                principalColumn: "request_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
