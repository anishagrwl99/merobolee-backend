using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class favouriteTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "User_experience",
                table: "mb_user",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "mb_favourite",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_favourite", x => x.id);
                    table.ForeignKey(
                        name: "FK_mb_favourite_mb_category_category_id",
                        column: x => x.category_id,
                        principalTable: "mb_category",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_favourite_mb_user_user_id",
                        column: x => x.user_id,
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mb_favourite_category_id",
                table: "mb_favourite",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_favourite_user_id",
                table: "mb_favourite",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mb_favourite");

            migrationBuilder.DropColumn(
                name: "User_experience",
                table: "mb_user");
        }
    }
}
