using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class table_name_typo_fixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_bidder_requesst_doc_mb_bidder_request_request_id",
                table: "mb_bidder_requesst_doc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_mb_bidder_requesst_doc",
                table: "mb_bidder_requesst_doc");

            migrationBuilder.RenameTable(
                name: "mb_bidder_requesst_doc",
                newName: "mb_bidder_request_doc");

            migrationBuilder.RenameIndex(
                name: "IX_mb_bidder_requesst_doc_request_id",
                table: "mb_bidder_request_doc",
                newName: "IX_mb_bidder_request_doc_request_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_mb_bidder_request_doc",
                table: "mb_bidder_request_doc",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_bidder_request_doc_mb_bidder_request_request_id",
                table: "mb_bidder_request_doc",
                column: "request_id",
                principalTable: "mb_bidder_request",
                principalColumn: "request_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_bidder_request_doc_mb_bidder_request_request_id",
                table: "mb_bidder_request_doc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_mb_bidder_request_doc",
                table: "mb_bidder_request_doc");

            migrationBuilder.RenameTable(
                name: "mb_bidder_request_doc",
                newName: "mb_bidder_requesst_doc");

            migrationBuilder.RenameIndex(
                name: "IX_mb_bidder_request_doc_request_id",
                table: "mb_bidder_requesst_doc",
                newName: "IX_mb_bidder_requesst_doc_request_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_mb_bidder_requesst_doc",
                table: "mb_bidder_requesst_doc",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_bidder_requesst_doc_mb_bidder_request_request_id",
                table: "mb_bidder_requesst_doc",
                column: "request_id",
                principalTable: "mb_bidder_request",
                principalColumn: "request_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
