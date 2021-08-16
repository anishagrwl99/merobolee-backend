using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class changeinTender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_tender_mb_common_status_PublishStatusStatus_id",
                table: "mb_tender");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_tender_mb_payment_status_payment_status_id",
                table: "mb_tender");

            migrationBuilder.DropIndex(
                name: "IX_mb_tender_payment_status_id",
                table: "mb_tender");

            migrationBuilder.DropIndex(
                name: "IX_mb_tender_PublishStatusStatus_id",
                table: "mb_tender");

            migrationBuilder.DropColumn(
                name: "PublishStatusStatus_id",
                table: "mb_tender");

            migrationBuilder.DropColumn(
                name: "payment_status_id",
                table: "mb_tender");

            migrationBuilder.AddColumn<int>(
                name: "PaymentStatusEntity",
                table: "mb_tender_material",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_material_PaymentStatusEntity",
                table: "mb_tender_material",
                column: "PaymentStatusEntity");

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_tender_status_id",
                table: "mb_tender",
                column: "tender_status_id");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_tender_mb_auction_status_tender_status_id",
                table: "mb_tender",
                column: "tender_status_id",
                principalTable: "mb_auction_status",
                principalColumn: "status_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_tender_material_mb_tender_PaymentStatusEntity",
                table: "mb_tender_material",
                column: "PaymentStatusEntity",
                principalTable: "mb_tender",
                principalColumn: "tender_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_tender_mb_auction_status_tender_status_id",
                table: "mb_tender");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_tender_material_mb_tender_PaymentStatusEntity",
                table: "mb_tender_material");

            migrationBuilder.DropIndex(
                name: "IX_mb_tender_material_PaymentStatusEntity",
                table: "mb_tender_material");

            migrationBuilder.DropIndex(
                name: "IX_mb_tender_tender_status_id",
                table: "mb_tender");

            migrationBuilder.DropColumn(
                name: "PaymentStatusEntity",
                table: "mb_tender_material");

            migrationBuilder.AddColumn<int>(
                name: "PublishStatusStatus_id",
                table: "mb_tender",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "payment_status_id",
                table: "mb_tender",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_payment_status_id",
                table: "mb_tender",
                column: "payment_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_PublishStatusStatus_id",
                table: "mb_tender",
                column: "PublishStatusStatus_id");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_tender_mb_common_status_PublishStatusStatus_id",
                table: "mb_tender",
                column: "PublishStatusStatus_id",
                principalTable: "mb_common_status",
                principalColumn: "status_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_tender_mb_payment_status_payment_status_id",
                table: "mb_tender",
                column: "payment_status_id",
                principalTable: "mb_payment_status",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
