using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNhom11.Migrations
{
    /// <inheritdoc />
    public partial class MenuSach : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuSach",
                columns: table => new
                {
                    MaSach = table.Column<string>(type: "TEXT", nullable: false),
                    MaNhap = table.Column<string>(type: "TEXT", nullable: false),
                    MaTheLoai = table.Column<string>(type: "TEXT", nullable: false),
                    TacGia = table.Column<string>(type: "TEXT", nullable: true),
                    GiaTien = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuSach", x => x.MaSach);
                    table.ForeignKey(
                        name: "FK_MenuSach_NhapSach_MaNhap",
                        column: x => x.MaNhap,
                        principalTable: "NhapSach",
                        principalColumn: "MaNhap",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuSach_TheLoai_MaTheLoai",
                        column: x => x.MaTheLoai,
                        principalTable: "TheLoai",
                        principalColumn: "MaTheLoai",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuSach_MaNhap",
                table: "MenuSach",
                column: "MaNhap");

            migrationBuilder.CreateIndex(
                name: "IX_MenuSach_MaTheLoai",
                table: "MenuSach",
                column: "MaTheLoai");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuSach");
        }
    }
}
