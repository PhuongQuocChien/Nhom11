using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTapNhom11.Migrations
{
    /// <inheritdoc />
    public partial class HoaDonNhap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HoaDonNhap",
                columns: table => new
                {
                    MaHoaDonNhap = table.Column<string>(type: "TEXT", nullable: false),
                    TenHoaDonNhap = table.Column<string>(type: "TEXT", nullable: false),
                    NhaCungCap = table.Column<string>(type: "TEXT", nullable: false),
                    TenVatPham = table.Column<string>(type: "TEXT", nullable: false),
                    SoLuong = table.Column<string>(type: "TEXT", nullable: true),
                    TongTien = table.Column<string>(type: "TEXT", nullable: true),
                    NgayNhap = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonNhap", x => x.MaHoaDonNhap);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HoaDonNhap");
        }
    }
}
