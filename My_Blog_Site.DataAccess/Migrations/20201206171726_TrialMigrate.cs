using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace My_Blog_Site.DataAccess.Migrations
{
    public partial class TrialMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Article_Summary = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Article_Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publish_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    View_Count = table.Column<int>(type: "int", nullable: false),
                    _CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleTable_CategoryTable__CategoryId",
                        column: x => x._CategoryId,
                        principalTable: "CategoryTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommentTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment_Owner_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Comment_Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publish_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    _ArticleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentTable_ArticleTable__ArticleId",
                        column: x => x._ArticleId,
                        principalTable: "ArticleTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTable__CategoryId",
                table: "ArticleTable",
                column: "_CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentTable__ArticleId",
                table: "CommentTable",
                column: "_ArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentTable");

            migrationBuilder.DropTable(
                name: "ArticleTable");

            migrationBuilder.DropTable(
                name: "CategoryTable");
        }
    }
}
