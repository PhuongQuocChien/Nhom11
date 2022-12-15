using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNhom11.Migrations
{
    /// <inheritdoc />
    public partial class HangHoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HangHoa",
                columns: table => new
                {
                    MaHH = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    TenHH = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    GiaVonHH = table.Column<decimal>(type: "TEXT", nullable: false),
                    GiaBanHH = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangHoa", x => x.MaHH);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HangHoa");
        }
    }
}
