using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNhom11.Migrations
{
    /// <inheritdoc />
    public partial class KhachHang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    MaKH = table.Column<string>(type: "TEXT", nullable: false),
                    TenKH = table.Column<string>(type: "TEXT", nullable: false),
                    MaGioiTinh = table.Column<string>(type: "TEXT", nullable: true),
                    SDTKH = table.Column<string>(type: "TEXT", nullable: false),
                    DiaChi = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.MaKH);
                    table.ForeignKey(
                        name: "FK_KhachHang_GioiTinh_MaGioiTinh",
                        column: x => x.MaGioiTinh,
                        principalTable: "GioiTinh",
                        principalColumn: "MaGioiTinh");
                });

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_MaGioiTinh",
                table: "KhachHang",
                column: "MaGioiTinh");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KhachHang");
        }
    }
}
