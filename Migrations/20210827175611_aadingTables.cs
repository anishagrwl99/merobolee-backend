using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class aadingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mb_FAQ",
                columns: table => new
                {
                    faq_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status_id = table.Column<int>(type: "int", nullable: false),
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
                    date_modified = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_FAQ", x => x.faq_id);
                    table.ForeignKey(
                        name: "FK_mb_FAQ_mb_common_status_status_id",
                        column: x => x.status_id,
                        principalTable: "mb_common_status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mb_request_help_status",
                columns: table => new
                {
                    status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    request_status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_request_help_status", x => x.status_id);
                });

            migrationBuilder.CreateTable(
                name: "mb_request_help",
                columns: table => new
                {
                    request_help_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    problem_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    help_status_id = table.Column<int>(type: "int", nullable: false),
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
                    date_modified = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_request_help", x => x.request_help_id);
                    table.ForeignKey(
                        name: "FK_mb_request_help_mb_request_help_status_help_status_id",
                        column: x => x.help_status_id,
                        principalTable: "mb_request_help_status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mb_FAQ_status_id",
                table: "mb_FAQ",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_request_help_help_status_id",
                table: "mb_request_help",
                column: "help_status_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mb_FAQ");

            migrationBuilder.DropTable(
                name: "mb_request_help");

            migrationBuilder.DropTable(
                name: "mb_request_help_status");
        }
    }
}
