using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Buoi5.Migrations
{
    /// <inheritdoc />
    public partial class InitialBookDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Cuộc sống" },
                    { 2, "Lập trình" },
                    { 3, "Sức khỏe" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "Image", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Hải Dớ", 1, "Cuộc sống rất giống cuộc đời...", "cuoc-song.jpg", 61000m, "Cuộc Sống Rất Giống Cuộc Đời" },
                    { 2, "Nguyễn Nhật Ánh", 1, "Cho tôi xin một vé đi tuổi thơ...", "ve-tuoi-tho.jpg", 55000m, "Cho Tôi Xin Một Vé Đi Tuổi Thơ" },
                    { 3, "Cay Horstmann", 2, "Core Java Fundamentals...", "java.jpg", 120000m, "Core Java: Fundamentals, Volume 1" },
                    { 4, "TS. Lê Xuân Việt", 2, "Lập trình C cơ bản...", "lap-trinh-c.jpg", 85000m, "Lập trình C" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
