using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class addingmailTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mb_mail_data",
                columns: table => new
                {
                    mail_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    to_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
                    date_modified = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_mail_data", x => x.mail_id);
                });

            migrationBuilder.CreateTable(
                name: "mb_mail_attachment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    attachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailEntityMail_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_mail_attachment", x => x.id);
                    table.ForeignKey(
                        name: "FK_mb_mail_attachment_mb_mail_data_MailEntityMail_id",
                        column: x => x.MailEntityMail_id,
                        principalTable: "mb_mail_data",
                        principalColumn: "mail_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mb_mail_attachment_MailEntityMail_id",
                table: "mb_mail_attachment",
                column: "MailEntityMail_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mb_mail_attachment");

            migrationBuilder.DropTable(
                name: "mb_mail_data");
        }
    }
}
