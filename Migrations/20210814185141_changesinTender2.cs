using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class changesinTender2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_tender_material_mb_tender_tender_id",
                table: "mb_tender_material");

            migrationBuilder.DropIndex(
                name: "IX_mb_tender_material_tender_id",
                table: "mb_tender_material");

            migrationBuilder.DropColumn(
                name: "tender_id",
                table: "mb_tender_material");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "tender_id",
                table: "mb_tender_material",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_material_tender_id",
                table: "mb_tender_material",
                column: "tender_id");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_tender_material_mb_tender_tender_id",
                table: "mb_tender_material",
                column: "tender_id",
                principalTable: "mb_tender",
                principalColumn: "tender_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
