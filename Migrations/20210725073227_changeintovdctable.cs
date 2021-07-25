using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class changeintovdctable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_municipality_mb_district_district_id",
                table: "mb_municipality");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_vdc_mb_district_district_id",
                table: "mb_vdc");

            migrationBuilder.AlterColumn<int>(
                name: "district_id",
                table: "mb_vdc",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "created_timestamp",
                table: "mb_vdc",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<DateTime>(
                name: "date_created",
                table: "mb_vdc",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "date_modified",
                table: "mb_vdc",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "modified_timestamp",
                table: "mb_vdc",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AlterColumn<int>(
                name: "district_id",
                table: "mb_municipality",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_municipality_mb_district_district_id",
                table: "mb_municipality",
                column: "district_id",
                principalTable: "mb_district",
                principalColumn: "district_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_vdc_mb_district_district_id",
                table: "mb_vdc",
                column: "district_id",
                principalTable: "mb_district",
                principalColumn: "district_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_municipality_mb_district_district_id",
                table: "mb_municipality");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_vdc_mb_district_district_id",
                table: "mb_vdc");

            migrationBuilder.DropColumn(
                name: "created_timestamp",
                table: "mb_vdc");

            migrationBuilder.DropColumn(
                name: "date_created",
                table: "mb_vdc");

            migrationBuilder.DropColumn(
                name: "date_modified",
                table: "mb_vdc");

            migrationBuilder.DropColumn(
                name: "modified_timestamp",
                table: "mb_vdc");

            migrationBuilder.AlterColumn<int>(
                name: "district_id",
                table: "mb_vdc",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "district_id",
                table: "mb_municipality",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_municipality_mb_district_district_id",
                table: "mb_municipality",
                column: "district_id",
                principalTable: "mb_district",
                principalColumn: "district_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_vdc_mb_district_district_id",
                table: "mb_vdc",
                column: "district_id",
                principalTable: "mb_district",
                principalColumn: "district_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
