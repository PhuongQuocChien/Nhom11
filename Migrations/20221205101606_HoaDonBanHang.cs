using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTapNhom11.Migrations
{
    /// <inheritdoc />
    public partial class HoaDonBanHang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HoaDonBanHang",
                columns: table => new
                {
                    MaHoaDon = table.Column<string>(type: "TEXT", nullable: false),
                    MaKhachHang = table.Column<string>(type: "TEXT", nullable: true),
                    MaSach = table.Column<string>(type: "TEXT", nullable: true),
                    MaNhanVien = table.Column<string>(type: "TEXT", nullable: true),
                    NgayLapHoaDon = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TongTien = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonBanHang", x => x.MaHoaDon);
                    table.ForeignKey(
                        name: "FK_HoaDonBanHang_KhachHang_MaKhachHang",
                        column: x => x.MaKhachHang,
                        principalTable: "KhachHang",
                        principalColumn: "MaKhachHang");
                    table.ForeignKey(
                        name: "FK_HoaDonBanHang_NhanVien_MaNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "MaNhanVien");
                    table.ForeignKey(
                        name: "FK_HoaDonBanHang_Sach_MaSach",
                        column: x => x.MaSach,
                        principalTable: "Sach",
                        principalColumn: "MaSach");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonBanHang_MaKhachHang",
                table: "HoaDonBanHang",
                column: "MaKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonBanHang_MaNhanVien",
                table: "HoaDonBanHang",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonBanHang_MaSach",
                table: "HoaDonBanHang",
                column: "MaSach");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HoaDonBanHang");
        }
    }
}
