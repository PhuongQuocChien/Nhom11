using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNhom11.Migrations
{
    /// <inheritdoc />
    public partial class NhapSACH : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NhapSach",
                columns: table => new
                {
                    MaNhap = table.Column<string>(type: "TEXT", nullable: false),
                    MaHH = table.Column<string>(type: "TEXT", nullable: false),
                    Mancc = table.Column<string>(type: "TEXT", nullable: false),
                    Makho = table.Column<string>(type: "TEXT", nullable: false),
                    SoluongNhap = table.Column<string>(type: "TEXT", nullable: false),
                    ngayNhap = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhapSach", x => x.MaNhap);
                    table.ForeignKey(
                        name: "FK_NhapSach_HangHoa_MaHH",
                        column: x => x.MaHH,
                        principalTable: "HangHoa",
                        principalColumn: "MaHH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhapSach_Kho_Makho",
                        column: x => x.Makho,
                        principalTable: "Kho",
                        principalColumn: "Makho",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhapSach_NhaCungCap_Mancc",
                        column: x => x.Mancc,
                        principalTable: "NhaCungCap",
                        principalColumn: "Mancc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NhapSach_MaHH",
                table: "NhapSach",
                column: "MaHH");

            migrationBuilder.CreateIndex(
                name: "IX_NhapSach_Makho",
                table: "NhapSach",
                column: "Makho");

            migrationBuilder.CreateIndex(
                name: "IX_NhapSach_Mancc",
                table: "NhapSach",
                column: "Mancc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NhapSach");
        }
    }
}
