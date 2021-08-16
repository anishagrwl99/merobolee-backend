using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class changeinuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_user_mb_company_type_company_type_Id",
                table: "mb_user");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_user_mb_municipality_municipality_id",
                table: "mb_user");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_user_mb_vdc_vdc_id",
                table: "mb_user");

            migrationBuilder.DropIndex(
                name: "IX_mb_user_company_type_Id",
                table: "mb_user");

            migrationBuilder.DropColumn(
                name: "User_experience",
                table: "mb_user");

            migrationBuilder.RenameColumn(
                name: "vdc_id",
                table: "mb_user",
                newName: "VDCEntityVdc_Id");

            migrationBuilder.RenameColumn(
                name: "municipality_id",
                table: "mb_user",
                newName: "MunicipalityEntityMunicipality_id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_user_vdc_id",
                table: "mb_user",
                newName: "IX_mb_user_VDCEntityVdc_Id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_user_municipality_id",
                table: "mb_user",
                newName: "IX_mb_user_MunicipalityEntityMunicipality_id");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_user_mb_municipality_MunicipalityEntityMunicipality_id",
                table: "mb_user",
                column: "MunicipalityEntityMunicipality_id",
                principalTable: "mb_municipality",
                principalColumn: "municipality_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_user_mb_vdc_VDCEntityVdc_Id",
                table: "mb_user",
                column: "VDCEntityVdc_Id",
                principalTable: "mb_vdc",
                principalColumn: "vdc_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_user_mb_municipality_MunicipalityEntityMunicipality_id",
                table: "mb_user");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_user_mb_vdc_VDCEntityVdc_Id",
                table: "mb_user");

            migrationBuilder.RenameColumn(
                name: "VDCEntityVdc_Id",
                table: "mb_user",
                newName: "vdc_id");

            migrationBuilder.RenameColumn(
                name: "MunicipalityEntityMunicipality_id",
                table: "mb_user",
                newName: "municipality_id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_user_VDCEntityVdc_Id",
                table: "mb_user",
                newName: "IX_mb_user_vdc_id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_user_MunicipalityEntityMunicipality_id",
                table: "mb_user",
                newName: "IX_mb_user_municipality_id");

            migrationBuilder.AddColumn<string>(
                name: "User_experience",
                table: "mb_user",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_company_type_Id",
                table: "mb_user",
                column: "company_type_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_user_mb_company_type_company_type_Id",
                table: "mb_user",
                column: "company_type_Id",
                principalTable: "mb_company_type",
                principalColumn: "company_type_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_user_mb_municipality_municipality_id",
                table: "mb_user",
                column: "municipality_id",
                principalTable: "mb_municipality",
                principalColumn: "municipality_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_user_mb_vdc_vdc_id",
                table: "mb_user",
                column: "vdc_id",
                principalTable: "mb_vdc",
                principalColumn: "vdc_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
