using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNhom11.Migrations
{
    /// <inheritdoc />
    public partial class PhieuBH : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhieuBH",
                columns: table => new
                {
                    MaPBH = table.Column<string>(type: "TEXT", nullable: false),
                    MaKH = table.Column<string>(type: "TEXT", nullable: false),
                    MaNV = table.Column<string>(type: "TEXT", nullable: false),
                    NgayBan = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TinhTrang = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuBH", x => x.MaPBH);
                    table.ForeignKey(
                        name: "FK_PhieuBH_KhachHang_MaKH",
                        column: x => x.MaKH,
                        principalTable: "KhachHang",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhieuBH_NhanVien_MaNV",
                        column: x => x.MaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhieuBH_MaKH",
                table: "PhieuBH",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuBH_MaNV",
                table: "PhieuBH",
                column: "MaNV");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhieuBH");
        }
    }
}
