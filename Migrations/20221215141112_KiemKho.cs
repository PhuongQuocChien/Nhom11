using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNhom11.Migrations
{
    /// <inheritdoc />
    public partial class KiemKho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KiemKho",
                columns: table => new
                {
                    MaKK = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    NgayKK = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MaHH = table.Column<string>(type: "TEXT", nullable: false),
                    Makho = table.Column<string>(type: "TEXT", nullable: false),
                    Sluongkk = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KiemKho", x => x.MaKK);
                    table.ForeignKey(
                        name: "FK_KiemKho_HangHoa_MaHH",
                        column: x => x.MaHH,
                        principalTable: "HangHoa",
                        principalColumn: "MaHH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KiemKho_Kho_Makho",
                        column: x => x.Makho,
                        principalTable: "Kho",
                        principalColumn: "Makho",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KiemKho_MaHH",
                table: "KiemKho",
                column: "MaHH");

            migrationBuilder.CreateIndex(
                name: "IX_KiemKho_Makho",
                table: "KiemKho",
                column: "Makho");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KiemKho");
        }
    }
}
