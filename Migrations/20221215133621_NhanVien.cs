using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNhom11.Migrations
{
    /// <inheritdoc />
    public partial class NhanVien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    MaNV = table.Column<string>(type: "TEXT", nullable: false),
                    TenNV = table.Column<string>(type: "TEXT", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MaQueQuan = table.Column<string>(type: "TEXT", nullable: false),
                    MaGioiTinh = table.Column<string>(type: "TEXT", nullable: false),
                    MaChucVu = table.Column<string>(type: "TEXT", nullable: false),
                    SDTNV = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.MaNV);
                    table.ForeignKey(
                        name: "FK_NhanVien_ChucVu_MaChucVu",
                        column: x => x.MaChucVu,
                        principalTable: "ChucVu",
                        principalColumn: "MaChucVu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhanVien_GioiTinh_MaGioiTinh",
                        column: x => x.MaGioiTinh,
                        principalTable: "GioiTinh",
                        principalColumn: "MaGioiTinh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhanVien_QueQuan_MaQueQuan",
                        column: x => x.MaQueQuan,
                        principalTable: "QueQuan",
                        principalColumn: "MaQueQuan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MaChucVu",
                table: "NhanVien",
                column: "MaChucVu");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MaGioiTinh",
                table: "NhanVien",
                column: "MaGioiTinh");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MaQueQuan",
                table: "NhanVien",
                column: "MaQueQuan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NhanVien");
        }
    }
}
