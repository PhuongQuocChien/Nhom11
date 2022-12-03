using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTapNhom11.Migrations
{
    /// <inheritdoc />
    public partial class Sach : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sach",
                columns: table => new
                {
                    MaSach = table.Column<string>(type: "TEXT", nullable: false),
                    TenSach = table.Column<string>(type: "TEXT", nullable: false),
                    MaTheLoai = table.Column<string>(type: "TEXT", nullable: false),
                    NamXuatBan = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TacGia = table.Column<string>(type: "TEXT", nullable: false),
                    GiaTien = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sach", x => x.MaSach);
                    table.ForeignKey(
                        name: "FK_Sach_KhoSach_TenSach",
                        column: x => x.TenSach,
                        principalTable: "KhoSach",
                        principalColumn: "TenSach",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sach_TheLoai_MaTheLoai",
                        column: x => x.MaTheLoai,
                        principalTable: "TheLoai",
                        principalColumn: "MaTheLoai",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sach_MaTheLoai",
                table: "Sach",
                column: "MaTheLoai");

            migrationBuilder.CreateIndex(
                name: "IX_Sach_TenSach",
                table: "Sach",
                column: "TenSach");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sach");
        }
    }
}
