using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class changeOnCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "vdc_id",
                table: "mb_city",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_mb_city_vdc_id",
                table: "mb_city",
                column: "vdc_id");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_city_mb_vdc_vdc_id",
                table: "mb_city",
                column: "vdc_id",
                principalTable: "mb_vdc",
                principalColumn: "vdc_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_city_mb_vdc_vdc_id",
                table: "mb_city");

            migrationBuilder.DropIndex(
                name: "IX_mb_city_vdc_id",
                table: "mb_city");

            migrationBuilder.DropColumn(
                name: "vdc_id",
                table: "mb_city");
        }
    }
}
