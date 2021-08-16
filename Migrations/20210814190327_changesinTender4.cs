using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class changesinTender4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_material_feature_mb_tender_material_material_id",
                table: "mb_material_feature");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_tender_term_condition_mb_tender_tender_id",
                table: "mb_tender_term_condition");

            migrationBuilder.DropIndex(
                name: "IX_mb_tender_term_condition_tender_id",
                table: "mb_tender_term_condition");

            migrationBuilder.DropIndex(
                name: "IX_mb_material_feature_material_id",
                table: "mb_material_feature");

            migrationBuilder.DropColumn(
                name: "tender_id",
                table: "mb_tender_term_condition");

            migrationBuilder.DropColumn(
                name: "material_id",
                table: "mb_material_feature");

            migrationBuilder.AddColumn<int>(
                name: "TenderEntityTender_Id",
                table: "mb_tender_term_condition",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenderMaterialEntityId",
                table: "mb_material_feature",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_term_condition_TenderEntityTender_Id",
                table: "mb_tender_term_condition",
                column: "TenderEntityTender_Id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_material_feature_TenderMaterialEntityId",
                table: "mb_material_feature",
                column: "TenderMaterialEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_material_feature_mb_tender_material_TenderMaterialEntityId",
                table: "mb_material_feature",
                column: "TenderMaterialEntityId",
                principalTable: "mb_tender_material",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_tender_term_condition_mb_tender_TenderEntityTender_Id",
                table: "mb_tender_term_condition",
                column: "TenderEntityTender_Id",
                principalTable: "mb_tender",
                principalColumn: "tender_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_material_feature_mb_tender_material_TenderMaterialEntityId",
                table: "mb_material_feature");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_tender_term_condition_mb_tender_TenderEntityTender_Id",
                table: "mb_tender_term_condition");

            migrationBuilder.DropIndex(
                name: "IX_mb_tender_term_condition_TenderEntityTender_Id",
                table: "mb_tender_term_condition");

            migrationBuilder.DropIndex(
                name: "IX_mb_material_feature_TenderMaterialEntityId",
                table: "mb_material_feature");

            migrationBuilder.DropColumn(
                name: "TenderEntityTender_Id",
                table: "mb_tender_term_condition");

            migrationBuilder.DropColumn(
                name: "TenderMaterialEntityId",
                table: "mb_material_feature");

            migrationBuilder.AddColumn<int>(
                name: "tender_id",
                table: "mb_tender_term_condition",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "material_id",
                table: "mb_material_feature",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_term_condition_tender_id",
                table: "mb_tender_term_condition",
                column: "tender_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_material_feature_material_id",
                table: "mb_material_feature",
                column: "material_id");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_material_feature_mb_tender_material_material_id",
                table: "mb_material_feature",
                column: "material_id",
                principalTable: "mb_tender_material",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_tender_term_condition_mb_tender_tender_id",
                table: "mb_tender_term_condition",
                column: "tender_id",
                principalTable: "mb_tender",
                principalColumn: "tender_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
