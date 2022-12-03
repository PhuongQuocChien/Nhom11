using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTapNhom11.Migrations
{
    /// <inheritdoc />
    public partial class QueQuan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QueQuan",
                columns: table => new
                {
                    MaQueQuan = table.Column<string>(type: "TEXT", nullable: false),
                    TenQueQuan = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueQuan", x => x.MaQueQuan);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QueQuan");
        }
    }
}
