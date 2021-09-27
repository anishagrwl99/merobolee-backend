using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class TenderMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_tender_material_mb_tender_TenderEntityTender_Id",
                schema: "dbo",
                table: "mb_tender_material");

            migrationBuilder.DropIndex(
                name: "IX_mb_tender_material_TenderEntityTender_Id",
                schema: "dbo",
                table: "mb_tender_material");

            migrationBuilder.DropColumn(
                name: "TenderEntityTender_Id",
                schema: "dbo",
                table: "mb_tender_material");

            migrationBuilder.AddColumn<int>(
                name: "tender_id",
                schema: "dbo",
                table: "mb_tender_material",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_material_tender_id",
                schema: "dbo",
                table: "mb_tender_material",
                column: "tender_id");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_tender_material_mb_tender_tender_id",
                schema: "dbo",
                table: "mb_tender_material",
                column: "tender_id",
                principalSchema: "dbo",
                principalTable: "mb_tender",
                principalColumn: "tender_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_tender_material_mb_tender_tender_id",
                schema: "dbo",
                table: "mb_tender_material");

            migrationBuilder.DropIndex(
                name: "IX_mb_tender_material_tender_id",
                schema: "dbo",
                table: "mb_tender_material");

            migrationBuilder.DropColumn(
                name: "tender_id",
                schema: "dbo",
                table: "mb_tender_material");

            migrationBuilder.AddColumn<int>(
                name: "TenderEntityTender_Id",
                schema: "dbo",
                table: "mb_tender_material",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_material_TenderEntityTender_Id",
                schema: "dbo",
                table: "mb_tender_material",
                column: "TenderEntityTender_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_tender_material_mb_tender_TenderEntityTender_Id",
                schema: "dbo",
                table: "mb_tender_material",
                column: "TenderEntityTender_Id",
                principalSchema: "dbo",
                principalTable: "mb_tender",
                principalColumn: "tender_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
