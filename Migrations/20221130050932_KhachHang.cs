using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTapNhom11.Migrations
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
                    MaKhachHang = table.Column<string>(type: "TEXT", nullable: false),
                    TenKhachHang = table.Column<string>(type: "TEXT", nullable: false),
                    MaGioiTinh = table.Column<string>(type: "TEXT", nullable: true),
                    SDT = table.Column<string>(type: "TEXT", nullable: false),
                    MaThe = table.Column<string>(type: "TEXT", nullable: false),
                    DiaChi = table.Column<string>(type: "TEXT", nullable: false),
                    CMND = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.MaKhachHang);
                    table.ForeignKey(
                        name: "FK_KhachHang_GioiTinh_MaGioiTinh",
                        column: x => x.MaGioiTinh,
                        principalTable: "GioiTinh",
                        principalColumn: "MaGioiTinh");
                    table.ForeignKey(
                        name: "FK_KhachHang_TheKhachHang_MaThe",
                        column: x => x.MaThe,
                        principalTable: "TheKhachHang",
                        principalColumn: "MaThe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_MaGioiTinh",
                table: "KhachHang",
                column: "MaGioiTinh");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_MaThe",
                table: "KhachHang",
                column: "MaThe");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KhachHang");
        }
    }
}
