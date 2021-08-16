using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_timestamp",
                table: "mb_vdc");

            migrationBuilder.DropColumn(
                name: "modified_timestamp",
                table: "mb_vdc");

            migrationBuilder.DropColumn(
                name: "created_timestamp",
                table: "mb_user");

            migrationBuilder.DropColumn(
                name: "modified_timestamp",
                table: "mb_user");

            migrationBuilder.DropColumn(
                name: "created_timestamp",
                table: "mb_tender");

            migrationBuilder.DropColumn(
                name: "modified_timestamp",
                table: "mb_tender");

            migrationBuilder.DropColumn(
                name: "created_timestamp",
                table: "mb_role");

            migrationBuilder.DropColumn(
                name: "modified_timestamp",
                table: "mb_role");

            migrationBuilder.DropColumn(
                name: "created_timestamp",
                table: "mb_province");

            migrationBuilder.DropColumn(
                name: "modified_timestamp",
                table: "mb_province");

            migrationBuilder.DropColumn(
                name: "created_timestamp",
                table: "mb_municipality");

            migrationBuilder.DropColumn(
                name: "modified_timestamp",
                table: "mb_municipality");

            migrationBuilder.DropColumn(
                name: "created_timestamp",
                table: "mb_membership");

            migrationBuilder.DropColumn(
                name: "modified_timestamp",
                table: "mb_membership");

            migrationBuilder.DropColumn(
                name: "created_timestamp",
                table: "mb_district");

            migrationBuilder.DropColumn(
                name: "modified_timestamp",
                table: "mb_district");

            migrationBuilder.DropColumn(
                name: "created_timestamp",
                table: "mb_country");

            migrationBuilder.DropColumn(
                name: "modified_timestamp",
                table: "mb_country");

            migrationBuilder.DropColumn(
                name: "created_timestamp",
                table: "mb_company_type");

            migrationBuilder.DropColumn(
                name: "modified_timestamp",
                table: "mb_company_type");

            migrationBuilder.DropColumn(
                name: "created_timestamp",
                table: "mb_city");

            migrationBuilder.DropColumn(
                name: "modified_timestamp",
                table: "mb_city");

            migrationBuilder.DropColumn(
                name: "created_timestamp",
                table: "mb_category");

            migrationBuilder.DropColumn(
                name: "modified_timestamp",
                table: "mb_category");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "created_timestamp",
                table: "mb_vdc",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "modified_timestamp",
                table: "mb_vdc",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "created_timestamp",
                table: "mb_user",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "modified_timestamp",
                table: "mb_user",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "created_timestamp",
                table: "mb_tender",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "modified_timestamp",
                table: "mb_tender",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "created_timestamp",
                table: "mb_role",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "modified_timestamp",
                table: "mb_role",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "created_timestamp",
                table: "mb_province",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "modified_timestamp",
                table: "mb_province",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "created_timestamp",
                table: "mb_municipality",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "modified_timestamp",
                table: "mb_municipality",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "created_timestamp",
                table: "mb_membership",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "modified_timestamp",
                table: "mb_membership",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "created_timestamp",
                table: "mb_district",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "modified_timestamp",
                table: "mb_district",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "created_timestamp",
                table: "mb_country",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "modified_timestamp",
                table: "mb_country",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "created_timestamp",
                table: "mb_company_type",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "modified_timestamp",
                table: "mb_company_type",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "created_timestamp",
                table: "mb_city",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "modified_timestamp",
                table: "mb_city",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "created_timestamp",
                table: "mb_category",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "modified_timestamp",
                table: "mb_category",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
