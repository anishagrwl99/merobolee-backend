using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class tendermaterial_feature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_material_feature_mb_tender_material_TenderMaterialEntityId",
                schema: "dbo",
                table: "mb_material_feature");

            migrationBuilder.DropIndex(
                name: "IX_mb_material_feature_TenderMaterialEntityId",
                schema: "dbo",
                table: "mb_material_feature");

            migrationBuilder.DropColumn(
                name: "TenderMaterialEntityId",
                schema: "dbo",
                table: "mb_material_feature");

            migrationBuilder.AddColumn<int>(
                name: "material_id",
                schema: "dbo",
                table: "mb_material_feature",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_mb_material_feature_material_id",
                schema: "dbo",
                table: "mb_material_feature",
                column: "material_id");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_material_feature_mb_tender_material_material_id",
                schema: "dbo",
                table: "mb_material_feature",
                column: "material_id",
                principalSchema: "dbo",
                principalTable: "mb_tender_material",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_material_feature_mb_tender_material_material_id",
                schema: "dbo",
                table: "mb_material_feature");

            migrationBuilder.DropIndex(
                name: "IX_mb_material_feature_material_id",
                schema: "dbo",
                table: "mb_material_feature");

            migrationBuilder.DropColumn(
                name: "material_id",
                schema: "dbo",
                table: "mb_material_feature");

            migrationBuilder.AddColumn<int>(
                name: "TenderMaterialEntityId",
                schema: "dbo",
                table: "mb_material_feature",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_mb_material_feature_TenderMaterialEntityId",
                schema: "dbo",
                table: "mb_material_feature",
                column: "TenderMaterialEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_material_feature_mb_tender_material_TenderMaterialEntityId",
                schema: "dbo",
                table: "mb_material_feature",
                column: "TenderMaterialEntityId",
                principalSchema: "dbo",
                principalTable: "mb_tender_material",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
