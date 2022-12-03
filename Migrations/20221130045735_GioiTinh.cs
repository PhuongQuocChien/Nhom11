using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTapNhom11.Migrations
{
    /// <inheritdoc />
    public partial class GioiTinh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GioiTinh",
                columns: table => new
                {
                    MaGioiTinh = table.Column<string>(type: "TEXT", nullable: false),
                    TenGioiTinh = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioiTinh", x => x.MaGioiTinh);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GioiTinh");
        }
    }
}
