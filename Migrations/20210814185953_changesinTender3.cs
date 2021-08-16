using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class changesinTender3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_tender_material_mb_tender_PaymentStatusEntity",
                table: "mb_tender_material");

            migrationBuilder.RenameColumn(
                name: "PaymentStatusEntity",
                table: "mb_tender_material",
                newName: "TenderEntityTender_Id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_tender_material_PaymentStatusEntity",
                table: "mb_tender_material",
                newName: "IX_mb_tender_material_TenderEntityTender_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_tender_material_mb_tender_TenderEntityTender_Id",
                table: "mb_tender_material",
                column: "TenderEntityTender_Id",
                principalTable: "mb_tender",
                principalColumn: "tender_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_tender_material_mb_tender_TenderEntityTender_Id",
                table: "mb_tender_material");

            migrationBuilder.RenameColumn(
                name: "TenderEntityTender_Id",
                table: "mb_tender_material",
                newName: "PaymentStatusEntity");

            migrationBuilder.RenameIndex(
                name: "IX_mb_tender_material_TenderEntityTender_Id",
                table: "mb_tender_material",
                newName: "IX_mb_tender_material_PaymentStatusEntity");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_tender_material_mb_tender_PaymentStatusEntity",
                table: "mb_tender_material",
                column: "PaymentStatusEntity",
                principalTable: "mb_tender",
                principalColumn: "tender_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
