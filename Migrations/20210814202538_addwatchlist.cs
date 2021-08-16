using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class addwatchlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IFB_RFB_EOI",
                table: "mb_tender",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_request_date",
                table: "mb_tender",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "project_start_date",
                table: "mb_tender",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "source_fund",
                table: "mb_tender",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "mb_watchlist",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    tender_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_watchlist", x => x.id);
                    table.ForeignKey(
                        name: "FK_mb_watchlist_mb_tender_tender_id",
                        column: x => x.tender_id,
                        principalTable: "mb_tender",
                        principalColumn: "tender_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_watchlist_mb_user_user_id",
                        column: x => x.user_id,
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mb_watchlist_tender_id",
                table: "mb_watchlist",
                column: "tender_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_watchlist_user_id",
                table: "mb_watchlist",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mb_watchlist");

            migrationBuilder.DropColumn(
                name: "IFB_RFB_EOI",
                table: "mb_tender");

            migrationBuilder.DropColumn(
                name: "last_request_date",
                table: "mb_tender");

            migrationBuilder.DropColumn(
                name: "project_start_date",
                table: "mb_tender");

            migrationBuilder.DropColumn(
                name: "source_fund",
                table: "mb_tender");
        }
    }
}
