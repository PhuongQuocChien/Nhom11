using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTapNhom11.Migrations
{
    /// <inheritdoc />
    public partial class KhoSach : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhoSach",
                columns: table => new
                {
                    TenSach = table.Column<string>(type: "TEXT", nullable: false),
                    NgayNhap = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DaBan = table.Column<string>(type: "TEXT", nullable: true),
                    ConLai = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoSach", x => x.TenSach);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KhoSach");
        }
    }
}
